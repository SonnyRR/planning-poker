namespace PlanningPoker.Persistence.Entities
{
	using System.ComponentModel.DataAnnotations;

	public class BaseEntity<TKey> : IAuditableEntity
		where TKey : struct, IComparable<TKey>, IEquatable<TKey>
	{
		public DateTimeOffset CreatedOn { get; set; }

		[Key]
		public TKey Id { get; set; }

		public DateTimeOffset? ModifiedOn { get; set; }
	}
}
