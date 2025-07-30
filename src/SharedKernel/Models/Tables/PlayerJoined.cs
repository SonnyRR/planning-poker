namespace PlanningPoker.SharedKernel.Models.Tables
{
    using System;

    /// <summary>
    /// Represents metadata for a player who joins a poker table.
    /// </summary>
    public class PlayerJoined
    {
        /// <summary>
        /// The player's unique identifier.
        /// </summary>
        /// <value>An instance of <see cref="Guid"/>.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// The player's username.
        /// </summary>
        /// <value>e.g., Galena</value>
        public string Username { get; set; }
    }
}
