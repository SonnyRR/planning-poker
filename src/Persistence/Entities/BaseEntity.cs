using System.ComponentModel.DataAnnotations;

namespace PlanningPoker.Persistence.Entities
{
    public class BaseEntity<TKey> : IAuditableEntity
        where TKey : struct, IComparable<TKey>, IEquatable<TKey>
    {
        public DateTimeOffset CreatedOn { get; set; }

        [Key]
        public TKey Id { get; set; }

        public DateTimeOffset? ModifiedOn { get; set; }
    }
}
