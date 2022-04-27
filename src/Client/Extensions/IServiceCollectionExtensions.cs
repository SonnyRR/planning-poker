using System.Text.Json;

using Ardalis.GuardClauses;

using Blazored.LocalStorage;

using FluentValidation;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PlanningPoker.Client.Services;
using PlanningPoker.SharedKernel.Models.Tables;

using Radzen;
using PlanningPoker.Client.Authorization;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace PlanningPoker.Client.Extensions
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Registers dependencies for the Blazor Client Application.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>An instance of <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddClientLayer(this IServiceCollection services, IWebAssemblyHostEnvironment environment)
        {
            Guard.Against.Null(services, nameof(services));
            Guard.Against.Null(environment, nameof(environment));

            services.AddScoped<DialogService>();
            services.AddScoped<NotificationService>();
            services.AddScoped<TooltipService>();
            services.AddScoped<ContextMenuService>();
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddOptions();
            services.AddAuthorizationCore();
            services.TryAddSingleton<AuthenticationStateProvider, HostAuthenticationStateProvider>();
            services.TryAddSingleton(sp => (HostAuthenticationStateProvider)sp.GetRequiredService<AuthenticationStateProvider>());
            services.AddTransient<AuthorizedHandler>();
            services.AddValidatorsFromAssemblyContaining<TableMetadataValidator>();

            services.AddBlazoredLocalStorage(config =>
            {
                config.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                config.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                config.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                config.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
                config.JsonSerializerOptions.WriteIndented = false;
            });


            services.AddHttpClient("default", client =>
            {
                client.BaseAddress = new Uri(environment.BaseAddress);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            services.AddHttpClient("authorizedClient", client =>
            {
                client.BaseAddress = new Uri(environment.BaseAddress);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }).AddHttpMessageHandler<AuthorizedHandler>();

            services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("default"));

            return services;
        }
    }
}
