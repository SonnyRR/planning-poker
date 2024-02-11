namespace PlanningPoker.Client
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using PlanningPoker.SharedKernel;
    using PlanningPoker.SharedKernel.Models.Generated;

    public interface IRoundService
    {
        Task<RoundModel> CreateAsync(RoundBindingModel model, CancellationToken ct = default);

        Task DeleteAsync(Guid id, CancellationToken ct = default);

        Task Finalize(CancellationToken ct = default);
    }
}
