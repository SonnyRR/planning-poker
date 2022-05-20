using System;
using System.Collections.Generic;
using PlanningPoker.SharedKernel.Models;
using PlanningPoker.SharedKernel.Models.Decks;

namespace PlanningPoker.SharedKernel.Models
{
    public partial class TableDto
    {
        public DeckType DeckType { get; set; }
        public string Name { get; set; }
        public ICollection<UserDto> Players { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public Guid Id { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
    }
}