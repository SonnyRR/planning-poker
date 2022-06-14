namespace PlanningPoker.SharedKernel.Models.Tables
{
	using System;

	/// <summary>
	/// Represents a player's estimation vote.
	/// </summary>
	public record PlayerVote
	{
		public int Estimation { get; init; }

		public Guid TableId { get; set; }

		public Guid PlayerId { get; set; }
	}
}
