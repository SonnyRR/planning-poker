namespace PlanningPoker.Persistence.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PlanningPoker.Persistence.Entities;
    using PlanningPoker.SharedKernel.Models.Decks;
    using System;
    using static Constants;

    public sealed class DeckConfiguration : IEntityTypeConfiguration<Deck>
    {
        public void Configure(EntityTypeBuilder<Deck> builder)
        {
            builder.Property(d => d.Type)
                .HasConversion<string>()
                .IsRequired();

            builder.HasIndex(d => d.Type)
                .IsUnique();

            builder.HasData(
                new Deck
                {
                    Id = Guid.Parse("6df8d39e-267d-4396-9e41-fa969fe3e9d9"),
                    Type = DeckType.Fibonacci,
                    CreatedOn = new DateTimeOffset(2024, 9, 7, 21, 22, 49, TimeSpan.Zero)
                }
            );

            builder
                .HasMany(d => d.Cards)
                .WithMany(c => c.Decks)
                .UsingEntity<DeckCard>(
                    e => e
                        .HasOne(x => x.Card)
                        .WithMany()
                        .HasForeignKey(e => e.CardId),
                    e => e
                        .HasOne(x => x.Deck)
                        .WithMany()
                        .HasForeignKey(e => e.DeckId),
                    e =>
                    {
                        e.HasKey(x => (new { x.CardId, x.DeckId }));
                        e.HasData(
                            new DeckCard
                            {
                                CardId = C0_ID,
                                DeckId = Guid.Parse("6df8d39e-267d-4396-9e41-fa969fe3e9d9")
                            },
                            new DeckCard
                            {
                                CardId = C1_ID,
                                DeckId = Guid.Parse("6df8d39e-267d-4396-9e41-fa969fe3e9d9")
                            },
                            new DeckCard
                            {
                                CardId = C2_ID,
                                DeckId = Guid.Parse("6df8d39e-267d-4396-9e41-fa969fe3e9d9")
                            },
                            new DeckCard
                            {
                                CardId = C3_ID,
                                DeckId = Guid.Parse("6df8d39e-267d-4396-9e41-fa969fe3e9d9")
                            },
                            new DeckCard
                            {
                                CardId = C5_ID,
                                DeckId = Guid.Parse("6df8d39e-267d-4396-9e41-fa969fe3e9d9")
                            },
                            new DeckCard
                            {
                                CardId = C8_ID,
                                DeckId = Guid.Parse("6df8d39e-267d-4396-9e41-fa969fe3e9d9")
                            },
                            new DeckCard
                            {
                                CardId = C13_ID,
                                DeckId = Guid.Parse("6df8d39e-267d-4396-9e41-fa969fe3e9d9")
                            },
                            new DeckCard
                            {
                                CardId = C21_ID,
                                DeckId = Guid.Parse("6df8d39e-267d-4396-9e41-fa969fe3e9d9")
                            },
                            new DeckCard
                            {
                                CardId = C34_ID,
                                DeckId = Guid.Parse("6df8d39e-267d-4396-9e41-fa969fe3e9d9")
                            },
                            new DeckCard
                            {
                                CardId = C55_ID,
                                DeckId = Guid.Parse("6df8d39e-267d-4396-9e41-fa969fe3e9d9")
                            },
                            new DeckCard
                            {
                                CardId = C89_ID,
                                DeckId = Guid.Parse("6df8d39e-267d-4396-9e41-fa969fe3e9d9")
                            },
                            new DeckCard
                            {
                                CardId = CQ_ID,
                                DeckId = Guid.Parse("6df8d39e-267d-4396-9e41-fa969fe3e9d9")
                            }
                        );
                    }
                );
        }
    }
}