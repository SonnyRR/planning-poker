namespace PlanningPoker.Persistence.Entities;

using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Identity;

public sealed class User : IdentityUser<Guid>, IDeletableEntity
{
    public DateTimeOffset? DeletedOn { get; set; }

    public bool IsDeleted { get; set; }

    public IList<Table> Tables { get; set; } = [];
}
