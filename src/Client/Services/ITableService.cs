namespace PlanningPoker.Client.Services
{
	using PlanningPoker.SharedKernel.Models.Binding;
	using PlanningPoker.SharedKernel.Models.Generated;
	using System;
	using System.Threading.Tasks;

	public interface ITableService
	{
		Task<TableModel> CreateAsync(TableBindingModel metadata);

		Task<bool> DeleteAsync(Guid id);

		Task<TableModel> GetByIdAsync(Guid id);

		Task<TableModel> ModifyAsync(TableBindingModel metadata);
	}
}
