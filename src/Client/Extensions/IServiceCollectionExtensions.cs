namespace PlanningPoker.Client.Extensions
{
	using Ardalis.GuardClauses;

	using Authorization;

	using Blazored.LocalStorage;

	using FluentValidation;

	using Microsoft.AspNetCore.Components.Authorization;
	using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.DependencyInjection.Extensions;
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
			services.AddScoped<IPlayerService, PlayerService>();
			services.AddScoped<ITableService, TableService>();
			services.TryAddSingleton<AuthenticationStateProvider, HostAuthenticationStateProvider>();
			services.TryAddSingleton(sp => (HostAuthenticationStateProvider)sp.GetRequiredService<AuthenticationStateProvider>());
			services.AddTransient<AuthorizedHandler>();
			services.AddValidatorsFromAssemblyContaining<TableBindingModelValidator>();

			services.AddBlazoredLocalStorage(config =>
			{
				config.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
				config.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
				config.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
				config.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
				config.JsonSerializerOptions.WriteIndented = false;
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

			return services;
		}
	}
}
