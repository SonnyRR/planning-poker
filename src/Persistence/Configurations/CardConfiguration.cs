namespace PlanningPoker.Persistence.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PlanningPoker.Persistence.Entities;
    using System;
    using static Constants;

    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.Property(c => c.UnicodeValue)
                .IsUnicode()
                .HasMaxLength(4)
                .IsRequired();

            builder.HasIndex(c => c.UnicodeValue)
                .IsUnique();

            builder.Property(c => c.Value)
                .HasDefaultValue(0);

            builder.HasData(
                new Card(0, "0") { Id = C0_ID, CreatedOn = DateTimeOffset.UtcNow },
                new Card(1, "1") { Id = C1_ID, CreatedOn = DateTimeOffset.UtcNow },
                new Card(0.5F, "½") { Id = C1_5_ID, CreatedOn = DateTimeOffset.UtcNow },
                new Card(2, "2") { Id = C2_ID, CreatedOn = DateTimeOffset.UtcNow },
                new Card(3, "3") { Id = C3_ID, CreatedOn = DateTimeOffset.UtcNow },
                new Card(5, "5") { Id = C5_ID, CreatedOn = DateTimeOffset.UtcNow },
                new Card(8, "8") { Id = C8_ID, CreatedOn = DateTimeOffset.UtcNow },
                new Card(13, "13") { Id = C13_ID, CreatedOn = DateTimeOffset.UtcNow },
                new Card(20, "20") { Id = C20_ID, CreatedOn = DateTimeOffset.UtcNow },
                new Card(21, "21") { Id = C21_ID, CreatedOn = DateTimeOffset.UtcNow },
                new Card(34, "34") { Id = C34_ID, CreatedOn = DateTimeOffset.UtcNow },
                new Card(40, "40") { Id = C40_ID, CreatedOn = DateTimeOffset.UtcNow },
                new Card(55, "55") { Id = C55_ID, CreatedOn = DateTimeOffset.UtcNow },
                new Card(80, "80") { Id = C80_ID, CreatedOn = DateTimeOffset.UtcNow },
                new Card(89, "89") { Id = C89_ID, CreatedOn = DateTimeOffset.UtcNow },
                new Card(100, "100") { Id = C100_ID, CreatedOn = DateTimeOffset.UtcNow },
                new Card(1, "XXS") { Id = CXXS_ID, CreatedOn = DateTimeOffset.UtcNow },
                new Card(2, "XS") { Id = CXS_ID, CreatedOn = DateTimeOffset.UtcNow },
                new Card(3, "S") { Id = CS_ID, CreatedOn = DateTimeOffset.UtcNow },
                new Card(5, "M") { Id = CM_ID, CreatedOn = DateTimeOffset.UtcNow },
                new Card(8, "L") { Id = CL_ID, CreatedOn = DateTimeOffset.UtcNow },
                new Card(13, "XL") { Id = CXL_ID, CreatedOn = DateTimeOffset.UtcNow },
                new Card(21, "XXL") { Id = CXXL_ID, CreatedOn = DateTimeOffset.UtcNow },
                new Card(0, "☕") { Id = CC_ID, CreatedOn = DateTimeOffset.UtcNow },
                new Card(0, "?") { Id = CQ_ID, CreatedOn = DateTimeOffset.UtcNow }
            );
        }
    }
}
