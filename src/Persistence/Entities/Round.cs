namespace PlanningPoker.Persistence
{
    using System;
    using System.Collections.Generic;
    using PlanningPoker.Persistence.Entities;

    public class Round : BaseEntity<Guid>
    {
        public string Description { get; set; }

        public Guid TableId { get; set; }

        public Table Table { get; set; }

        public float? FinalEstimation { get; set; }

        public DateTimeOffset? StartedOn { get; set; }

        public DateTimeOffset? EndedOn { get; set; }

        public TimeSpan? Elapsed => this.EndedOn?.Subtract(this.StartedOn.GetValueOrDefault());

        public IList<Vote> Votes { get; set; } = new List<Vote>();
    }
}