namespace PlanningPoker.Identity.Extensions
{
    using Ardalis.GuardClauses;

    using Identity.Extensions;
    using Identity.Workers;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.ResponseCompression;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Persistence;
    using Persistence.Entities;
    using Persistence.Extensions;

    using PlanningPoker.Identity.Models.Options;

    using Quartz;

    using SharedKernel.Models.Configuration;

    using System.Collections.Generic;
    using System.Net.Mime;

    using static OpenIddict.Abstractions.OpenIddictConstants;

    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services)
        {
            Guard.Against.Null(services, nameof(services));

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<PlanningPokerDbContext>()
                .AddDefaultTokenProviders()
                .AddDefaultUI();

            return services;
        }

        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            Guard.Against.Null(services, nameof(services));
            Guard.Against.Null(configuration, nameof(configuration));

            services.Configure<PlanningPokerOptions>(configuration);
            services.Configure<ClientMetadata>("Blazor", configuration.GetSection("Applications:Blazor"));
            services.Configure<ClientMetadata>("Api", configuration.GetSection("Applications:Api"));
            services.AddPersistanceServices();
            services.AddIdentityConfiguration();
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddResponseCompression(opts =>
                opts.MimeTypes = new List<string>(ResponseCompressionDefaults.MimeTypes)
                {
                    MediaTypeNames.Application.Octet
                }
            );

            services.AddQuartz();
            services.AddOpenIdDict();
            services.AddIdentityOptions();
            services.AddAuthentication();
            services.AddAuthorization();
            services.AddHostedService<ApplicationRegistrator>();

            return services;
        }

        public static IServiceCollection AddIdentityOptions(this IServiceCollection services)
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

                options.User.RequireUniqueEmail = true;
            });

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
                               .SetEndSessionEndpointUris("/connect/logout")
                               .SetIntrospectionEndpointUris("/connect/introspect")
                               .SetTokenEndpointUris("/connect/token")
                               .SetUserInfoEndpointUris("/connect/userinfo")
                               .SetEndUserVerificationEndpointUris("/connect/verify");

                    // Mark the "email", "profile" and "roles" scopes as supported scopes.
                    options.RegisterScopes(Scopes.Email, Scopes.Profile, Scopes.Roles);

                    // Note: this sample only uses the authorization code flow but you can enable
                    // the other flows if you need to support implicit, password or client credentials.
                    options.AllowAuthorizationCodeFlow();

                    // Register the signing and encryption credentials.
                    options.AddDevelopmentEncryptionCertificate().AddDevelopmentSigningCertificate();

                    // Register the ASP.NET Core host and configure the ASP.NET Core-specific options.
                    options.UseAspNetCore()
                            .EnableEndSessionEndpointPassthrough()
                            .EnableAuthorizationEndpointPassthrough()
                            .EnableTokenEndpointPassthrough()
                            .EnableUserInfoEndpointPassthrough()
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
                options.UseSimpleTypeLoader();
                options.UseInMemoryStore();
            });

            // Register the Quartz.NET service and configure it to block shutdown until jobs are complete.
            services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);

            return services;
        }
    }
}
