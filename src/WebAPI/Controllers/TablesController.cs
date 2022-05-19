namespace PlanningPoker.WebAPI.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	using PlanningPoker.Core.Models.Binding;
	using PlanningPoker.Core.Services;

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
		/// <returns></returns>
		[HttpGet(ID_ROUTE_PARAM)]
		public async Task<object> Get([FromRoute] Guid id, CancellationToken ct)
			=> await this.tableService.GetByIdAsync(id, ct);

		/// <summary>
		/// Creates a new poker table.
		/// </summary>
		/// <param name="tableMetadata">The table metadata.</param>
		/// <param name="ct">Cancellation token.</param>
		/// <returns></returns>
		[HttpPost]
		public async Task<object> Create([FromBody] TableMetadata tableMetadata, CancellationToken ct)
			=> await this.tableService.CreateAsync(tableMetadata, ct);

		/// <summary>
		/// Updates an existing poker table.
		/// </summary>
		/// <param name="tableMetadata">The table metadata.</param>
		/// <param name="ct">Cancellation token.</param>
		/// <returns></returns>
		[HttpPut]
		public async Task<object> Update([FromBody] TableMetadata tableMetadata, CancellationToken ct)
			=> await this.tableService.UpdateAsync(tableMetadata, ct);

		/// <summary>
		/// Deletes an existing poker table.
		/// </summary>
		/// <param name="id">The unique identifier of the table.</param>
		/// <param name="ct">Cancellation token.</param>
		/// <returns></returns>
		[HttpDelete(ID_ROUTE_PARAM)]
		public async Task<bool> Delete([FromRoute] Guid id, CancellationToken ct)
			=> await this.tableService.DeleteAsync(id, ct);
	}
}
