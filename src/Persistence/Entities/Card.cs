namespace PlanningPoker.Persistence.Entities
{
	using System;
	using System.Collections.Generic;

	public sealed class Card : BaseDeletableEntity<Guid>
	{
		public Card()
		{
		}

		public Card(int value, char unicodeValue)
		{
			this.Value = value;
			this.UnicodeValue = unicodeValue;
		}

		/// <summary>
		/// The unicode value of the card.
		/// </summary>
		public char UnicodeValue { get; set; }

		/// <summary>
		/// The numeric value of the card.
		/// </summary>
		public int Value { get; set; }

		public List<Deck> Decks { get; set; }

		public List<DeckCard> DeckCards { get; set; }
	}
}
