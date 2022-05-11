namespace PlanningPoker.Client.Authorization
{
	using Microsoft.AspNetCore.Components;
	using Microsoft.AspNetCore.Components.Authorization;
	using Microsoft.Extensions.Logging;

	using SharedKernel.Models.Authorization;

	using System;
	using System.Net.Http;
	using System.Net.Http.Json;
	using System.Security.Claims;
	using System.Threading.Tasks;

	public class HostAuthenticationStateProvider : AuthenticationStateProvider
	{
		private static readonly TimeSpan userCacheRefreshInterval = TimeSpan.FromSeconds(60);

		private const string LOGIN_PATH = "api/Account/Login";

		private readonly NavigationManager navigation;
		private readonly HttpClient client;
		private readonly ILogger<HostAuthenticationStateProvider> logger;

		private DateTimeOffset userLastCheck = DateTimeOffset.FromUnixTimeSeconds(0);
		private ClaimsPrincipal cachedUser = new(new ClaimsIdentity());

		public HostAuthenticationStateProvider(NavigationManager navigation, HttpClient client, ILogger<HostAuthenticationStateProvider> logger)
		{
			this.navigation = navigation;
			this.client = client;
			this.logger = logger;
		}

		public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			return new AuthenticationState(await this.GetUser(useCache: true));
		}

		public void SignIn(string customReturnUrl = null)
		{
			var returnUrl = customReturnUrl != null ? this.navigation.ToAbsoluteUri(customReturnUrl).ToString() : null;
			var encodedReturnUrl = Uri.EscapeDataString(returnUrl ?? this.navigation.Uri);
			var logInUrl = this.navigation.ToAbsoluteUri($"{LOGIN_PATH}?returnUrl={encodedReturnUrl}");
			this.navigation.NavigateTo(logInUrl.ToString(), true);
		}

		private async ValueTask<ClaimsPrincipal> GetUser(bool useCache = false)
		{
			var now = DateTimeOffset.Now;
			if (useCache && now < this.userLastCheck + userCacheRefreshInterval)
			{
				this.logger.LogDebug("Taking user from cache");
				return this.cachedUser;
			}

			this.logger.LogDebug("Fetching user");
			this.cachedUser = await this.FetchUser();
			this.userLastCheck = now;

			return this.cachedUser;
		}

		private async Task<ClaimsPrincipal> FetchUser()
		{
			UserInfo user = null;

			try
			{
				this.logger.LogInformation("Attempting to fetch user from: '{0}' base url.", this.client.BaseAddress.ToString());
				user = await this.client.GetFromJsonAsync<UserInfo>("api/User");
			}
			catch (Exception exc)
			{
				this.logger.LogWarning(exc, "Fetching user failed.");
			}

			if (user?.IsAuthenticated != true)
			{
				return new ClaimsPrincipal(new ClaimsIdentity());
			}

			var identity = new ClaimsIdentity(
				nameof(HostAuthenticationStateProvider),
				user.NameClaimType,
				user.RoleClaimType);

			if (user.Claims != null)
			{
				foreach (var claim in user.Claims)
				{
					identity.AddClaim(new Claim(claim.Type, claim.Value));
				}
			}

			return new ClaimsPrincipal(identity);
		}
	}
}
