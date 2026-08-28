namespace PlanningPoker.Client.Features.PokerTable.Store;

using System;

using Fluxor;

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

#pragma warning disable S1133 // Retained for backward compatibility with existing serialized actions.
    [Obsolete("Deprecated")]
    [ReducerMethod(typeof(PokerTableSetInitializedAction))]
    public static PokerTableState OnSetInitialized(PokerTableState state)
        => state with
        {
            IsInitialized = true
        };
#pragma warning restore S1133

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
