namespace PlanningPoker.Core
{
    using PlanningPoker.Generated.Models;
    using PlanningPoker.SharedKernel.Models.Binding;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IRoundService
    {
        Task<RoundModel> CreateAsync(RoundBindingModel model, CancellationToken ct = default);

        Task<bool> DeleteAsync(Guid id, CancellationToken ct = default);

        Task Finalize(CancellationToken ct = default);
    }
}
