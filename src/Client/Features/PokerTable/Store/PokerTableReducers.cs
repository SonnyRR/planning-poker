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
		[ReducerMethod(typeof(PokerTableSubmitAction))]
		public static PokerTableSubmissionState OnSubmit(PokerTableSubmissionState state)
			=> state with
			{
				Submitting = true
			};

		[ReducerMethod(typeof(PokerTableSuccessfulSubmitAction))]
		public static PokerTableSubmissionState OnSubmitSuccess(PokerTableSubmissionState state)
			=> state with
			{
				Submitting = false,
				Submitted = true
			};

		[ReducerMethod]
		public static PokerTableSubmissionState OnSubmitSuccess(PokerTableSubmissionState state, PokerTableUnsuccessfulSubmitAction action)
			=> state with
			{
				Submitting = false,
				Submitted = true,
				ErrorMessage = action.ErrorMessage
			};
	}
}
