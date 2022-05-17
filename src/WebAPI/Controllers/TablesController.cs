namespace PlanningPoker.WebAPI.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	using PlanningPoker.Core.Models.Binding;
	using PlanningPoker.Core.Services;

	using System;
	using System.Threading;
	using System.Threading.Tasks;

	[Authorize]
	public sealed class TablesController : BasePokerController
	{
		private const string ID_ROUTE_PARAM = "{id:guid}";
		private readonly ITableService tableService;

		public TablesController(ITableService tableService) => this.tableService = tableService;

		[HttpGet(ID_ROUTE_PARAM)]
		public async Task<object> Get([FromRoute] Guid id, CancellationToken ct)
			=> await this.tableService.GetByIdAsync(id, ct);

		[HttpPost]
		public async Task<object> Create([FromBody] TableMetadata tableMetadata, CancellationToken ct)
			=> await this.tableService.CreateAsync(tableMetadata, ct);

		[HttpPut(ID_ROUTE_PARAM)]
		public async Task<object> Update(
			[FromRoute] Guid id,
			[FromBody] TableMetadata tableMetadata,
			CancellationToken ct)
			=> await this.tableService.UpdateAsync(id, tableMetadata, ct);

		[HttpDelete(ID_ROUTE_PARAM)]
		public async Task<bool> Delete([FromRoute] Guid id, CancellationToken ct)
			=> await this.tableService.DeleteAsync(id, ct);
	}
}
