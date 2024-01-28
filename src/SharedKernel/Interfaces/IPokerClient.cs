namespace PlanningPoker.SharedKernel.Interfaces
{
	using PlanningPoker.SharedKernel.Models.Tables;
	using System;
	using System.Threading.Tasks;

	public interface IPokerClient
	{
		/// <summary>
		/// Sends a new message that adds a player to a poker table.
		/// </summary>
		/// <param name="playerMetadata">The player metadata.</param>
		Task AddedToTable(PlayerJoined playerMetadata);

		/// <summary>
		/// Sends a new message that removes a player from a poker table.
		/// </summary>
		/// <param name="tableId">The poker table's unique identifier value.</param>
		Task RemovedFromTable(Guid tableId);

		/// <summary>
		/// Sends a new message that a player has voted on a work item.
		/// </summary>
		/// <param name="vote">The player's vote</param>
		Task VoteCasted(PlayerVote vote);

        Task VotingRoundStarted(Guid tableId);
	}
}
