namespace PlanningPoker.Persistence.Entities
{
	using PlanningPoker.SharedKernel.Models.Decks;

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

		public Table(DeckType deckType, string name, Guid ownerId)
		{
			this.DeckType = deckType;
			this.Name = name;
			this.OwnerId = ownerId;
		}

		/// <summary>
		/// The card deck type.
		/// </summary>
		public DeckType DeckType { get; set; }

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
		public List<User> Players { get; set; } = new List<User>();
	}
}
