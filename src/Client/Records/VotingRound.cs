using PlanningPoker.Generated.Models;
using System.Collections.Generic;
using System.Linq;

namespace PlanningPoker.Client
{
    public record VotingRound
    {
        public bool HasFinished { get; init; }

        public IDictionary<string, CardModel> Votes { get; init; } = new Dictionary<string, CardModel>();

        public float Average => this.Votes.Values.Select(v => v.Value).Average();
    }
}