namespace PlanningPoker.Persistence
{
    using System;
    using PlanningPoker.Persistence.Entities;

    public class Vote : BaseEntity<Guid>
    {
        public Guid RoundId { get; set; }

        public Round Round { get; set; }
        
        public float Estimation { get; set; }

        public TimeSpan Duration { get; set; }

        public string Username { get; set; }

        public Guid? PlayerId { get; set; }

        public User Player { get; set; }
    }
}
