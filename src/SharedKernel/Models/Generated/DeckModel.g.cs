using System;
using System.Collections.Generic;
using PlanningPoker.SharedKernel.Models.Decks;
using PlanningPoker.SharedKernel.Models.Generated;

namespace PlanningPoker.SharedKernel.Models.Generated
{
    public partial class DeckModel
    {
        public DeckType Type { get; set; }
        public List<CardModel> Cards { get; set; }
        public Guid Id { get; set; }
    }
}