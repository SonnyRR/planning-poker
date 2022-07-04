namespace PlanningPoker.Core.Services
{
	using Ardalis.GuardClauses;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Logging;
	using PlanningPoker.Persistence;
	using PlanningPoker.Persistence.Entities;
	using PlanningPoker.SharedKernel.Models.Binding;
	using System;
	using System.Linq;
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

		public async Task<Table> AddPlayerToTable(Guid playerId, Guid tableId, CancellationToken ct = default)
		{
			Table table = await this.GetByIdAsync(tableId, ct);

			if (table is not null && !table.Players.Any(p => p.Id == playerId))
			{
				var user = await this.dbContext.Users.SingleOrDefaultAsync(u => u.Id == playerId, ct);
				table.Players.Add(user);
				await this.dbContext.SaveChangesAsync(ct);
			}

			return table;
		}

		public async Task<Table> CreateAsync(TableBindingModel bindingModel, CancellationToken ct = default)
		{
			var user = await this.dbContext.Users.FindAsync(this.currentUserService.UserId);
			var deck = await this.dbContext
				.Decks
				.Select(d => new { d.Id, d.Type })
				.SingleOrDefaultAsync(d => d.Type == bindingModel.DeckType);

			var table = new Table(deck.Id, bindingModel.Name, user.Id);
			table.Players.Add(user);

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
			var table = await this.dbContext
				.Tables
				.Include(t => t.Players)
				.Include(t => t.Deck)
					.ThenInclude(d => d.Cards)
				.SingleOrDefaultAsync(t => t.Id == id, ct);

			if (table is null)
			{
				this.logger.LogError("Table with id '{id}' not found.", id);
				return null;
			}

			return table;
		}

		public Task<Table> LeaveTableAsync(Guid tableId, CancellationToken ct = default)
			=> this.RemovePlayerFromTable(this.currentUserService.UserId, tableId, ct);

		public async Task<Table> RemovePlayerFromTable(Guid playerId, Guid tableId, CancellationToken ct = default)
		{
			var table = await this.GetByIdAsync(tableId, ct);
			if (table is not null)
			{
				var playerToRemove = table.Players.SingleOrDefault(p => p.Id == playerId);
				table.Players.Remove(playerToRemove);
				await this.dbContext.SaveChangesAsync(ct);
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
			tableToUpdate.Deck = null;

			await this.dbContext.SaveChangesAsync(ct);
			return tableToUpdate;
		}
	}
}
