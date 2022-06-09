namespace PlanningPoker.WebAPI.Hubs
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.SignalR;
	using PlanningPoker.Core.Services;
	using PlanningPoker.SharedKernel.Interfaces;
	using System;
	using System.Threading;
	using System.Threading.Tasks;
	using static OpenIddict.Abstractions.OpenIddictConstants;

	/// <summary>
	/// SignalR hub for interacting with poker tables.
	/// </summary>
	[Authorize]
	public sealed class PokerHub : Hub<IPokerClient>
	{
		private readonly ITableService tableService;

		private string UserId => this.Context.User.FindFirst(Claims.Subject)?.Value;

		/// <summary>
		/// Contructs a SignalR hub for managing poker tables.
		/// </summary>
		/// <param name="tableService">An instance of <see cref="ITableService"/>.</param>
		public PokerHub(ITableService tableService)
			=> this.tableService = tableService;

		/// <summary>
		/// Adds a user to specified table.
		/// </summary>
		/// <param name="tableId">The table unique identifier.</param>
		/// <param name="ct">The cancellation token.</param>
		[HubMethodName(nameof(IPokerClient.AddedToTable))]
		public async Task AddToTableAsync(Guid tableId, CancellationToken ct = default)
		{
			var table = await this.tableService.AddPlayerToTable(Guid.Parse(this.UserId), tableId, ct);

			if (table is not null)
			{
				await this.Groups.AddToGroupAsync(this.Context.ConnectionId, table.Id.ToString(), ct);
			}
		}

		/// <summary>
		/// Removes a user from a specified table.
		/// </summary>
		/// <param name="tableName">The table name.</param>
		[HubMethodName(nameof(IPokerClient.RemovedFromTable))]
		public async Task RemoveFromTableAsync(string tableName)
		{
			await this.Groups.RemoveFromGroupAsync(this.Context.ConnectionId, tableName);
		}

		/// <summary>
		/// Sends a user's vote to all other table players.
		/// </summary>
		/// <param name="val"></param>
		[HubMethodName(nameof(IPokerClient.VoteCasted))]
		public async Task VoteAsync(int val)
		{
			await this.Clients.All.VoteCasted(val);
		}
	}
}
