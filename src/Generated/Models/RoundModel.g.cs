using System;
using System.Collections.Generic;
using PlanningPoker.Generated.Models;

namespace PlanningPoker.Generated.Models
{
    public partial class RoundModel
    {
        public string Description { get; set; }
        public Guid TableId { get; set; }
        public float? FinalEstimation { get; set; }
        public DateTimeOffset? StartedOn { get; set; }
        public DateTimeOffset? EndedOn { get; set; }
        public TimeSpan? Elapsed { get; set; }
        public IList<VoteModel> Votes { get; set; }
        public Guid Id { get; set; }
    }
}