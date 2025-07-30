namespace PlanningPoker.Client.Clients
{
    using PlanningPoker.Generated.Models;
    using PlanningPoker.SharedKernel.Models.Binding;
    using PlanningPoker.SharedKernel.Models.Tables;
    using PlanningPoker.Sockets;
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
        /// Cast a player vote.
        /// </summary>
        /// <param name="vote">The vote metadata.</param>
        Task CastVoteAsync(PlayerVote vote);

        /// <summary>
        /// Creates a voting round.
        /// </summary>
        /// <param name="round">The round's binding model.</param>
        Task CreateVotingRound(RoundBindingModel round);

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
        /// Registers a handler, that is called when a voting round has been created.
        /// </summary>
        /// <param name="handler">The handler delegate.</param>
        void OnVotingRoundCreated(Action<RoundModel> handler);

        /// <summary>
        /// Registers a handler that is called when the table owner has started a new voting session.
        /// </summary>
        /// <param name="handler">The handler delegate.</param>
        void OnVotingRoundStarted(Action<Guid> handler);

        /// <summary>
        /// Remove the currently signed-in player from a poker table.
        /// </summary>
        /// <param name="tableId">The table identifier.</param>
        Task RemoveFromTableAsync(Guid tableId);

        /// <summary>
        /// Starts a new voting round.
        /// </summary>
        /// <param name="tableId">The table identifier.</param>
        Task StartVotingRound(Guid tableId);
    }
}
