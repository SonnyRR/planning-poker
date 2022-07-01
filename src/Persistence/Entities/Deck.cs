namespace PlanningPoker.Persistence.Entities
{
	using PlanningPoker.SharedKernel.Models.Decks;
	using System;
	using System.Collections.Generic;

	public sealed class Deck : BaseDeletableEntity<Guid>
	{
		/// <summary>
		/// The card deck's type.
		/// </summary>
		public DeckType Type { get; set; }

		/// <summary>
		/// The deck's cards.
		/// </summary>
		public List<Card> Cards { get; set; } = new();

		public List<DeckCard> DeckCards { get; set; }
	}
}
