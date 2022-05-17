namespace PlanningPoker.Core.Services
{
	using Ardalis.GuardClauses;

	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Logging;

	using PlanningPoker.Core.Models.Binding;
	using PlanningPoker.Persistence;
	using PlanningPoker.Persistence.Entities;

	using System;
	using System.Threading;
	using System.Threading.Tasks;

	/// <inheritdoc cref="ITableService" />
	public sealed class TableService : ITableService
	{
		private readonly PlanningPokerDbContext dbContext;
		private readonly ILogger<TableService> logger;

		public TableService(PlanningPokerDbContext dbContext, ILogger<TableService> logger)
		{
			Guard.Against.Null(dbContext, nameof(dbContext));
			Guard.Against.Null(logger, nameof(logger));

			this.dbContext = dbContext;
			this.logger = logger;
		}

		public async Task<Table> CreateAsync(TableMetadata tableMetadata, CancellationToken ct = default)
		{
			var table = new Table(tableMetadata.DeckType, tableMetadata.Name);
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

		public async Task<Table> UpdateAsync(Guid id, TableMetadata tableMetadata, CancellationToken ct = default)
		{
			var tableToUpdate = await this.dbContext.Tables.SingleOrDefaultAsync(t => t.Id == id, ct);

			if (tableToUpdate is null)
			{
				// TODO: Extract constant.
				this.logger.LogError("Table with id '{id}' not found.", id);
				return null;
			}

			tableToUpdate.Name = tableMetadata.Name;
			tableToUpdate.DeckType = tableMetadata.DeckType;

			await this.dbContext.SaveChangesAsync(ct);
			return tableToUpdate;
		}
	}
}
