
namespace PlanningPoker.Client
{
    using PlanningPoker.Client.Services;
    using PlanningPoker.SharedKernel.Models.Binding;
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class RoundService : BaseHttpService, IRoundService
    {
        private const string ROUTE = "/api/rounds";

        public RoundService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, true)
        {
        }

        public Task CreateAsync(RoundBindingModel model, CancellationToken ct = default)
            => this.PostAsync(ROUTE, model, ct);

        public Task DeleteAsync(Guid id, CancellationToken ct = default)
            => this.DeleteAsync($"{ROUTE}/{id}", ct);

        public Task Finalize(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}