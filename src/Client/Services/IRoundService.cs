namespace PlanningPoker.Client
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using PlanningPoker.SharedKernel.Models.Binding;

    public interface IRoundService
    {
        Task CreateAsync(RoundBindingModel model, CancellationToken ct = default);

        Task DeleteAsync(Guid id, CancellationToken ct = default);

        Task Finalize(CancellationToken ct = default);
    }
}
