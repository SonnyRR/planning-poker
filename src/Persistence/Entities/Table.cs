namespace PlanningPoker.Persistence.Entities
{
	using System;
	using System.Collections.Generic;

	/// <summary>
	/// Represents a poker table.
	/// </summary>
	public sealed class Table : BaseEntity<Guid>
	{
		public Table()
		{
		}

		public Table(string name, Deck deck, Guid ownerId)
		{
			this.Name = name;
			this.DeckId = deck.Id;
            this.Deck = deck;
			this.OwnerId = ownerId;
		}

		/// <summary>
		/// The card deck.
		/// </summary>
		public Deck Deck { get; set; }

		/// <summary>
		/// The card deck's unique identifier.
		/// </summary>
		public Guid DeckId { get; set; }

		/// <summary>
		/// Name of the table.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The table's owner.
		/// </summary>
		public User Owner { get; set; }

		/// <summary>
		/// The tables' owner unique identifier.
		/// </summary>
		public Guid OwnerId { get; set; }

		/// <summary>
		/// The card players.
		/// </summary>
		public IList<User> Players { get; set; } = new List<User>();

        /// <summary>
        /// The voting rounds.
        /// </summary>
        public IList<Round> Rounds { get; set; } = new List<Round>();
	}
}
