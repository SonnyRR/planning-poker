namespace PlanningPoker.Persistence.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;

    public sealed class User : IdentityUser<Guid>, IDeletableEntity
    {
        public DateTimeOffset? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public IList<Table> Tables { get; set; } = new List<Table>();
    }
}