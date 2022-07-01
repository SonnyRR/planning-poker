namespace PlanningPoker.Persistence.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using PlanningPoker.Persistence.Entities;
	using PlanningPoker.SharedKernel.Models.Decks;
	using System;

	public sealed class DeckConfiguration : IEntityTypeConfiguration<Deck>
	{
		public void Configure(EntityTypeBuilder<Deck> builder)
		{
			builder.Property(d => d.Type)
				.HasConversion<string>()
				.IsRequired();

			builder.HasData(new[]
{
				new Deck
				{
					Id = Guid.Parse("6df8d39e-267d-4396-9e41-fa969fe3e9d9"),
					Type = DeckType.Fibonacci,
					CreatedOn = DateTimeOffset.UtcNow
				}
			});

			builder.HasMany(d => d.Cards)
				.WithMany(c => c.Decks)
				.UsingEntity<Entities.DeckCard>(
					e => e
						.HasOne(x => x.Card)
						.WithMany(e => e.DeckCards)
						.HasForeignKey(e => e.CardId),
					e => e
						.HasOne(x => x.Deck)
						.WithMany(e => e.DeckCards)
						.HasForeignKey(e => e.DeckId),
					e =>
					{
						e.HasKey(x => (new { x.CardId, x.DeckId }));
						e.HasData(new[]
						{
							new Entities.DeckCard
							{
								CardId = Guid.Parse("92242626-dbf5-4888-8876-66cb9d088e02"),
								DeckId = Guid.Parse("6df8d39e-267d-4396-9e41-fa969fe3e9d9")
							}
						});
					});
		}
	}
}
