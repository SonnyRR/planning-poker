namespace PlanningPoker.Client.Features.PokerTable.Store.VotingRound
{
    using Fluxor;
    using PlanningPoker.SharedKernel.Models.Generated;
    using System;
    using static VotingRoundStates;

    public static class VotingRoundFeatures
    {
        public class PokerTableCreateFeature : Feature<VotingRoundCreationState>
        {
            public override string GetName() => nameof(VotingRoundCreationState);

            protected override VotingRoundCreationState GetInitialState()
                => new();
        }

        public class PokerTableFeature : Feature<VotingRoundsState>
        {
            public override string GetName() => nameof(VotingRoundsState);

            protected override VotingRoundsState GetInitialState()
                => new() { Rounds = Array.Empty<RoundModel>() };
        }
    }
}