namespace PlanningPoker.Client.Features.PokerTable.Store
{
	using Fluxor;

	public static class PokerTableReducers
	{
		[ReducerMethod]
		public static PokerTableState OnSet(PokerTableState state, PokerTableSetAction action)
			=> state with
			{
				Table = action.Table
			};
	}
}
