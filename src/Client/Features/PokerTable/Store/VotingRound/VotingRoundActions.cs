﻿namespace PlanningPoker.Client.Features.PokerTable.Store.VotingRound
{
    using System;
    using PlanningPoker.SharedKernel.Models.Binding;
    using PlanningPoker.SharedKernel.Models.Generated;

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

    public class SetVotingRoundLoadingAction
    {
        public SetVotingRoundLoadingAction(bool flag = true) => this.Flag = flag;

        public bool Flag { get; init; }
    }

    public class SetVotingRoundAction
    {
        public SetVotingRoundAction(RoundModel round) => this.Round = round;

        public RoundModel Round { get; init; }
    }
}

