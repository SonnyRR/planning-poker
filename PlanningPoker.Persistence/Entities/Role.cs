
using Microsoft.AspNetCore.Identity;

namespace PlanningPoker.Persistence.Entities
{
    public sealed class Role : IdentityRole<Guid>, IAuditableEntity, IDeletableEntity
    {
        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTimeOffset? ModifiedOn { get; set; }
    }
}
