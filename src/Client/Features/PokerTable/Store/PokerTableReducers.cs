namespace PlanningPoker.Client.Features.PokerTable.Store
{
	using Actions;
	using Fluxor;
	using System;

	public static class PokerTableReducers
	{
		[ReducerMethod(typeof(PokerTableCreationAction))]
		public static PokerTableCreationState OnCreation(PokerTableCreationState state)
			=> state with
			{
				Submitting = true
			};

		[ReducerMethod]
		public static PokerTableState OnSet(PokerTableState state, PokerTableSetAction action)
			=> state with
			{
				Table = action.Table,
				IsLoading = false
			};

		[Obsolete("Deprecated")]
		[ReducerMethod(typeof(PokerTableSetInitializedAction))]
		public static PokerTableState OnSetInitialized(PokerTableState state)
			=> state with
			{
				IsInitialized = true
			};

		[ReducerMethod(typeof(PokerTableSetLoadingAction))]
		public static PokerTableState OnSetLoading(PokerTableState state)
			=> state with
			{
				IsLoading = true
			};

		[ReducerMethod(typeof(PokerTableSuccessfulCreationAction))]
		public static PokerTableCreationState OnSuccessfulCreation(PokerTableCreationState state)
			=> state with
			{
				Submitting = false,
				Submitted = true
			};

		[ReducerMethod]
		public static PokerTableCreationState OnUnsuccessfulCreation(
			PokerTableCreationState state, PokerTableUnsuccessfulCreationAction action)
			=> state with
			{
				Submitting = false,
				Submitted = true,
				ErrorMessage = action.ErrorMessage
			};
	}
}
