namespace PlanningPoker.Client.Clients
{
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.SignalR.Client;
    using PlanningPoker.Client.Authorization;
    using PlanningPoker.SharedKernel.Interfaces;
    using PlanningPoker.SharedKernel.Models.Generated;
    using PlanningPoker.SharedKernel.Models.Tables;
    using System;
    using System.Threading.Tasks;
    using static SharedKernel.Constants.Hubs;

    /// <inheritdoc cref="BaseSignalRClient"/>
    /// <inheritdoc cref="IBlazorPokerClient"/>
    public class PokerHubClient : BaseSignalRClient, IBlazorPokerClient
    {
        public PokerHubClient(NavigationManager navigationManager, HostAuthenticationStateProvider hostAuthenticationStateProvider)
            : base(navigationManager, POKER_HUB_URI, hostAuthenticationStateProvider)
        {
        }

        public Task AddToTableAsync(Guid tableId)
            => this.HubConnection.SendAsync(nameof(IPokerClient.AddedToTable), tableId);

        public void OnAddedToTable(Action<Guid> handler)
        {
            if (!this.HasStarted)
            {
                this.HubConnection.On(nameof(IPokerClient.AddedToTable), handler);
            }
        }

        public void OnRemovedFromTable(Action<Guid> handler)
        {
            if (!this.HasStarted)
            {
                this.HubConnection.On(nameof(IPokerClient.RemovedFromTable), handler);
            }
        }

        public void OnVoteCasted(Action<PlayerVote> handler)
        {
            if (!this.HasStarted)
            {
                this.HubConnection.On(nameof(IPokerClient.VoteCasted), handler);
            }
        }

        public void OnVotingRoundStarted(Action<Guid> handler)
        {
            if (!this.HasStarted)
            {
                this.HubConnection.On(nameof(IPokerClient.VotingRoundStarted), handler);
            }
        }

        public void OnVotingRoundCreated(Action<RoundModel> handler)
        {
            if (!this.HasStarted)
            {
                this.HubConnection.On(nameof(IPokerClient.VotingRoundCreated), handler);
            }
        }

        public Task RemoveFromTableAsync(Guid tableId)
            => this.HubConnection.SendAsync(nameof(IPokerClient.RemovedFromTable), tableId);

        public Task CastVoteAsync(PlayerVote vote)
            => this.HubConnection.SendAsync(nameof(IPokerClient.VoteCasted), vote);

        public Task StartVotingRound(Guid tableId)
            => this.HubConnection.SendAsync(nameof(IPokerClient.VotingRoundStarted), tableId);
    }
}
