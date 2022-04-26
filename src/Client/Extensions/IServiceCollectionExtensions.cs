using System.Text.Json;

using Ardalis.GuardClauses;

using Blazored.LocalStorage;

using FluentValidation;

using Microsoft.Extensions.DependencyInjection;

using PlanningPoker.Client.Services;
using PlanningPoker.SharedKernel.Models.Tables;

using Radzen;

namespace PlanningPoker.Client.Extensions
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Registers dependencies for the Blazor Client Application.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>An instance of <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddClientLayer(this IServiceCollection services)
        {
            Guard.Against.Null(services, nameof(services));

            services.AddScoped<DialogService>();
            services.AddScoped<NotificationService>();
            services.AddScoped<TooltipService>();
            services.AddScoped<ContextMenuService>();
            services.AddScoped<IPlayerService, PlayerService>();

            services.AddValidatorsFromAssemblyContaining<TableMetadataValidator>();

            services.AddBlazoredLocalStorage(config =>
            {
                config.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                config.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                config.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                config.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
                config.JsonSerializerOptions.WriteIndented = false;
            });
            
            //services.Configure<OidcConfiguration>(configuration);

            services.AddOidcAuthentication(options =>
            {
                options.ProviderOptions.ClientId = "balosar-blazor-client";
                options.ProviderOptions.Authority = "https://localhost:44310/";
                options.ProviderOptions.ResponseType = "code";

                // Note: response_mode=fragment is the best option for a SPA. Unfortunately, the Blazor WASM
                // authentication stack is impacted by a bug that prevents it from correctly extracting
                // authorization error responses (e.g error=access_denied responses) from the URL fragment.
                // For more information about this bug, visit https://github.com/dotnet/aspnetcore/issues/28344.
                //
                options.ProviderOptions.ResponseMode = "query";
                options.AuthenticationPaths.RemoteRegisterPath = "https://localhost:44310/Identity/Account/Register";

                // Add the "roles" (OpenIddictConstants.Scopes.Roles) scope and the "role" (OpenIddictConstants.Claims.Role) claim
                // (the same ones used in the Startup class of the Server) in order for the roles to be validated.
                // See the Counter component for an example of how to use the Authorize attribute with roles
                options.ProviderOptions.DefaultScopes.Add("roles");
                options.UserOptions.RoleClaim = "role";
            });

            return services;
        }
    }
}
