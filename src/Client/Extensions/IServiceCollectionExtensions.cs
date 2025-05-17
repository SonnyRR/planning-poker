namespace PlanningPoker.Client.Extensions
{
    using Ardalis.GuardClauses;

    using Authorization;

    using Blazored.LocalStorage;

    using FluentValidation;
    using Fluxor;
    using Fluxor.Blazor.Web.ReduxDevTools;
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using PlanningPoker.Client.Clients;
    using PlanningPoker.SharedKernel;
    using PlanningPoker.SharedKernel.Models.Binding;
    using Radzen;

    using Services;

    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Net.Mime;
    using System.Text.Json;
    using static Constants;

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

            services.AddOptions();
            services.AddAuthorizationCore();
            services.AddScoped<DialogService>();
            services.AddScoped<NotificationService>();
            services.AddScoped<TooltipService>();
            services.AddScoped<ContextMenuService>();
            services.AddScoped<ITableService, TableService>();
            services.AddScoped<IRoundService, RoundService>();
            services.TryAddSingleton<AuthenticationStateProvider, HostAuthenticationStateProvider>();
            services.TryAddSingleton(sp => (HostAuthenticationStateProvider)sp.GetRequiredService<AuthenticationStateProvider>());
            services.AddTransient<AuthorizedHandler>();
            services.AddValidatorsFromAssemblyContaining<TableBindingModelValidator>();

            services.AddBlazoredLocalStorage(config =>
            {
                config.JsonSerializerOptions = JsonSerializerConfigurations.LocalStorageSettings;
            });

            services.AddHttpClient(Http.UNAUTHORIZED_CLIENT_ID, client =>
            {
                client.BaseAddress = new Uri(environment.BaseAddress);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
            });

            services.AddHttpClient(Http.AUTHORIZED_CLIENT_ID, client =>
            {
                client.BaseAddress = new Uri(environment.BaseAddress);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
            })
            .AddHttpMessageHandler<AuthorizedHandler>();

            services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("default"));
            services.AddFluxor(options =>
            {
                options.ScanAssemblies(typeof(Program).Assembly);

                if (environment.IsDevelopment())
                {
                    options.UseReduxDevTools(x =>
                    {
                        x.Name = "Planning Poker";
                        x.EnableStackTrace();
                    });
                }
            });

            services.AddScoped<IBlazorPokerClient, PokerHubClient>();
            services.AddSingleton(JsonSerializerConfigurations.Default);
            services.AddKeyedSingleton(nameof(JsonSerializerConfigurations.LoggingSettings), JsonSerializerConfigurations.LoggingSettings);

            services.AddRadzenComponents();

            return services;
        }
    }
}