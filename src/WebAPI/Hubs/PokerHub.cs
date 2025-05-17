namespace PlanningPoker.WebAPI.Hubs
{
    using Core.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.SignalR;
    using Microsoft.Extensions.Logging;
    using PlanningPoker.Core;
    using PlanningPoker.SharedKernel.Models.Binding;
    using PlanningPoker.Sockets;
    using SharedKernel.Models.Tables;
    using System;
    using System.Threading.Tasks;
    using static OpenIddict.Abstractions.OpenIddictConstants;
    using static SharedKernel.Constants;

    /// <summary>
    /// SignalR hub for interacting with poker tables.
    /// </summary>
    [Authorize]
    public sealed class PokerHub : Hub<IPokerClient>
    {
        private readonly ICurrentUserService currentUserService;
        private readonly ILogger<PokerHub> logger;
        private readonly IRoundService roundService;
        private readonly ITableService tableService;

        /// <summary>
        /// Constructs a SignalR hub for managing poker tables.
        /// </summary>
        /// <param name="tableService">An instance of <see cref="ITableService"/>.</param>
        /// <param name="currentUserService">The current user service.</param>
        /// <param name="roundService"></param>
        /// <param name="logger">An instance of <see cref="ILogger{PokerHub}"/>.</param>
        public PokerHub(
            ITableService tableService,
            ICurrentUserService currentUserService,
            IRoundService roundService,
            ILogger<PokerHub> logger)
        {
            this.tableService = tableService;
            this.currentUserService = currentUserService;
            this.roundService = roundService;
            this.logger = logger;
        }

        private string UserId => this.Context.User.FindFirst(Claims.Subject)?.Value;

        /// <summary>
        /// Adds a user to specified table.
        /// </summary>
        /// <param name="tableId">The table unique identifier.</param>
        [HubMethodName(nameof(IPokerClient.AddToTable))]
        public async Task AddToTableAsync(Guid tableId)
        {
            var table = await this.tableService.AddPlayerToTable(Guid.Parse(this.UserId), tableId);

            if (table is not null)
            {
                await this.Groups.AddToGroupAsync(this.Context.ConnectionId, table.Id.ToString());
                await this.Clients
                    .Group(table.Id.ToString())
                    .AddToTable(new PlayerJoined
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
        /// Creates a voting round.
        /// </summary>
        /// <param name="bindingModel"></param>
        /// <returns></returns>
        [HubMethodName(nameof(IPokerClient.CreateVotingRound))]
        public async Task CreateVotingRoundAsync(RoundBindingModel bindingModel)
        {
            var round = await this.roundService.CreateAsync(bindingModel);
            await this.Clients.Group(bindingModel.TableId.ToString()).CreateVotingRound(round);
        }

        /// <inheritdoc />
        public override async Task OnConnectedAsync()
        {
            var userName = this.currentUserService.Username;
            await this.Groups.AddToGroupAsync(this.Context.ConnectionId, $"{Hubs.USER_GROUP_PREFIX}${userName}");
            await base.OnConnectedAsync();
        }

        /// <summary>
        /// Removes a user from a specified table.
        /// </summary>
        /// <param name="tableId">The table's unique identifier.</param>
        [HubMethodName(nameof(IPokerClient.RemoveFromTable))]
        public async Task RemoveFromTableAsync(Guid tableId)
        {
            await this.Groups.RemoveFromGroupAsync(this.Context.ConnectionId, tableId.ToString());
            await this.tableService.RemovePlayerFromTable(Guid.Parse(this.UserId), tableId);
        }

        /// <summary>
        /// Starts a new voting session.
        /// </summary>
        /// <param name="tableId">The table's unique identifier.</param>
        [HubMethodName(nameof(IPokerClient.StartVotingRound))]
        public async Task StartVotingRound(Guid tableId)
        {
            await this.Clients.Group(tableId.ToString()).StartVotingRound(tableId);
        }

        /// <summary>
        /// Sends a user's vote to all other table players.
        /// </summary>
        /// <param name="vote">The player's vote.</param>
        [HubMethodName(nameof(IPokerClient.Vote))]
        public async Task VoteAsync(PlayerVote vote)
        {
            vote.PlayerId = this.currentUserService.UserId;
            await this.Clients.Group(vote.TableId.ToString()).Vote(vote);
        }
    }
}