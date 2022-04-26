
using Microsoft.AspNetCore.Identity;

namespace PlanningPoker.Persistence.Entities
{
    public sealed class User : IdentityUser<Guid>, IDeletableEntity
    {
        public DateTimeOffset? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
