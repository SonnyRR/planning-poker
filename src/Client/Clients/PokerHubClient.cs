namespace PlanningPoker.Client.Clients
{
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.SignalR.Client;
    using PlanningPoker.Client.Authorization;
    using PlanningPoker.Generated.Models;
    using PlanningPoker.SharedKernel.Models.Tables;
    using PlanningPoker.Sockets;
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
            => this.HubConnection.SendAsync(nameof(IPokerClient.AddToTable), tableId);

        public void OnAddedToTable(Action<Guid> handler)
        {
            if (!this.HasStarted)
            {
                this.HubConnection.On(nameof(IPokerClient.AddToTable), handler);
            }
        }

        public void OnRemovedFromTable(Action<Guid> handler)
        {
            if (!this.HasStarted)
            {
                this.HubConnection.On(nameof(IPokerClient.RemoveFromTable), handler);
            }
        }

        public void OnVoteCasted(Action<PlayerVote> handler)
        {
            if (!this.HasStarted)
            {
                this.HubConnection.On(nameof(IPokerClient.Vote), handler);
            }
        }

        public void OnVotingRoundStarted(Action<Guid> handler)
        {
            if (!this.HasStarted)
            {
                this.HubConnection.On(nameof(IPokerClient.StartVotingRound), handler);
            }
        }

        public void OnVotingRoundCreated(Action<RoundModel> handler)
        {
            if (!this.HasStarted)
            {
                this.HubConnection.On(nameof(IPokerClient.CreateVotingRound), handler);
            }
        }

        public Task RemoveFromTableAsync(Guid tableId)
            => this.HubConnection.SendAsync(nameof(IPokerClient.RemoveFromTable), tableId);

        public Task CastVoteAsync(PlayerVote vote)
            => this.HubConnection.SendAsync(nameof(IPokerClient.Vote), vote);

        public Task StartVotingRound(Guid tableId)
            => this.HubConnection.SendAsync(nameof(IPokerClient.StartVotingRound), tableId);
    }
}
