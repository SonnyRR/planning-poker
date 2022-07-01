using System;
using System.Collections.Generic;
using PlanningPoker.SharedKernel.Models.Generated;

namespace PlanningPoker.SharedKernel.Models.Generated
{
    public partial class CardModel
    {
        public char UnicodeValue { get; set; }
        public int Value { get; set; }
        public List<DeckModel> Decks { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public Guid Id { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
    }
}