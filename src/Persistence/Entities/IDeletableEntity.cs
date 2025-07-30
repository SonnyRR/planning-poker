namespace PlanningPoker.Persistence.Entities
{
    using System;

    public interface IDeletableEntity
    {
        DateTimeOffset? DeletedOn { get; set; }

        bool IsDeleted { get; set; }
    }
}
