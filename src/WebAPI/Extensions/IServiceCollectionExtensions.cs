namespace PlanningPoker.WebAPI.Extensions
{
    using Ardalis.GuardClauses;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.OpenApi;
    using Microsoft.AspNetCore.ResponseCompression;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using Microsoft.OpenApi;
    using OpenIddict.Validation.AspNetCore;
    using PlanningPoker.Core.Extensions;
    using PlanningPoker.Persistence.Extensions;
    using SharedKernel.Models.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Net.Mime;
    using System.Threading.Tasks;

    /// <summary>
    /// Contains extension methods for registering application services.
    /// </summary>
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds all API service configurations.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configuration">The web host configuration.</param>
        /// <returns>An instance of <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            Guard.Against.Null(services, nameof(services));
            Guard.Against.Null(configuration, nameof(configuration));

            services.Configure<PlanningPokerOptions>(configuration);
            services.AddOidcServices();
            services.AddControllers();
            services.AddResponseCompression(opts =>
                opts.MimeTypes = new List<string>(ResponseCompressionDefaults.MimeTypes)
                {
                    MediaTypeNames.Application.Octet
                }
            );

            services.AddOpenApi();
            services.AddSignalR();
            services.AddPersistanceServices();
            services.AddHttpContextAccessor();
            services.AddCoreServices();

            return services;
        }

        /// <summary>
        /// Adds OIDC configuration.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>An instance of <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddOidcServices(this IServiceCollection services)
        {
            Guard.Against.Null(services, nameof(services));

            using var serviceProvider = services.BuildServiceProvider();
            var oidcConfiguration = serviceProvider.GetService<IOptions<PlanningPokerOptions>>()?.Value?.OidcConfiguration;

            // Register the OpenIddict validation components.
            services.AddOpenIddict()
                .AddValidation(options =>
                {
                    // Note: the validation handler uses OpenID Connect discovery
                    // to retrieve the address of the introspection endpoint.
                    options.SetIssuer(oidcConfiguration.Authority);
                    options.AddAudiences(oidcConfiguration.ClientId);

                    // Configure the validation handler to use introspection and register the client
                    // credentials used when communicating with the remote introspection endpoint.
                    options.UseIntrospection().SetClientId(oidcConfiguration.ClientId).SetClientSecret(oidcConfiguration.ClientSecret);

                    // Register the System.Net.Http integration.
                    options.UseSystemNetHttp();

                    // Register the ASP.NET Core host.
                    options.UseAspNetCore();
                });

            services.AddAuthentication(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
            services.AddAuthorization();

            return services;
        }

        /// <summary>
        /// Adds OpenAPI configuration.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>An instance of <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddOpenApi(this IServiceCollection services)
        {
            Guard.Against.Null(services, nameof(services));

            OpenApiServiceCollectionExtensions.AddOpenApi(services);
            services.Configure<OpenApiOptions>(options =>
            {
#pragma warning disable S1075 // URIs should not be hardcoded
                options.OpenApiVersion = OpenApiSpecVersion.OpenApi3_0;
                options.AddDocumentTransformer((document, _, _) =>
                {
                    document.Info = new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Planning Poker API",
                        Description = "API for managing scrum poker tables.",
                        TermsOfService = new Uri("https://placeholder/terms"),
                        Contact = new OpenApiContact
                        {
                            Name = "Vasil Kotsev",
                            Url = new Uri("https://placeholder.vk")
                        },
                        License = new OpenApiLicense
                        {
                            Name = "MIT Licence",
                            Url = new Uri("https://github.com/SonnyRR/planning-poker/blob/master/LICENSE")
                        }
                    };
                    return Task.CompletedTask;
                });
#pragma warning restore S1075 // URIs should not be hardcoded
            });

            return services;
        }
    }
}
