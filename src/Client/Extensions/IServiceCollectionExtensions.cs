using System.Text.Json;

using Ardalis.GuardClauses;

using Blazored.LocalStorage;

using FluentValidation;

using Microsoft.Extensions.DependencyInjection;

using PlanningPoker.Client.Models;
using PlanningPoker.Client.Services;

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

            return services;
        }
    }
}
