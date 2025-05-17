namespace PlanningPoker.SharedKernel.Models.Tables
{
    using System;

    /// <summary>
    /// Represents a player's estimation vote.
    /// </summary>
    public record PlayerVote
    {
        public float Estimation { get; init; }

        public Guid TableId { get; init; }

        public Guid PlayerId { get; set; }

        public DateTimeOffset Timestamp { get; init; }
    }
}