namespace PlanningPoker.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class VoteConfiguration : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder
                .HasOne(v => v.Round)
                .WithMany(r => r.Votes)
                .HasForeignKey(v => v.RoundId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(v => v.Player)
                .WithMany()
                .HasForeignKey(v => v.PlayerId)
                .IsRequired(false);
        }
    }
}