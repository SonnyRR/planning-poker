namespace PlanningPoker.Client.Store.PokerTableUseCase
{
	using Fluxor;

	public static class PokerTableReducers
	{
		[ReducerMethod()]
		public static PokerTableState OnSet(PokerTableState state, PokerTableSetAction action)
			=> state with
			{
				Table = action.Table
			};
	}
}
