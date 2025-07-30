namespace PlanningPoker.Client.Features.PokerTable.Store.VotingRound
{
    using Fluxor;
    using static VotingRoundStates;

    public static class VotingRoundReducers
    {
        [ReducerMethod]
        public static VotingRoundsState OnSet(VotingRoundsState state, SetVotingRoundAction action)
            => state with
            {
                Rounds = [.. state.Rounds, action.Round],
                IsLoading = false
            };
    }
}
