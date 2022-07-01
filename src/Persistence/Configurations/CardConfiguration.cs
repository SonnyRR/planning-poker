namespace PlanningPoker.Persistence.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using PlanningPoker.Persistence.Entities;
	using System;

	public class CardConfiguration : IEntityTypeConfiguration<Card>
	{
		public void Configure(EntityTypeBuilder<Card> builder)
		{
			builder.Property(c => c.UnicodeValue)
				.IsUnicode()
				.HasMaxLength(1)
				.IsRequired();

			builder.HasIndex(c => c.UnicodeValue)
				.IsUnique();

			builder.Property(c => c.Value)
				.HasDefaultValue(0);

			builder.HasData(new[]
			{
				new Card(1, '1') { Id = Guid.Parse("92242626-dbf5-4888-8876-66cb9d088e02"), CreatedOn = DateTimeOffset.UtcNow },
				new Card(2, '2') { Id = Guid.Parse("911bdb42-7f5f-4431-9d11-95d63672edd9"), CreatedOn = DateTimeOffset.UtcNow },
				new Card(3, '3') { Id = Guid.Parse("d39ad4fa-3273-47ef-b46c-01ac37588c15"), CreatedOn = DateTimeOffset.UtcNow },
				new Card(5, '5') { Id = Guid.Parse("12278530-7958-436a-a5a4-cf44daaaf95e"), CreatedOn = DateTimeOffset.UtcNow },
				new Card(8, '8') { Id = Guid.Parse("91dc58ae-18f3-49ed-8784-e62348c9d6b1"), CreatedOn = DateTimeOffset.UtcNow }
			});
		}
	}
}
