namespace PlanningPoker.Client.Features.PokerTable.Store
{
	using PlanningPoker.SharedKernel.Models.Generated;

	public record PokerTableState
	{
		public TableModel Table { get; init; }
	}
}
