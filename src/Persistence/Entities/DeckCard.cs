namespace PlanningPoker.Persistence.Entities
{
    using System;

    public sealed class DeckCard
    {
        public Card Card { get; set; }

        public Guid CardId { get; set; }

        public Deck Deck { get; set; }

        public Guid DeckId { get; set; }
    }
}
