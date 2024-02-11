namespace PlanningPoker.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RoundConfiguration : IEntityTypeConfiguration<Round>
    {
        public void Configure(EntityTypeBuilder<Round> builder)
        {
            builder
                .HasOne(r => r.Table)
                .WithMany(t => t.Rounds)
                .HasForeignKey(r => r.TableId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(r => r.Description)
                .IsUnicode()
                .HasMaxLength(512);
            
            builder.Ignore(r => r.Elapsed);
        }
    }
}
