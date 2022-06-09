namespace PlanningPoker.Client.Clients
{
	using PlanningPoker.SharedKernel.Interfaces;
	using System;

	/// <summary>
	/// Contract for SignalR clients responsible for managing scrum poker games.
	/// </summary>
	public interface IPokerSignalRClient : ISignalRClient, IPokerClient
	{
		/// <summary>
		/// Registers a handler that is called whenever a new player is added to a poker table.
		/// </summary>
		/// <param name="handler">The handler delegate.</param>
		void OnAddedToTable(Action<Guid> handler);

		/// <summary>
		/// Registers a handler that is called whenever a player is removed from a poker table.
		/// </summary>
		/// <param name="handler">The handler delegate.</param>
		void OnRemovedFromTable(Action<Guid> handler);

		/// <summary>
		/// Registers a handler that is called whenever a player has voted succesfully.
		/// </summary>
		/// <param name="handler">The handler delegate.</param>
		void OnVoteCasted(Action<int> handler);
	}
}
