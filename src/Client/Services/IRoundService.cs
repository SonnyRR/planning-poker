namespace PlanningPoker.Client
{
    using PlanningPoker.SharedKernel.Models.Binding;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IRoundService
    {
        Task CreateAsync(RoundBindingModel model, CancellationToken ct = default);

        Task DeleteAsync(Guid id, CancellationToken ct = default);

        Task Finalize(CancellationToken ct = default);
    }
}