namespace PlanningPoker.Persistence
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using PlanningPoker.Persistence.Entities;
    using PlanningPoker.Persistence.Extensions;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public sealed class PlanningPokerDbContext : IdentityDbContext<User, Role, Guid>
    {
        public PlanningPokerDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }

        public DbSet<DeckCard> DeckCards { get; set; }

        public DbSet<Deck> Decks { get; set; }

        public DbSet<Table> Tables { get; set; }

        public DbSet<Round> Rounds { get; set; }

        public DbSet<Vote> Votes { get; set; }

        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Necessary for Identity models configuration.
            base.OnModelCreating(builder);

            builder.RemoveIdentityTablesPrefix();
            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditableEntity &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditableEntity)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTimeOffset.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTimeOffset.UtcNow;
                }
            }
        }
    }
}