using System;
using System.Collections.Generic;
using PlanningPoker.SharedKernel.Models.Decks;
using PlanningPoker.SharedKernel.Models.Generated;

namespace PlanningPoker.SharedKernel.Models.Generated
{
    public partial class TableModel
    {
        public DeckType DeckType { get; set; }
        public string Name { get; set; }
        public UserModel Owner { get; set; }
        public Guid OwnerId { get; set; }
        public IList<UserModel> Players { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public Guid Id { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
    }
}