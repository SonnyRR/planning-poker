namespace PlanningPoker.Client.Store.PokerTableUseCase
{
	using PlanningPoker.SharedKernel.Models.Generated;

	public record PokerTableState
	{
		public TableModel Table { get; init; }
	}
}
