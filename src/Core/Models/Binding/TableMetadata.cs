namespace PlanningPoker.Core.Models.Binding
{
	using PlanningPoker.SharedKernel.Models.Decks;
	using System;

	public sealed class TableMetadata
	{
		public DeckType DeckType { get; set; }

		public Guid? Id { get; set; }

		public string Name { get; set; }
	}
}
