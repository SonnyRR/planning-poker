﻿namespace PlanningPoker.Persistence.Entities
{
	using PlanningPoker.SharedKernel.Models.Decks;

	using System;
	using System.Collections.Generic;

	/// <summary>
	/// Represents a poker table.
	/// </summary>
	public sealed class Table : BaseEntity<Guid>
	{
		/// <summary>
		/// The card deck type.
		/// </summary>
		public DeckType DeckType { get; set; }

		/// <summary>
		/// Name of the table.
		/// </summary>
		public int Name { get; set; }

		/// <summary>
		/// The card players.
		/// </summary>
		public ICollection<User> Players { get; set; } = new List<User>();
	}
}
