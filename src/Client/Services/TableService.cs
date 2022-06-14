namespace PlanningPoker.Client.Services
{
	using PlanningPoker.SharedKernel.Models.Binding;
	using PlanningPoker.SharedKernel.Models.Generated;
	using System;
	using System.Net.Http;
	using System.Threading;
	using System.Threading.Tasks;

	/// <inheritdoc cref="ITableService"/>
	public class TableService : BaseHttpService, ITableService
	{
		private const string ROUTE = "/api/tables";

		public TableService(IHttpClientFactory httpClientFactory)
			: base(httpClientFactory, true)
		{
		}

		public Task<TableModel> CreateAsync(TableBindingModel bindingModel, CancellationToken ct = default)
			=> this.PostAsync<TableBindingModel, TableModel>(ROUTE, bindingModel, ct);

		public Task DeleteAsync(Guid id, CancellationToken ct = default)
			=> this.DeleteAsync($"{ROUTE}/{id}", ct);

		public Task<TableModel> GetByIdAsync(Guid id, CancellationToken ct = default)
			=> this.GetAsync<TableModel>($"{ROUTE}/{id}", ct);

		public Task LeaveAsync(Guid id, CancellationToken ct = default)
			=> this.PostAsync($"{ROUTE}/{id}/leave", ct);

		public Task ModifyAsync(TableBindingModel bindingModel, CancellationToken ct = default)
			=> this.PostAsync(ROUTE, bindingModel, ct);
	}
}
