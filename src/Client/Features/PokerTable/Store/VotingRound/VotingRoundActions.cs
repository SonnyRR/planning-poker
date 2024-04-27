namespace PlanningPoker.Client.Features.PokerTable.Store.VotingRound
{
    using System;
    using PlanningPoker.SharedKernel.Models.Binding;

    public class StartVotingRoundAction
    {
        public StartVotingRoundAction(Guid tableId)
            => this.TableId = tableId;

        public Guid TableId { get; init; }
    }

    public class CreateVotingRoundAction
    {
        public CreateVotingRoundAction(RoundBindingModel round)
            => this.Round = round;

        public RoundBindingModel Round { get; init; }
    }
}

