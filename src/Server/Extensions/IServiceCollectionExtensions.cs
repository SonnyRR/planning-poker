using System.Collections.Generic;
using System.Net.Mime;

using Ardalis.GuardClauses;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;

using Quartz;

using static OpenIddict.Abstractions.OpenIddictConstants;

namespace PlanningPoker.Server.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            Guard.Against.Null(services, nameof(services));

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSignalR();
            services.AddResponseCompression(opts =>
                opts.MimeTypes = new List<string>(ResponseCompressionDefaults.MimeTypes)
                {
                    MediaTypeNames.Application.Octet
                });

            services.AddQuartz();
            services.AddOpenIdDict();
            services.AddJwtClaims();

            return services;
        }

        public static IServiceCollection AddOpenIdDict(this IServiceCollection services)
        {
            Guard.Against.Null(services, nameof(services));

            services.AddOpenIddict()
                // Register the OpenIddict core components.
                .AddCore(options =>
                {
                    // Configure OpenIddict to use the Entity Framework Core stores and models.
                    // Note: call ReplaceDefaultEntities() to replace the default OpenIddict entities.

                    //options.UseEntityFrameworkCore()
                    //       .UseDbContext<ApplicationDbContext>();

                    // Enable Quartz.NET integration.
                    options.UseQuartz();
                })
                // Register the OpenIddict server components.
                .AddServer(options =>
                {
                    // Enable the authorization, logout, token and userinfo endpoints.
                    options.SetAuthorizationEndpointUris("/connect/authorize")
                   .SetLogoutEndpointUris("/connect/logout")
                   .SetTokenEndpointUris("/connect/token")
                   .SetUserinfoEndpointUris("/connect/userinfo");

                    // Mark the "email", "profile" and "roles" scopes as supported scopes.
                    options.RegisterScopes(Scopes.Email, Scopes.Profile, Scopes.Roles);

                    // Note: the sample uses the code and refresh token flows but you can enable
                    // the other flows if you need to support implicit, password or client credentials.
                    options.AllowAuthorizationCodeFlow()
                   .AllowRefreshTokenFlow();

                    // Register the signing and encryption credentials.
                    options.AddDevelopmentEncryptionCertificate()
                   .AddDevelopmentSigningCertificate();

                    // Register the ASP.NET Core host and configure the ASP.NET Core-specific options.
                    options.UseAspNetCore()
                   .EnableAuthorizationEndpointPassthrough()
                   .EnableLogoutEndpointPassthrough()
                   .EnableStatusCodePagesIntegration()
                   .EnableTokenEndpointPassthrough();
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
            });

            return services;
        }
    }
}
