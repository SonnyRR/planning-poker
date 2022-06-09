namespace PlanningPoker.Client.Clients
{
	using Microsoft.AspNetCore.Components;
	using Microsoft.AspNetCore.SignalR.Client;
	using PlanningPoker.SharedKernel.Models.Tables;
	using System;
	using System.Threading.Tasks;
	using static SharedKernel.Constants.Hubs;

	/// <inheritdoc cref="BaseSignalRClient"/>
	/// <inheritdoc cref="IPokerSignalRClient"/>
	public class PokerHubClient : BaseSignalRClient, IPokerSignalRClient
	{
		public PokerHubClient(NavigationManager navigationManager)
			: base(navigationManager, POKER_HUB_URI)
		{
		}

		public async Task AddedToTable(Guid tableId)
			=> await this.HubConnection.SendAsync(nameof(AddedToTable), tableId);

		public void OnAddedToTable(Action<Guid> handler)
		{
			if (!this.HasStarted)
			{
				this.HubConnection.On(nameof(AddedToTable), handler);
			}
		}

		public void OnRemovedFromTable(Action<Guid> handler)
		{
			if (!this.HasStarted)
			{
				this.HubConnection.On(nameof(RemovedFromTable), handler);
			}
		}

		public void OnVoteCasted(Action<PlayerVote> handler)
		{
			if (!this.HasStarted)
			{
				this.HubConnection.On(nameof(VoteCasted), handler);
			}
		}

		public async Task RemovedFromTable(Guid tableId)
			=> await this.HubConnection.SendAsync(nameof(RemovedFromTable), tableId);

		public async Task VoteCasted(PlayerVote vote)
			=> await this.HubConnection.SendAsync(nameof(VoteCasted), vote);
	}
}
