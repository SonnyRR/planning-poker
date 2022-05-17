namespace PlanningPoker.Core.Models.Binding
{
	using PlanningPoker.SharedKernel.Models.Decks;

	public sealed class TableMetadata
	{
		public string Name { get; set; }

		public DeckType DeckType { get; set; }
	}
}
