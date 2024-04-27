
namespace PlanningPoker.Client
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using PlanningPoker.Client.Services;
    using PlanningPoker.SharedKernel.Models.Binding;
    using PlanningPoker.SharedKernel.Models.Generated;

    public class RoundService : BaseHttpService, IRoundService
    {
        private const string ROUTE = "/api/tables";

        public RoundService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, true)
        {
        }

        public Task<RoundModel> CreateAsync(RoundBindingModel model, CancellationToken ct = default)
            => this.PostAsync<RoundBindingModel, RoundModel>(ROUTE, model, ct);

        public Task DeleteAsync(Guid id, CancellationToken ct = default)
            => this.DeleteAsync($"{ROUTE}/{id}", ct);

        public Task Finalize(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}