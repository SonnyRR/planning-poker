namespace PlanningPoker.Core.Services;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using PlanningPoker.Generated.Models;
    using PlanningPoker.SharedKernel.Models.Binding;

    public interface IRoundService
    {
        Task<RoundModel> CreateAsync(RoundBindingModel model, CancellationToken ct = default);

        Task<bool> DeleteAsync(Guid id, CancellationToken ct = default);

        Task Finalize(CancellationToken ct = default);
    }
