using System.Collections.Generic;
using System.Linq;

using PlanningPoker.Generated.Models;

namespace PlanningPoker.Client.Records;

public record VotingRound
{
    public bool HasFinished { get; init; }

    public IDictionary<string, CardModel> Votes { get; init; } = new Dictionary<string, CardModel>();

    public float Average => this.Votes.Values.Select(v => v.Value).Average();
}
