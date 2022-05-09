using Ardalis.GuardClauses;
using Blazored.LocalStorage;
using FluentValidation;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PlanningPoker.Client.Authorization;
using PlanningPoker.Client.Services;
using PlanningPoker.SharedKernel.Models.Tables;
using Radzen;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;

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

			services.AddOptions();
			services.AddAuthorizationCore();
			services.AddScoped<DialogService>();
			services.AddScoped<NotificationService>();
			services.AddScoped<TooltipService>();
			services.AddScoped<ContextMenuService>();
			services.AddScoped<IPlayerService, PlayerService>();
			services.TryAddSingleton<AuthenticationStateProvider, HostAuthenticationStateProvider>();
			services.TryAddSingleton(sp => (HostAuthenticationStateProvider)sp.GetRequiredService<AuthenticationStateProvider>());
			services.AddTransient<AuthorizedHandler>();
			services.AddValidatorsFromAssemblyContaining<TableMetadataValidator>();

			services.AddBlazoredLocalStorage();

			services.AddHttpClient("default", client =>
			{
				client.BaseAddress = new Uri(environment.BaseAddress);
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
			});

			services.AddHttpClient("authorizedClient", client =>
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
