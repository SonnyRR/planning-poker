#if !MAPSTER_CONTEXT
namespace PlanningPoker.Sockets
{
    using PlanningPoker.Generated.Models;
    using PlanningPoker.SharedKernel.Models.Tables;
    using System;
    using System.Threading.Tasks;

    public interface IPokerClient
    {
        /// <summary>
        /// Sends a new message that adds a player to a poker table.
        /// </summary>
        /// <param name="playerMetadata">The player metadata.</param>
        Task AddToTable(PlayerJoined playerMetadata);

        /// <summary>
        /// Sends a new message that removes a player from a poker table.
        /// </summary>
        /// <param name="tableId">The poker table's unique identifier value.</param>
        Task RemoveFromTable(Guid tableId);

        /// <summary>
        /// Sends a new message that a player has voted on a work item.
        /// </summary>
        /// <param name="vote">The player's vote</param>
        Task Vote(PlayerVote vote);

        Task StartVotingRound(Guid tableId);

        Task CreateVotingRound(RoundModel round);

        Task DeleteVotingRound(Guid roundId);
    }
}
#endif