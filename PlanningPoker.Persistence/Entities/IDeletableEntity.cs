namespace PlanningPoker.Persistence.Entities
{
    public interface IDeletableEntity
    {
        DateTimeOffset? DeletedOn { get; set; }

        bool IsDeleted { get; set; }
    }
}
