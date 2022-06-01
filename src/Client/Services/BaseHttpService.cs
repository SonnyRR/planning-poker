namespace PlanningPoker.Client.Services
{
	using Ardalis.GuardClauses;
	using System;
	using System.Net.Http;
	using System.Text.Json;
	using System.Threading;
	using System.Threading.Tasks;

	public abstract class BaseHttpService
	{
		protected readonly HttpClient httpClient;
		protected readonly JsonSerializerOptions jsonSerializerOptions = new()
		{
			PropertyNameCaseInsensitive = true
		};

		protected BaseHttpService(IHttpClientFactory httpClientFactory, bool authorized = false)
		{
			Guard.Against.Null(httpClientFactory, nameof(httpClientFactory));

			this.httpClient = httpClientFactory.CreateClient("authorized");
		}

		protected async Task<TModel> GetAsync<TModel>(string? uri, CancellationToken ct = default)
		{
			var response = await this.httpClient.GetAsync(uri, ct);
			var content = await response.Content.ReadAsStreamAsync(ct);
			if (response.IsSuccessStatusCode)
			{
				return await JsonSerializer.DeserializeAsync<TModel>(content, this.jsonSerializerOptions, ct);
			}

			throw new ApplicationException();
		}
	}
}
