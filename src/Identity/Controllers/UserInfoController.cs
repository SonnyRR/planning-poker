namespace PlanningPoker.Identity.Controllers
{
	using Microsoft.AspNetCore.Authentication;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;

	using OpenIddict.Abstractions;
	using OpenIddict.Server.AspNetCore;

	using PlanningPoker.Persistence.Entities;

	using System;
	using System.Collections.Generic;
	using System.Net.Mime;
	using System.Threading.Tasks;

	using static OpenIddict.Abstractions.OpenIddictConstants;

	public class UserInfoController : Controller
	{
		private readonly UserManager<User> userManager;

		public UserInfoController(UserManager<User> userManager)
		{
			this.userManager = userManager;
		}

		[Authorize(AuthenticationSchemes = OpenIddictServerAspNetCoreDefaults.AuthenticationScheme)]
		[HttpGet("~/connect/userinfo"), HttpPost("~/connect/userinfo"), Produces(MediaTypeNames.Application.Json)]
		public async Task<IActionResult> Userinfo()
		{
			var user = await this.userManager.GetUserAsync(this.User);
			if (user == null)
			{
				return this.Challenge(
					properties: new AuthenticationProperties(new Dictionary<string, string?>
					{
						[OpenIddictServerAspNetCoreConstants.Properties.Error] = Errors.InvalidToken,
						[OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] =
							"The specified access token is bound to an account that no longer exists."
					}),
					authenticationSchemes: OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
			}

			var claims = new Dictionary<string, object>(StringComparer.Ordinal)
			{
				// Note: the "sub" claim is a mandatory claim and must be included in the JSON response.
				[Claims.Subject] = await this.userManager.GetUserIdAsync(user)
			};

			if (this.User.HasScope(Scopes.Email))
			{
				claims[Claims.Email] = await this.userManager.GetEmailAsync(user);
				claims[Claims.EmailVerified] = await this.userManager.IsEmailConfirmedAsync(user);
			}

			if (this.User.HasScope(Scopes.Phone))
			{
				claims[Claims.PhoneNumber] = await this.userManager.GetPhoneNumberAsync(user);
				claims[Claims.PhoneNumberVerified] = await this.userManager.IsPhoneNumberConfirmedAsync(user);
			}

			if (this.User.HasScope(Scopes.Roles))
			{
				claims[Claims.Role] = await this.userManager.GetRolesAsync(user);
			}

			// Note: the complete list of standard claims supported by the OpenID Connect specification
			// can be found here: http://openid.net/specs/openid-connect-core-1_0.html#StandardClaims

			return this.Ok(claims);
		}
	}
}
