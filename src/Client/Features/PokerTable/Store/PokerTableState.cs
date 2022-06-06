namespace PlanningPoker.Client.Features.PokerTable.Store
{
	using PlanningPoker.SharedKernel.Models.Generated;

	public record PokerTableState
	{
		public bool IsInitialized { get; init; }

		public bool IsLoading { get; init; }

		public TableModel Table { get; init; }
	}
}
