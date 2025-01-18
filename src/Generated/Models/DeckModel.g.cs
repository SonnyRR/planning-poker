using System;
using System.Collections.Generic;
using PlanningPoker.Generated.Models;
using PlanningPoker.SharedKernel.Models.Decks;

namespace PlanningPoker.Generated.Models
{
    public partial class DeckModel
    {
        public DeckType Type { get; set; }
        public List<CardModel> Cards { get; set; }
        public Guid Id { get; set; }
    }
}