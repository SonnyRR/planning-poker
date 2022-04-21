
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using PlanningPoker.Persistence.Entities;
using PlanningPoker.Persistence.Extensions;

namespace PlanningPoker.Persistence
{
    public sealed class PlanningPokerContext : IdentityDbContext<User, Role, Guid>
    {
        public PlanningPokerContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Necessary for Identity models configuration.
            base.OnModelCreating(builder);

            builder.RemoveIdentityTablesPrefix();
        }
    }
}
