namespace PlanningPoker.WebAPI.Hubs
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.SignalR;
	using Microsoft.Extensions.Logging;
	using PlanningPoker.Core.Services;
	using PlanningPoker.SharedKernel.Interfaces;
	using PlanningPoker.SharedKernel.Models.Tables;
	using System;
	using System.Threading.Tasks;
	using static OpenIddict.Abstractions.OpenIddictConstants;

	/// <summary>
	/// SignalR hub for interacting with poker tables.
	/// </summary>
	[Authorize]
	public sealed class PokerHub : Hub<IPokerClient>
	{
		private readonly ILogger<PokerHub> logger;
		private readonly ITableService tableService;
		private readonly ICurrentUserService currentUserService;

		/// <summary>
		/// Contructs a SignalR hub for managing poker tables.
		/// </summary>
		/// <param name="tableService">An instance of <see cref="ITableService"/>.</param>
		/// <param name="currentUserService">The current user service.</param>
		/// <param name="logger">An instance of <see cref="ILogger{PokerHub}"/>.</param>
		public PokerHub(
			ITableService tableService,
			ICurrentUserService currentUserService,
			ILogger<PokerHub> logger)
		{
			this.tableService = tableService;
			this.currentUserService = currentUserService;
			this.logger = logger;
		}

		private string UserId => this.Context.User.FindFirst(Claims.Subject)?.Value;

		/// <summary>
		/// Adds a user to specified table.
		/// </summary>
		/// <param name="tableId">The table unique identifier.</param>
		[HubMethodName(nameof(IPokerClient.AddedToTable))]
		public async Task AddToTableAsync(Guid tableId)
		{
			var table = await this.tableService.AddPlayerToTable(Guid.Parse(this.UserId), tableId);

			if (table is not null)
			{
				await this.Groups.AddToGroupAsync(this.Context.ConnectionId, table.Id.ToString());
				this.logger.LogInformation("User {username} has been added to group & table: {tableId}.", this.UserId);
			}
		}

		/// <summary>
		/// Removes a user from a specified table.
		/// </summary>
		/// <param name="tableId">The table's unique identifier.</param>
		[HubMethodName(nameof(IPokerClient.RemovedFromTable))]
		public async Task RemoveFromTableAsync(Guid tableId)
		{
			await this.Groups.RemoveFromGroupAsync(this.Context.ConnectionId, tableId.ToString());
			await this.tableService.RemovePlayerFromTable(Guid.Parse(this.UserId), tableId);
		}

		/// <summary>
		/// Sends a user's vote to all other table players.
		/// </summary>
		/// <param name="vote">The player's vote.</param>
		[HubMethodName(nameof(IPokerClient.VoteCasted))]
		public async Task VoteAsync(PlayerVote vote)
		{
			vote.PlayerId = this.currentUserService.UserId;
			await this.Clients.Group(vote.TableId.ToString()).VoteCasted(vote);
		}
	}
}
