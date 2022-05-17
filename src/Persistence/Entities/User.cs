namespace PlanningPoker.Persistence.Entities
{
	using Microsoft.AspNetCore.Identity;

	public sealed class User : IdentityUser<Guid>, IDeletableEntity
	{
		public DateTimeOffset? DeletedOn { get; set; }

		public bool IsDeleted { get; set; }

		public IList<Table> Tables { get; set; } = new List<Table>();
	}
}
