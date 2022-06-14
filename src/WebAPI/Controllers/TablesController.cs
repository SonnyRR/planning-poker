namespace PlanningPoker.WebAPI.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using PlanningPoker.Core.Mapping;
	using PlanningPoker.Core.Services;
	using PlanningPoker.SharedKernel.Models.Binding;
	using PlanningPoker.SharedKernel.Models.Generated;
	using System;
	using System.Threading;
	using System.Threading.Tasks;

	/// <summary>
	/// Responsible for managing poker tables.
	/// </summary>
	[Authorize]
	public sealed class TablesController : BasePokerController
	{
		private const string ID_ROUTE_PARAM = "{id:guid}";
		private readonly ITableService tableService;

		/// <summary>
		/// Instantiates a new tables controller.
		/// </summary>
		/// <param name="tableService"></param>
		public TablesController(ITableService tableService) => this.tableService = tableService;

		/// <summary>
		/// Retrieves an existing poker table.
		/// </summary>
		/// <param name="id">The unique identifier of the table.</param>
		/// <param name="ct">Cancellation token.</param>
		/// <returns>An instance of <see cref="TableModel"/>.</returns>
		[HttpGet(ID_ROUTE_PARAM)]
		public async Task<TableModel> Get([FromRoute] Guid id, CancellationToken ct)
			=> (await this.tableService.GetByIdAsync(id, ct)).AdaptToModel();

		/// <summary>
		/// Creates a new poker table.
		/// </summary>
		/// <param name="tableMetadata">The table metadata.</param>
		/// <param name="ct">Cancellation token.</param>
		/// <returns>An instance of <see cref="TableBindingModel"/>.</returns>
		[HttpPost]
		public async Task<TableModel> Create([FromBody] TableBindingModel tableMetadata, CancellationToken ct)
			=> (await this.tableService.CreateAsync(tableMetadata, ct)).AdaptToModel();

		/// <summary>
		/// Updates an existing poker table.
		/// </summary>
		/// <param name="tableMetadata">The table metadata.</param>
		/// <param name="ct">Cancellation token.</param>
		/// <returns>An instance of <see cref="TableModel"/>.</returns>
		[HttpPut]
		public async Task<TableModel> Update([FromBody] TableBindingModel tableMetadata, CancellationToken ct)
			=> (await this.tableService.UpdateAsync(tableMetadata, ct)).AdaptToModel();

		/// <summary>
		/// Deletes an existing poker table.
		/// </summary>
		/// <param name="id">The unique identifier of the table.</param>
		/// <param name="ct">Cancellation token.</param>
		/// <returns>A <see cref="bool"/> flag, indicating if the table was successfully deleted.</returns>
		[HttpDelete(ID_ROUTE_PARAM)]
		public async Task<bool> Delete([FromRoute] Guid id, CancellationToken ct)
			=> await this.tableService.DeleteAsync(id, ct);

		/// <summary>
		/// Removes the currently signed-in player from an existing table.
		/// </summary>
		/// <param name="id">The table's unique identifier value.</param>
		/// <param name="ct">The cancellation token.</param>
		/// <returns>An instance of <see cref="TableModel"/>.</returns>
		[HttpPost($"{ID_ROUTE_PARAM}/leave")]
		public async Task<TableModel> LeaveAsync([FromRoute] Guid id, CancellationToken ct)
			=> (await this.tableService.LeaveTableAsync(id, ct)).AdaptToModel();
	}
}
