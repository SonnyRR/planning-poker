using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Mime;

using Ardalis.GuardClauses;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using PlanningPoker.BFF.Extensions;
using PlanningPoker.SharedKernel.Models.Configuration;

using Yarp.ReverseProxy.Transforms;

namespace PlanningPoker.BFF.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            Guard.Against.Null(services, nameof(services));
            Guard.Against.Null(configuration, nameof(configuration));

            services.Configure<PlanningPokerOptions>(configuration);
            services.AddControllersWithViews(options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));
            services.AddRazorPages();
            services.AddSignalR();
            services.AddHttpClient();
            services.AddOptions();

            services.AddResponseCompression(opts =>
                opts.MimeTypes = new List<string>(ResponseCompressionDefaults.MimeTypes)
                {
                    MediaTypeNames.Application.Octet
                }
            );

            services.AddAntiforgery();
            services.AddReverseProxyConfig(configuration);
            services.AddAuthentication();
            services.AddAuthorization();

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

        public static IServiceCollection AddAntiforgery(this IServiceCollection services)
        {
            Guard.Against.Null(services, nameof(services));

            services.AddAntiforgery(options =>
            {
                options.HeaderName = "X-XSRF-TOKEN";
                options.Cookie.Name = "__Host-X-XSRF-TOKEN";
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            });

            return services;
        }

        public static IServiceCollection AddReverseProxyConfig(this IServiceCollection services, IConfiguration configuration)
        {
            Guard.Against.Null(services, nameof(services));
            Guard.Against.Null(configuration, nameof(configuration));

            services.AddReverseProxy()
                .LoadFromConfig(configuration.GetSection("ReverseProxy"))
                .AddTransforms(builder => builder.AddRequestTransform(async context =>
                {
                    // Attach the access token retrieved from the authentication cookie.
                    //
                    // Note: in a real world application, the expiration date of the access token
                    // should be checked before sending a request to avoid getting a 401 response.
                    // Once expired, a new access token could be retrieved using the OAuth 2.0
                    // refresh token grant (which could be done transparently).
                    var token = await context.HttpContext.GetTokenAsync("access_token");

                    context.ProxyRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }));

            return services;
        }
    }
}
