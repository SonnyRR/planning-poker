namespace PlanningPoker.Client.Services
{
	using PlanningPoker.SharedKernel.Models.Generated;
	using PlanningPoker.SharedKernel.Models.Tables;
	using System;
	using System.Threading.Tasks;

	public interface ITableService
	{
		Task<TableModel> CreateAsync(TableMetadata metadata);

		Task<bool> DeleteAsync(Guid id);

		Task<TableModel> GetByIdAsync(Guid id);

		Task<TableModel> ModifyAsync(TableMetadata metadata);
	}
}
