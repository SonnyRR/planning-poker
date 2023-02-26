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
        public DateTimeOffset? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public Guid Id { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
    }
}
