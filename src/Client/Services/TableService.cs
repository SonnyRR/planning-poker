namespace PlanningPoker.Client.Services
{
	using PlanningPoker.SharedKernel.Models.Binding;
	using PlanningPoker.SharedKernel.Models.Generated;
	using System;
	using System.Net.Http;
	using System.Threading.Tasks;

	public class TableService : BaseHttpService, ITableService
	{
		public TableService(IHttpClientFactory httpClientFactory)
			: base(httpClientFactory, true)
		{
		}

		public Task<TableModel> CreateAsync(TableBindingModel metadata) => throw new NotImplementedException();

		public Task<bool> DeleteAsync(Guid id) => throw new NotImplementedException();

		public Task<TableModel> GetByIdAsync(Guid id) => base.GetAsync<TableModel>($"/api/tables/{id}");

		public Task<TableModel> ModifyAsync(TableBindingModel metadata) => throw new NotImplementedException();
	}
}
