using System;
using System.Collections.Generic;
using PlanningPoker.Core.Models.DTO;

namespace PlanningPoker.Core.Models.DTO
{
    public partial class UserDto
    {
        public IList<TableDto> Tables { get; set; }
        public Guid Id { get; set; }
        public string UserName { get; set; }
    }
}