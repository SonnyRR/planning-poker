namespace PlanningPoker.Identity.Workers
{
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Hosting;
	using Microsoft.Extensions.Options;

	using OpenIddict.Abstractions;

	using PlanningPoker.Identity.Models.Options;

	using System;
	using System.Linq;
	using System.Threading;
	using System.Threading.Tasks;

	using static OpenIddict.Abstractions.OpenIddictConstants;

	public class ApplicationRegistrator : IHostedService
	{
		private readonly IServiceProvider serviceProvider;
		private ClientMetadata apiClientOptions;
		private IOpenIddictApplicationManager applicationManager;
		private ClientMetadata blazorClientOptions;
		private IOpenIddictScopeManager scopeManager;

		public ApplicationRegistrator(IServiceProvider serviceProvider)
		{
			this.serviceProvider = serviceProvider;
		}

		public async Task StartAsync(CancellationToken cancellationToken)
		{
			using var scope = this.serviceProvider.CreateScope();

			this.applicationManager = scope.ServiceProvider.GetRequiredService<IOpenIddictApplicationManager>();
			this.scopeManager = scope.ServiceProvider.GetRequiredService<IOpenIddictScopeManager>();

			var clientMetadataOptions = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<ClientMetadata>>();
			this.blazorClientOptions = clientMetadataOptions.Get("Blazor");
			this.apiClientOptions = clientMetadataOptions.Get("Api");

			await this.RegisterApplicationsAsync();
			await this.RegisterScopesAsync();
		}

		public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

		private async Task RegisterApplicationsAsync()
		{
			if (await this.applicationManager.FindByClientIdAsync(this.blazorClientOptions.ClientId) is null)
			{
				var descriptor = new OpenIddictApplicationDescriptor
				{
					ClientId = this.blazorClientOptions.ClientId,
					ConsentType = ConsentTypes.Explicit,
					DisplayName = this.blazorClientOptions.DisplayName,
					ClientSecret = this.blazorClientOptions.ClientSecret,
					Permissions =
					{
						Permissions.Endpoints.Authorization,
						Permissions.Endpoints.Logout,
						Permissions.Endpoints.Token,
						Permissions.GrantTypes.AuthorizationCode,
						Permissions.ResponseTypes.Code,
						Permissions.Scopes.Email,
						Permissions.Scopes.Profile,
						Permissions.Scopes.Roles,
						Permissions.Prefixes.Scope + this.apiClientOptions.Name
					},
					Requirements =
					{
						Requirements.Features.ProofKeyForCodeExchange
					}
				};

				foreach (var uri in this.blazorClientOptions.PostLogoutRedirectUris.Select(a => new Uri(a)))
				{
					descriptor.PostLogoutRedirectUris.Add(uri);
				}

				foreach (var uri in this.blazorClientOptions.RedirectUris.Select(a => new Uri(a)))
				{
					descriptor.RedirectUris.Add(uri);
				}

				await this.applicationManager.CreateAsync(descriptor);
			}

			if (await this.applicationManager.FindByClientIdAsync(this.apiClientOptions.ClientId) is null)
			{
				var descriptor = new OpenIddictApplicationDescriptor
				{
					ClientId = this.apiClientOptions.ClientId,
					ClientSecret = this.apiClientOptions.ClientSecret,
					Permissions =
					{
						Permissions.Endpoints.Introspection
					}
				};

				await this.applicationManager.CreateAsync(descriptor);
			}
		}

		private async Task RegisterScopesAsync()
		{
			if (await this.scopeManager.FindByNameAsync(this.apiClientOptions.Name) is null)
			{
				await this.scopeManager.CreateAsync(new OpenIddictScopeDescriptor
				{
					DisplayName = this.apiClientOptions.DisplayName,
					Name = this.apiClientOptions.Name,
					Resources =
					{
						this.apiClientOptions.ClientId
					}
				});
			}
		}
	}
}
