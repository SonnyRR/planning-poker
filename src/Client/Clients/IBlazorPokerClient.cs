namespace PlanningPoker.Client.Clients
{
	using PlanningPoker.SharedKernel.Models.Tables;
	using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Contract for SignalR clients responsible for managing scrum poker games.
    /// </summary>
    public interface IBlazorPokerClient : ISignalRClient
	{
        /// <summary>
        /// Add the currently signed-in user to a poker table.
        /// </summary>
        /// <param name="tableId">The table identifier.</param>
        Task AddToTableAsync(Guid tableId);

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
		void OnVoteCasted(Action<PlayerVote> handler);

        /// <summary>
        /// Remove the currently signed-in player from a poker table.
        /// </summary>
        /// <param name="tableId">The table identifier.</param>
        Task RemoveFromTableAsync(Guid tableId);

        /// <summary>
        /// Cast a player vote.
        /// </summary>
        /// <param name="vote">The vote metadata.</param>
        Task CastVoteAsync(PlayerVote vote);
	}
}
