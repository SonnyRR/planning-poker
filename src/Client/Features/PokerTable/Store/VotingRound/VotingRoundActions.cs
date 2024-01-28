namespace PlanningPoker.Client.Features.PokerTable.Store.VotingRound
{
    using System;

    public class StartVotingRoundAction
    {
        public StartVotingRoundAction(Guid tableId)
            => this.TableId = tableId;

        public Guid TableId { get; init; }
    }
}

