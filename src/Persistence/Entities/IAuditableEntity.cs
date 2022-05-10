namespace PlanningPoker.Persistence.Entities
{
	public interface IAuditableEntity
	{
		DateTimeOffset CreatedOn { get; set; }

		DateTimeOffset? ModifiedOn { get; set; }
	}
}
