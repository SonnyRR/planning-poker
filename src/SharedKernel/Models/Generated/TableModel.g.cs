using System;
using System.Collections.Generic;
using PlanningPoker.SharedKernel.Models.Generated;

namespace PlanningPoker.SharedKernel.Models.Generated
{
    public partial class TableModel
    {
        public DeckModel Deck { get; set; }
        public string Name { get; set; }
        public UserModel Owner { get; set; }
        public IList<UserModel> Players { get; set; }
        public IList<RoundModel> Rounds { get; set; }
        public Guid Id { get; set; }
    }
}