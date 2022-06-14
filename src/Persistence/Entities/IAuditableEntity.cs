namespace PlanningPoker.Persistence.Entities
{
	using System;

	public interface IAuditableEntity
	{
		DateTimeOffset CreatedOn { get; set; }

		DateTimeOffset? ModifiedOn { get; set; }
	}
}
