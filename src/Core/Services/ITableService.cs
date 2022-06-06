namespace PlanningPoker.Core.Services
{
	using PlanningPoker.Persistence.Entities;
	using PlanningPoker.SharedKernel.Models.Binding;

	using System;
	using System.Threading;
	using System.Threading.Tasks;

	/// <summary>
	/// Provides CRUD operations for poker tables.
	/// </summary>
	public interface ITableService
	{
		/// <summary>
		/// Adds a player to an existing poker table by their unique identifiers.
		/// </summary>
		/// <param name="playerId">The player's unique identifier value.</param>
		/// <param name="tableId">The table's unique identifier value.</param>
		/// <param name="ct">The cancellation token.</param>
		/// <returns>An instance of <see cref="Table"/>.</returns>
		Task<Table> AddPlayerToTable(Guid playerId, Guid tableId, CancellationToken ct = default);

		/// <summary>
		/// Creates a new poker table.
		/// </summary>
		/// <param name="bindingModel">Table metadata.</param>
		/// <param name="ct">The cancellation token.</param>
		/// <returns>Instance of <see cref="Table"/>.</returns>
		Task<Table> CreateAsync(TableBindingModel bindingModel, CancellationToken ct = default);

		/// <summary>
		/// Deletes an existing poker table by it's unique identifier.
		/// </summary>
		/// <param name="id">The unique identifier value.</param>
		/// <param name="ct">The cancellation token.</param>
		/// <returns>A flag indicating if the operation was successfull.</returns>
		Task<bool> DeleteAsync(Guid id, CancellationToken ct = default);

		/// <summary>
		/// Retrieves an existing poker table by it's unique identifier.
		/// </summary>
		/// <param name="id">The unique identifier value.</param>
		/// <param name="ct">The cancellation token.</param>
		/// <returns>Instance of <see cref="Table"/> or <see cref="null"/> if it does not exist.</returns>
		Task<Table> GetByIdAsync(Guid id, CancellationToken ct = default);
		/// <summary>
		/// Removes a player from an existing poker table by their unique identifiers.
		/// </summary>
		/// <param name="playerId">The player's unique identifier value.</param>
		/// <param name="tableId">The table's unique identifier value.</param>
		/// <param name="ct">The cancellation token.</param>
		/// <returns>An instance of <see cref="Table"/>.</returns>
		Task<Table> RemovePlayerFromTable(Guid playerId, Guid tableId, CancellationToken ct = default);

		/// <summary>
		/// Updates an existing poker table by it's unique identifier.
		/// </summary>
		/// <param name="bindingModel">Table metadata.</param>
		/// <param name="ct">The cancellation token.</param>
		/// <returns>Instance of <see cref="Table"/>.</returns>
		Task<Table> UpdateAsync(TableBindingModel bindingModel, CancellationToken ct = default);
	}
}
