namespace PlanningPoker.Persistence.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System;

    public sealed class Role : IdentityRole<Guid>, IAuditableEntity, IDeletableEntity
    {
        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTimeOffset? ModifiedOn { get; set; }
    }
}
