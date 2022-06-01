using PlanningPoker.SharedKernel.Models.Decks;
using System;
using System.Collections.Generic;

namespace PlanningPoker.SharedKernel.Models.Generated
{
	public partial class TableModel
    {
        public DeckType DeckType { get; set; }
        public string Name { get; set; }
        public ICollection<UserModel> Players { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public Guid Id { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
    }
}
