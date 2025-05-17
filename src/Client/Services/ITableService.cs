namespace PlanningPoker.Client.Services
{
    using PlanningPoker.Generated.Models;
    using PlanningPoker.SharedKernel.Models.Binding;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Service responsible for the management of poker tables.
    /// </summary>
    public interface ITableService
    {
        /// <summary>
        /// Creates a new poker table.
        /// </summary>
        /// <param name="bindingModel">The binding model.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>An instance of <see cref="TableModel"/>.</returns>
        Task<TableModel> CreateAsync(TableBindingModel bindingModel, CancellationToken ct = default);

        /// <summary>
        /// Deletes an existing poker table by it's unique identifier.
        /// </summary>
        /// <param name="id">The table's unique identifier.</param>
        /// <param name="ct">Cancellation token.</param>
        Task DeleteAsync(Guid id, CancellationToken ct = default);

        /// <summary>
        /// Retrieves an existing poker table by it's unique identifier.
        /// </summary>
        /// <param name="id">The table's unique identifier.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>An instance of <see cref="TableModel"/> or <see cref="null"/> if it does not exist.</returns>
        Task<TableModel> GetByIdAsync(Guid id, CancellationToken ct = default);

        /// <summary>
        /// Leaves an existing poker table.
        /// </summary>
        /// <param name="id">The table's unique identifier value.</param>
        /// <param name="ct">The cancellation token.</param>
        Task LeaveAsync(Guid id, CancellationToken ct = default);

        /// <summary>
        /// Modifies an existing poker table.
        /// </summary>
        /// <param name="bindingModel">The binding model.</param>
        /// <param name="ct">Cancellation token.</param>
        Task ModifyAsync(TableBindingModel bindingModel, CancellationToken ct = default);
    }
}