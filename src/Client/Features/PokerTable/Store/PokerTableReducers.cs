namespace PlanningPoker.Client.Features.PokerTable.Store
{
	using Actions;
	using Fluxor;

	public static class PokerTableReducers
	{
		[ReducerMethod]
		public static PokerTableState OnSet(PokerTableState state, PokerTableSetAction action)
			=> state with
			{
				Table = action.Table,
				IsLoading = false
			};

		[ReducerMethod(typeof(PokerTableSetLoadingAction))]
		public static PokerTableState OnSetLoading(PokerTableState state)
			=> state with
			{
				IsLoading = true
			};

		[ReducerMethod(typeof(PokerTableSetInitializedAction))]
		public static PokerTableState OnSetInitialized(PokerTableState state)
			=> state with
			{
				IsInitialized = true
			};
	}
}
