namespace PlanningPoker.WebAPI.Hubs
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.SignalR;
    using Microsoft.Extensions.Logging;
    using Core.Services;
    using SharedKernel.Interfaces;
    using SharedKernel.Models.Tables;
    using System;
    using System.Threading.Tasks;
    using static OpenIddict.Abstractions.OpenIddictConstants;
    using static SharedKernel.Constants;
    using Mapster;

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
        /// Constructs a SignalR hub for managing poker tables.
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

        /// <inheritdoc />
        public override async Task OnConnectedAsync()
        {
            var userName = this.currentUserService.Username;
            await this.Groups.AddToGroupAsync(this.Context.ConnectionId, $"{Hubs.USER_GROUP_PREFIX}${userName}");
            await base.OnConnectedAsync();
        }

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
                await this.Clients
                    .Group(table.Id.ToString())
                    .AddedToTable(new PlayerJoined
                    {
                        Id = this.currentUserService.UserId,
                        Username = this.currentUserService.Username
                    });

                this.logger.LogInformation("User {Username} has been added to group & table: {TableId}.", this.UserId, tableId);
                return;
            }

            this.logger.LogError("Table: '{TableId}' has not been found!", tableId);
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

        /// <summary>
        /// Starts a new voting session.
        /// </summary>
        /// <param name="tableId">The table's unique identifier.</param>
        [HubMethodName(nameof(IPokerClient.VotingRoundStarted))]
        public async Task StartVotingRound(Guid tableId)
        {
            await this.Clients.Group(tableId.ToString()).VotingRoundStarted(tableId);
        }
    }
}
