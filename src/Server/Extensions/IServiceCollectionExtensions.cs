using System.Collections.Generic;
using System.Net.Mime;

using Ardalis.GuardClauses;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using PlanningPoker.Persistence;
using PlanningPoker.SharedKernel.Models.Configuration;

using Quartz;

using static OpenIddict.Abstractions.OpenIddictConstants;

namespace PlanningPoker.Server.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            Guard.Against.Null(services, nameof(services));
            Guard.Against.Null(configuration, nameof(configuration));

            services.Configure<PlanningPokerOptions>(configuration);
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSignalR();

            services.AddResponseCompression(opts =>
                opts.MimeTypes = new List<string>(ResponseCompressionDefaults.MimeTypes)
                {
                    MediaTypeNames.Application.Octet
                }
            );

            services.AddQuartz();
            services.AddOpenIdDict();
            services.AddJwtClaims();
            services.AddAuthentication();
            services.AddAuthorization();

            return services;
        }

        public static IServiceCollection AddOpenIdDict(this IServiceCollection services)
        {
            Guard.Against.Null(services, nameof(services));

            services
                .AddOpenIddict()
                .AddCore(options =>
                {
                    // Configure OpenIddict to use the Entity Framework Core stores and models.
                    // Note: call ReplaceDefaultEntities() to replace the default OpenIddict entities.
                    options.UseEntityFrameworkCore().UseDbContext<PlanningPokerDbContext>();

                    // Enable Quartz.NET integration.
                    options.UseQuartz();
                })

                // Register the OpenIddict server components.
                .AddServer(options =>
                {
                    // Enable the authorization, logout, token and userinfo endpoints.
                    options.SetAuthorizationEndpointUris("/connect/authorize")
                               .SetLogoutEndpointUris("/connect/logout")
                               .SetIntrospectionEndpointUris("/connect/introspect")
                               .SetTokenEndpointUris("/connect/token")
                               .SetUserinfoEndpointUris("/connect/userinfo")
                               .SetVerificationEndpointUris("/connect/verify");

                    // Mark the "email", "profile" and "roles" scopes as supported scopes.
                    options.RegisterScopes(Scopes.Email, Scopes.Profile, Scopes.Roles);

                    // Note: this sample only uses the authorization code flow but you can enable
                    // the other flows if you need to support implicit, password or client credentials.
                    options.AllowAuthorizationCodeFlow();

                    // Register the signing and encryption credentials.
                    options.AddDevelopmentEncryptionCertificate().AddDevelopmentSigningCertificate();

                    // Register the ASP.NET Core host and configure the ASP.NET Core-specific options.
                    options.UseAspNetCore()
                            .EnableAuthorizationEndpointPassthrough()
                            .EnableLogoutEndpointPassthrough()
                            .EnableTokenEndpointPassthrough()
                            .EnableUserinfoEndpointPassthrough()
                            .EnableStatusCodePagesIntegration();
                })

                // Register the OpenIddict validation components.
                .AddValidation(options =>
                {
                    // Import the configuration from the local OpenIddict server instance.
                    options.UseLocalServer();

                    // Register the ASP.NET Core host.
                    options.UseAspNetCore();
                });

            return services;
        }

        public static IServiceCollection AddQuartz(this IServiceCollection services)
        {
            Guard.Against.Null(services, nameof(services));

            services.AddQuartz(options =>
            {
                options.UseMicrosoftDependencyInjectionJobFactory();
                options.UseSimpleTypeLoader();
                options.UseInMemoryStore();
            });

            // Register the Quartz.NET service and configure it to block shutdown until jobs are complete.
            services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);

            return services;
        }

        public static IServiceCollection AddJwtClaims(this IServiceCollection services)
        {
            Guard.Against.Null(services, nameof(services));

            // Configure Identity to use the same JWT claims as OpenIddict instead
            // of the legacy WS-Federation claims it uses by default (ClaimTypes),
            // which saves you from doing the mapping in your authorization controller.
            services.Configure<IdentityOptions>(options =>
            {
                options.ClaimsIdentity.UserNameClaimType = Claims.Name;
                options.ClaimsIdentity.UserIdClaimType = Claims.Subject;
                options.ClaimsIdentity.RoleClaimType = Claims.Role;
                options.ClaimsIdentity.EmailClaimType = Claims.Email;

                // Note: to require account confirmation before login,
                // register an email sender service (IEmailSender) and
                // set options.SignIn.RequireConfirmedAccount to true.
                //
                // For more information, visit https://aka.ms/aspaccountconf.
                options.SignIn.RequireConfirmedAccount = false;
            });

            return services;
        }

        public static IServiceCollection AddAuthentication(this IServiceCollection services)
        {
            Guard.Against.Null(services, nameof(services));

            using var serviceProvider = services.BuildServiceProvider();
            var oidcConfiguration = serviceProvider.GetService<IOptions<OidcConfiguration>>()?.Value;
            Guard.Against.Null(oidcConfiguration, nameof(oidcConfiguration));

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
           .AddCookie()
           .AddOpenIdConnect(options =>
           {
               options.SignInScheme = oidcConfiguration.SignInScheme;
               options.Authority = oidcConfiguration.Authority;
               options.ClientId = oidcConfiguration.ClientId;
               options.ClientSecret = oidcConfiguration.ClientSecret;
               options.RequireHttpsMetadata = oidcConfiguration.RequireHttpsMetadata;
               options.ResponseType = oidcConfiguration.ResponseType;

               foreach (var scope in oidcConfiguration.Scopes)
               {
                   options.Scope.Add(scope);
               }

               options.SaveTokens = oidcConfiguration.SaveTokens;
               options.GetClaimsFromUserInfoEndpoint = oidcConfiguration.GetClaimsFromUserInfoEndpoint;
           });

            return services;
        }

        public static IServiceCollection AddAuthorization(this IServiceCollection services)
        {
            Guard.Against.Null(services, nameof(services));

            // Create an authorization policy used by YARP when forwarding requests
            services.AddAuthorization(options => options.AddPolicy("CookieAuthenticationPolicy", builder =>
            {
                builder.AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme);
                builder.RequireAuthenticatedUser();
            }));

            return services;
        }
    }
}
