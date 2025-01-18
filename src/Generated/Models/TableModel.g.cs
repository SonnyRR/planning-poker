using System;
using System.Collections.Generic;
using PlanningPoker.Generated.Models;

namespace PlanningPoker.Generated.Models
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