namespace PlanningPoker.Persistence.Entities
{
	using System;
	using System.Collections.Generic;

	public sealed class Card : BaseDeletableEntity<Guid>
	{
		public Card()
		{
		}

		public Card(float value, string unicodeValue)
		{
			this.Value = value;
			this.UnicodeValue = unicodeValue;
		}

		/// <summary>
		/// The unicode value of the card.
		/// </summary>
		public string UnicodeValue { get; set; }

		/// <summary>
		/// The numeric value of the card.
		/// </summary>
		public float Value { get; set; }

		public List<Deck> Decks { get; set; }
	}
}
