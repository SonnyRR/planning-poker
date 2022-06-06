namespace PlanningPoker.Core.Services
{
	using Ardalis.GuardClauses;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Logging;
	using PlanningPoker.Persistence;
	using PlanningPoker.Persistence.Entities;
	using PlanningPoker.SharedKernel.Models.Binding;
	using System;
	using System.Threading;
	using System.Threading.Tasks;

	/// <inheritdoc cref="ITableService" />
	public sealed class TableService : ITableService
	{
		private readonly ICurrentUserService currentUserService;
		private readonly PlanningPokerDbContext dbContext;
		private readonly ILogger<TableService> logger;

		public TableService(PlanningPokerDbContext dbContext, ILogger<TableService> logger, ICurrentUserService currentUserService)
		{
			Guard.Against.Null(dbContext, nameof(dbContext));
			Guard.Against.Null(logger, nameof(logger));
			Guard.Against.Null(currentUserService, nameof(currentUserService));

			this.dbContext = dbContext;
			this.logger = logger;
			this.currentUserService = currentUserService;
		}

		public async Task<Table> CreateAsync(TableBindingModel bindingModel, CancellationToken ct = default)
		{
			var table = new Table(bindingModel.DeckType, bindingModel.Name, this.currentUserService.UserId);
			await this.dbContext.Tables.AddAsync(table, ct);
			await this.dbContext.SaveChangesAsync(ct);

			return table;
		}

		public async Task<bool> DeleteAsync(Guid id, CancellationToken ct = default)
		{
			this.dbContext.Tables.Remove(new() { Id = id });
			return Convert.ToBoolean(await this.dbContext.SaveChangesAsync(ct));
		}

		public async Task<Table> GetByIdAsync(Guid id, CancellationToken ct = default)
		{
			var table = await this.dbContext.Tables.SingleOrDefaultAsync(t => t.Id == id, ct);

			if (table is null)
			{
				this.logger.LogError("Table with id '{id}' not found.", id);
				return null;
			}

			return table;
		}

		public async Task<Table> UpdateAsync(TableBindingModel bindingModel, CancellationToken ct = default)
		{
			if (bindingModel is null || !bindingModel.Id.HasValue)
				return null;

			var tableToUpdate = await this.dbContext.Tables.SingleOrDefaultAsync(t => t.Id == bindingModel.Id.Value, ct);

			if (tableToUpdate is null)
			{
				// TODO: Extract constant.
				this.logger.LogError("Table with id '{id}' not found.", bindingModel.Id.Value);
				return null;
			}

			tableToUpdate.Name = bindingModel.Name;
			tableToUpdate.DeckType = bindingModel.DeckType;

			await this.dbContext.SaveChangesAsync(ct);
			return tableToUpdate;
		}
	}
}
