namespace PlanningPoker.Client.Services
{
    using Ardalis.GuardClauses;
    using PlanningPoker.SharedKernel;
    using System.Net.Http;
    using System.Net.Http.Json;

    using System.Net.Mime;
    using System.Text.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using static Constants;

    public abstract class BaseHttpService
    {
        protected readonly HttpClient httpClient;
        protected readonly JsonSerializerOptions JsonSerializerOptions = JsonSerializerConfigurations.Default;

        protected BaseHttpService(IHttpClientFactory httpClientFactory, bool authorized = false)
        {
            Guard.Against.Null(httpClientFactory, nameof(httpClientFactory));

            this.httpClient = httpClientFactory.CreateClient(authorized ? Http.AUTHORIZED_CLIENT_ID : Http.UNAUTHORIZED_CLIENT_ID);
        }

        protected async Task DeleteAsync(string uri, CancellationToken ct = default)
        {
            var response = await this.httpClient.DeleteAsync(uri, ct);
            response.EnsureSuccessStatusCode();
        }

        protected Task<TRes> GetAsync<TRes>(string uri, CancellationToken ct = default) =>
            this.httpClient.GetFromJsonAsync<TRes>(uri, this.JsonSerializerOptions, ct);

        protected async Task PostAsync<TPayload>(string uri, TPayload payload, CancellationToken ct = default)
        {
            using var response = await this.httpClient.PostAsJsonAsync(uri, payload, ct);
            response.EnsureSuccessStatusCode();
        }

        protected async Task PostAsync(string uri, HttpContent content = null, CancellationToken ct = default)
        {
            using var response = await this.httpClient.PostAsync(uri, content, ct);
            response.EnsureSuccessStatusCode();
        }

        protected async Task<TRes> PostAsync<TPayload, TRes>(string uri, TPayload payload, CancellationToken ct = default)
        {
            using var response = await this.httpClient.PostAsJsonAsync(uri, payload, ct);
            response.EnsureSuccessStatusCode();

            return await this.ParseHttpResponseContentAsync<TRes>(response, ct);
        }

        protected async Task PutAsync<TPayload>(string uri, TPayload payload, CancellationToken ct = default)
        {
            using var response = await this.httpClient.PutAsJsonAsync(uri, payload, ct);
            response.EnsureSuccessStatusCode();
        }

        protected async Task<TRes> PutAsync<TPayload, TRes>(string uri, TPayload payload, CancellationToken ct = default)
        {
            using var response = await this.httpClient.PutAsJsonAsync(uri, payload, ct);
            response.EnsureSuccessStatusCode();

            return await this.ParseHttpResponseContentAsync<TRes>(response, ct);
        }

        private async Task<TModel> ParseHttpResponseContentAsync<TModel>(HttpResponseMessage response, CancellationToken ct = default)
        {
            TModel model = default;
            if (response.Content is not null && response.Content.Headers.ContentType?.MediaType == MediaTypeNames.Application.Json)
            {
                model = await response.Content.ReadFromJsonAsync<TModel>(this.JsonSerializerOptions, ct);
            }

            return model;
        }
    }
}
