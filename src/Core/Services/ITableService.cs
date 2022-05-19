namespace PlanningPoker.Core.Services
{
	using PlanningPoker.Core.Models.Binding;
	using PlanningPoker.Persistence.Entities;
	using PlanningPoker.SharedKernel.Models.Decks;

	using System;
	using System.Threading;
	using System.Threading.Tasks;

	/// <summary>
	/// Provides CRUD operations for poker tables.
	/// </summary>
	public interface ITableService
	{
		/// <summary>
		/// Creates a new poker table.
		/// </summary>
		/// <param name="tableMetadata">Table metadata.</param>
		/// <param name="ct">The cancellation token.</param>
		/// <returns>Instance of <see cref="Table"/>.</returns>
		Task<Table> CreateAsync(TableMetadata tableMetadata, CancellationToken ct = default);

		/// <summary>
		/// Retrieves an existing poker table by it's unique identifier.
		/// </summary>
		/// <param name="id">The unique identifier value.</param>
		/// <param name="ct">The cancellation token.</param>
		/// <returns>Instance of <see cref="Table"/> or <see cref="null"/> if it does not exist.</returns>
		Task<Table> GetByIdAsync(Guid id, CancellationToken ct = default);

		/// <summary>
		/// Deletes an existing poker table by it's unique identifier.
		/// </summary>
		/// <param name="id">The unique identifier value.</param>
		/// <param name="ct">The cancellation token.</param>
		/// <returns>A flag indicating if the operation was successfull.</returns>
		Task<bool> DeleteAsync(Guid id, CancellationToken ct = default);

		/// <summary>
		/// Updates an existing poker table by it's unique identifier.
		/// </summary>
		/// <param name="tableMetadata">Table metadata.</param>
		/// <param name="ct">The cancellation token.</param>
		/// <returns>Instance of <see cref="Table"/>.</returns>
		Task<Table> UpdateAsync(TableMetadata tableMetadata, CancellationToken ct = default);
	}
}
