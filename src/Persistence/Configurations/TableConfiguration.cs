namespace PlanningPoker.Persistence.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using PlanningPoker.Persistence.Entities;

	public sealed class TableConfiguration : IEntityTypeConfiguration<Table>
	{
		public void Configure(EntityTypeBuilder<Table> builder)
		{
			builder
				.Property(t => t.Name)
				.IsUnicode()
				.IsRequired()
				.HasMaxLength(150);

			builder
				.Property(t => t.DeckType)
				.HasConversion<string>();

			builder
				.HasMany(t => t.Players)
				.WithMany(p => p.Tables);
		}
	}
}
