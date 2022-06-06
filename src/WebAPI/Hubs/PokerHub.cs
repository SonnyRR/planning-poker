namespace PlanningPoker.WebAPI.Hubs
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.SignalR;
	using PlanningPoker.Core.Services;
	using System;
	using System.Threading;
	using System.Threading.Tasks;

	/// <summary>
	/// SignalR hub for interacting with poker tables.
	/// </summary>
	[Authorize]
	public sealed class PokerHub : Hub
	{
		private readonly ITableService tableService;
		private readonly ICurrentUserService currentUserService;

		/// <summary>
		/// Contructs a SignalR hub for managing poker tables.
		/// </summary>
		/// <param name="tableService">An instance of <see cref="ITableService"/>.</param>
		/// <param name="currentUserService">An instance of <see cref="ICurrentUserService"/>.</param>
		public PokerHub(ITableService tableService, ICurrentUserService currentUserService)
			=> (this.tableService, this.currentUserService) = (tableService, currentUserService);

		/// <summary>
		/// Adds a user to specified table.
		/// </summary>
		/// <param name="tableId">The table unique identifier.</param>
		/// <param name="ct">The cancellation token.</param>
		public async Task AddToTable(Guid tableId, CancellationToken ct = default)
		{
			var table = await this.tableService.AddPlayerToTable(this.currentUserService.UserId, tableId, ct);

			if (table is not null)
			{
				await this.Groups.AddToGroupAsync(this.Context.ConnectionId, table.Id.ToString(), ct);
				await this.Clients
					.Group(table.Id.ToString())
					.SendAsync("AddedToTable", $"{this.Context.ConnectionId} has joined the group {table.Name}.", cancellationToken: ct);
			}
		}

		/// <summary>
		/// Removes a user from a specified table.
		/// </summary>
		/// <param name="tableName">The table name.</param>
		public async Task RemoveFromTable(string tableName)
		{
			await this.Groups.RemoveFromGroupAsync(this.Context.ConnectionId, tableName);

			await this.Clients
				.Group(tableName)
				.SendAsync("Send", $"{this.Context.ConnectionId} has left the group {tableName}.");
		}
	}
}
