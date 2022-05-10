namespace PlanningPoker.Identity.Workers
{
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Hosting;

	using OpenIddict.Abstractions;

	using System;
	using System.Threading;
	using System.Threading.Tasks;

	using static OpenIddict.Abstractions.OpenIddictConstants;

	public class ApplicationRegistrator : IHostedService
	{
		private readonly IServiceProvider serviceProvider;

		public ApplicationRegistrator(IServiceProvider serviceProvider)
			=> this.serviceProvider = serviceProvider;

		public async Task StartAsync(CancellationToken cancellationToken)
		{
			using var scope = this.serviceProvider.CreateScope();

			await RegisterApplicationsAsync(scope.ServiceProvider);
			//await RegisterScopesAsync(scope.ServiceProvider);
		}

		public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

		private static async Task RegisterApplicationsAsync(IServiceProvider provider)
		{
			var manager = provider.GetRequiredService<IOpenIddictApplicationManager>();

			if (await manager.FindByClientIdAsync("376f1a49-e253-4b77-b5be-b52a8fff8446") is null)
			{
				await manager.CreateAsync(new OpenIddictApplicationDescriptor
				{
					ClientId = "376f1a49-e253-4b77-b5be-b52a8fff8446",
					ConsentType = ConsentTypes.Explicit,
					DisplayName = "Blazor code PKCE",
					PostLogoutRedirectUris =
						{
							new Uri("https://localhost:5002/signout-callback-oidc")
						},
					RedirectUris =
						{
							new Uri("https://localhost:5002/signin-oidc")
						},
					ClientSecret = "74f009d6-4600-4985-9027-c23fd047ffd5",
					Permissions =
						{
							Permissions.Endpoints.Authorization,
							Permissions.Endpoints.Logout,
							Permissions.Endpoints.Token,
							Permissions.GrantTypes.AuthorizationCode,
							Permissions.ResponseTypes.Code,
							Permissions.Scopes.Email,
							Permissions.Scopes.Profile,
							Permissions.Scopes.Roles
							//Permissions.Prefixes.Scope + "api1"
						},
					Requirements =
						{
							Requirements.Features.ProofKeyForCodeExchange
						}
				});
			}
		}
	}
}
