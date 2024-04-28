namespace PlanningPoker.Client.Features.PokerTable.Store.VotingRound
{
    using PlanningPoker.SharedKernel.Models.Generated;
    
    public class VotingRoundStates
    {
        public record VotingRoundCreationState
        {
            public bool Submitting { get; init; }

            public bool Submitted { get; init; }

            public string ErrorMessage { get; init; }
        }

        public record VotingRoundsState
        {
            public bool IsInitialized { get; init; }

            public bool IsLoading { get; init; }

            public RoundModel[] Rounds { get; init; }
        }
    }
}
