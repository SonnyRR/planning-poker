namespace PlanningPoker.Identity.Controllers
{
    using Identity.Models.View;
    using Identity.Utilities;

    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Primitives;

    using OpenIddict.Abstractions;
    using OpenIddict.Server.AspNetCore;

    using Persistence.Entities;

    using SharedKernel.Extensions;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using static OpenIddict.Abstractions.OpenIddictConstants;

    public class AuthorizationController : Controller
    {
        private readonly IOpenIddictApplicationManager applicationManager;
        private readonly IOpenIddictAuthorizationManager authorizationManager;
        private readonly IOpenIddictScopeManager scopeManager;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public AuthorizationController(
            IOpenIddictApplicationManager applicationManager,
            IOpenIddictAuthorizationManager authorizationManager,
            IOpenIddictScopeManager scopeManager,
            SignInManager<User> signInManager,
            UserManager<User> userManager)
        {
            this.applicationManager = applicationManager;
            this.authorizationManager = authorizationManager;
            this.scopeManager = scopeManager;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [Authorize, FormValueRequired("submit.Accept")]
        [HttpPost("~/connect/authorize"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Accept()
        {
            var request = this.HttpContext.GetOpenIddictServerRequest() ??
                throw new InvalidOperationException("The OpenID Connect request cannot be retrieved.");

            // Retrieve the profile of the logged in user.
            var user = await this.userManager.GetUserAsync(this.User) ??
                throw new InvalidOperationException("The user details cannot be retrieved.");

            // Retrieve the application details from the database.
            var application = await this.applicationManager.FindByClientIdAsync(request.ClientId) ??
                throw new InvalidOperationException("Details concerning the calling client application cannot be found.");

            // Retrieve the permanent authorizations associated with the user and the calling client application.
            var authorizations = await this.authorizationManager.FindAsync(
                subject: await this.userManager.GetUserIdAsync(user),
                client: await this.applicationManager.GetIdAsync(application),
                status: Statuses.Valid,
                type: AuthorizationTypes.Permanent,
                scopes: request.GetScopes()).ToListAsync();

            // Note: the same check is already made in the other action but is repeated
            // here to ensure a malicious user can't abuse this POST-only endpoint and
            // force it to return a valid response without the external authorization.
            if (authorizations.Count == 0 && await this.applicationManager.HasConsentTypeAsync(application, ConsentTypes.External))
            {
                return this.Forbid(
                    properties: new AuthenticationProperties(new Dictionary<string, string>
                    {
                        [OpenIddictServerAspNetCoreConstants.Properties.Error] = Errors.ConsentRequired,
                        [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] =
                            "The logged in user is not allowed to access this client application."
                    }),
                    authenticationSchemes: OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            }

            var principal = await this.signInManager.CreateUserPrincipalAsync(user);

            // Note: in this sample, the granted scopes match the requested scope
            // but you may want to allow the user to uncheck specific scopes.
            // For that, simply restrict the list of scopes before calling SetScopes.
            principal.SetScopes(request.GetScopes());
            principal.SetResources(await this.scopeManager.ListResourcesAsync(principal.GetScopes()).ToListAsync());

            // Automatically create a permanent authorization to avoid requiring explicit consent
            // for future authorization or token requests containing the same scopes.
            var authorization = authorizations.LastOrDefault();
            if (authorization == null)
            {
                authorization = await this.authorizationManager.CreateAsync(
                    principal: principal,
                    subject: await this.userManager.GetUserIdAsync(user),
                    client: await this.applicationManager.GetIdAsync(application),
                    type: AuthorizationTypes.Permanent,
                    scopes: principal.GetScopes());
            }

            principal.SetAuthorizationId(await this.authorizationManager.GetIdAsync(authorization));

            foreach (var claim in principal.Claims)
            {
                claim.SetDestinations(GetDestinations(claim, principal));
            }

            // Returning a SignInResult will ask OpenIddict to issue the appropriate access/identity tokens.
            return this.SignIn(principal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }

        [HttpGet("~/connect/authorize")]
        [HttpPost("~/connect/authorize")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Authorize()
        {
            var request = this.HttpContext.GetOpenIddictServerRequest() ??
                throw new InvalidOperationException("The OpenID Connect request cannot be retrieved.");

            // If prompt=login was specified by the client application,
            // immediately return the user agent to the login page.
            if (request.HasPromptValue(PromptValues.Login))
            {
                // To avoid endless login -> authorization redirects, the prompt=login flag
                // is removed from the authorization request payload before redirecting the user.
                var prompt = string.Join(" ", request.GetPromptValues().Remove(PromptValues.Login));

                var parameters = this.Request.HasFormContentType ?
                    this.Request.Form.Where(parameter => parameter.Key != Parameters.Prompt).ToList() :
                    this.Request.Query.Where(parameter => parameter.Key != Parameters.Prompt).ToList();

                parameters.Add(KeyValuePair.Create(Parameters.Prompt, new StringValues(prompt)));

                return this.Challenge(
                    properties: new AuthenticationProperties
                    {
                        RedirectUri = this.Request.PathBase + this.Request.Path + QueryString.Create(parameters)
                    },
                    authenticationSchemes: IdentityConstants.ApplicationScheme);
            }

            // Retrieve the user principal stored in the authentication cookie.
            // If a max_age parameter was provided, ensure that the cookie is not too old.
            // If the user principal can't be extracted or the cookie is too old, redirect the user to the login page.
            var result = await this.HttpContext.AuthenticateAsync(IdentityConstants.ApplicationScheme);
            if (result?.Succeeded != true || (request.MaxAge != null && result.Properties?.IssuedUtc != null &&
                DateTimeOffset.UtcNow - result.Properties.IssuedUtc > TimeSpan.FromSeconds(request.MaxAge.Value)))
            {
                // If the client application requested promptless authentication,
                // return an error indicating that the user is not logged in.
                if (request.HasPromptValue(PromptValues.None))
                {
                    return this.Forbid(
                        properties: new AuthenticationProperties(new Dictionary<string, string>
                        {
                            [OpenIddictServerAspNetCoreConstants.Properties.Error] = Errors.LoginRequired,
                            [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] = "The user is not logged in."
                        }),
                        authenticationSchemes: OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
                }

                return this.Challenge(
                    properties: new AuthenticationProperties
                    {
                        RedirectUri = this.Request.PathBase + this.Request.Path + QueryString.Create(
                            this.Request.HasFormContentType ? this.Request.Form.ToList() : this.Request.Query.ToList())
                    },
                    authenticationSchemes: IdentityConstants.ApplicationScheme);
            }

            // Retrieve the profile of the logged in user.
            var user = await this.userManager.GetUserAsync(result.Principal) ??
                throw new InvalidOperationException("The user details cannot be retrieved.");

            // Retrieve the application details from the database.
            var application = await this.applicationManager.FindByClientIdAsync(request.ClientId) ??
                throw new InvalidOperationException("Details concerning the calling client application cannot be found.");

            // Retrieve the permanent authorizations associated with the user and the calling client application.
            var authorizations = await this.authorizationManager.FindAsync(
                subject: await this.userManager.GetUserIdAsync(user),
                client: await this.applicationManager.GetIdAsync(application),
                status: Statuses.Valid,
                type: AuthorizationTypes.Permanent,
                scopes: request.GetScopes()).ToListAsync();

            switch (await this.applicationManager.GetConsentTypeAsync(application))
            {
                // If the consent is external (e.g when authorizations are granted by a sysadmin),
                // immediately return an error if no authorization can be found in the database.
                case ConsentTypes.External when !authorizations.Any():
                    return this.Forbid(
                        properties: new AuthenticationProperties(new Dictionary<string, string>
                        {
                            [OpenIddictServerAspNetCoreConstants.Properties.Error] = Errors.ConsentRequired,
                            [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] =
                                "The logged in user is not allowed to access this client application."
                        }),
                        authenticationSchemes: OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

                // If the consent is implicit or if an authorization was found,
                // return an authorization response without displaying the consent form.
                case ConsentTypes.Implicit:
                case ConsentTypes.External when authorizations.Count > 0:
                case ConsentTypes.Explicit when authorizations.Count > 0 && !request.HasPromptValue(PromptValues.Consent):
                    var principal = await this.signInManager.CreateUserPrincipalAsync(user);

                    // Note: in this sample, the granted scopes match the requested scope
                    // but you may want to allow the user to uncheck specific scopes.
                    // For that, simply restrict the list of scopes before calling SetScopes.
                    principal.SetScopes(request.GetScopes());
                    principal.SetResources(await this.scopeManager.ListResourcesAsync(principal.GetScopes()).ToListAsync());

                    // Automatically create a permanent authorization to avoid requiring explicit consent
                    // for future authorization or token requests containing the same scopes.
                    var authorization = authorizations.LastOrDefault()
                        ?? await this.authorizationManager.CreateAsync(
                            principal: principal,
                            subject: await this.userManager.GetUserIdAsync(user),
                            client: await this.applicationManager.GetIdAsync(application),
                            type: AuthorizationTypes.Permanent,
                            scopes: principal.GetScopes());

                    principal.SetAuthorizationId(await this.authorizationManager.GetIdAsync(authorization));

                    foreach (var claim in principal.Claims)
                    {
                        claim.SetDestinations(GetDestinations(claim, principal));
                    }

                    return this.SignIn(principal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

                // At this point, no authorization was found in the database and an error must be returned
                // if the client application specified prompt=none in the authorization request.
                case ConsentTypes.Explicit when request.HasPromptValue(PromptValues.None):
                case ConsentTypes.Systematic when request.HasPromptValue(PromptValues.None):
                    return this.Forbid(
                        properties: new AuthenticationProperties(new Dictionary<string, string>
                        {
                            [OpenIddictServerAspNetCoreConstants.Properties.Error] = Errors.ConsentRequired,
                            [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] =
                                "Interactive user consent is required."
                        }),
                        authenticationSchemes: OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

                // In every other case, render the consent form.
                default:
                    return this.View(new AuthorizeViewModel
                    {
                        ApplicationName = await this.applicationManager.GetDisplayNameAsync(application),
                        Scope = request.Scope
                    });
            }
        }

        [Authorize, FormValueRequired("submit.Deny")]
        [HttpPost("~/connect/authorize"), ValidateAntiForgeryToken]
        // Notify OpenIddict that the authorization grant has been denied by the resource owner
        // to redirect the user agent to the client application using the appropriate response_mode.
        public IActionResult Deny() => this.Forbid(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

        [HttpPost("~/connect/token"), Produces("application/json")]
        public async Task<IActionResult> Exchange()
        {
            var request = this.HttpContext.GetOpenIddictServerRequest() ??
                throw new InvalidOperationException("The OpenID Connect request cannot be retrieved.");

            if (request.IsAuthorizationCodeGrantType() || request.IsRefreshTokenGrantType())
            {
                // Retrieve the claims principal stored in the authorization code/device code/refresh token.
                var principal = (await this.HttpContext.AuthenticateAsync(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme)).Principal;

                // Retrieve the user profile corresponding to the authorization code/refresh token.
                // Note: if you want to automatically invalidate the authorization code/refresh token
                // when the user password/roles change, use the following line instead:
                // var user = _signInManager.ValidateSecurityStampAsync(info.Principal);
                var user = await this.userManager.GetUserAsync(principal);
                if (user == null)
                {
                    return this.Forbid(
                        properties: new AuthenticationProperties(new Dictionary<string, string>
                        {
                            [OpenIddictServerAspNetCoreConstants.Properties.Error] = Errors.InvalidGrant,
                            [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] = "The token is no longer valid."
                        }),
                        authenticationSchemes: OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
                }

                // Ensure the user is still allowed to sign in.
                if (!await this.signInManager.CanSignInAsync(user))
                {
                    return this.Forbid(
                        properties: new AuthenticationProperties(new Dictionary<string, string>
                        {
                            [OpenIddictServerAspNetCoreConstants.Properties.Error] = Errors.InvalidGrant,
                            [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] = "The user is no longer allowed to sign in."
                        }),
                        authenticationSchemes: OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
                }

                foreach (var claim in principal.Claims)
                {
                    claim.SetDestinations(GetDestinations(claim, principal));
                }

                // Returning a SignInResult will ask OpenIddict to issue the appropriate access/identity tokens.
                return this.SignIn(principal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            }

            throw new InvalidOperationException("The specified grant type is not supported.");
        }

        [HttpGet("~/connect/logout")]
        public IActionResult Logout() => this.View();

        [ActionName(nameof(Logout)), HttpPost("~/connect/logout"), ValidateAntiForgeryToken]

        public async Task<IActionResult> LogoutPost()
        {
            // Ask ASP.NET Core Identity to delete the local and external cookies created
            // when the user agent is redirected from the external identity provider
            // after a successful authentication flow (e.g Google or Facebook).
            await this.signInManager.SignOutAsync();

            // Returning a SignOutResult will ask OpenIddict to redirect the user agent
            // to the post_logout_redirect_uri specified by the client application or to
            // the RedirectUri specified in the authentication properties if none was set.
            return this.SignOut(
                properties: new AuthenticationProperties
                {
                    RedirectUri = "/"
                },
                authenticationSchemes: OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }

        private static IEnumerable<string> GetDestinations(Claim claim, ClaimsPrincipal principal)
        {
            // Note: by default, claims are NOT automatically included in the access and identity tokens.
            // To allow OpenIddict to serialize them, you must attach them a destination, that specifies
            // whether they should be included in access tokens, in identity tokens or in both.

            switch (claim.Type)
            {
                case Claims.Name:
                    yield return Destinations.AccessToken;

                    if (principal.HasScope(Scopes.Profile))
                        yield return Destinations.IdentityToken;

                    yield break;

                case Claims.Email:
                    yield return Destinations.AccessToken;

                    if (principal.HasScope(Scopes.Email))
                        yield return Destinations.IdentityToken;

                    yield break;

                case Claims.Role:
                    yield return Destinations.AccessToken;

                    if (principal.HasScope(Scopes.Roles))
                        yield return Destinations.IdentityToken;

                    yield break;

                // Never include the security stamp in the access and identity tokens, as it's a secret value.
                case "AspNet.Identity.SecurityStamp": yield break;

                default:
                    yield return Destinations.AccessToken;
                    yield break;
            }
        }
    }
}