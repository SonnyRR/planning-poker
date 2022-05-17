namespace PlanningPoker.Persistence
{
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;

	using PlanningPoker.Persistence.Entities;
	using PlanningPoker.Persistence.Extensions;

	public sealed class PlanningPokerDbContext : IdentityDbContext<User, Role, Guid>
	{
		public PlanningPokerDbContext(DbContextOptions options)
			: base(options)
		{
		}

		public DbSet<Table> Tables { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			// Necessary for Identity models configuration.
			base.OnModelCreating(builder);

			builder.RemoveIdentityTablesPrefix();
			builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
		}
	}
}
