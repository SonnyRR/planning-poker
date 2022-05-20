using System;
using System.Collections.Generic;
using PlanningPoker.SharedKernel.Models;

namespace PlanningPoker.SharedKernel.Models
{
    public partial class UserDto
    {
        public IList<TableDto> Tables { get; set; }
        public Guid Id { get; set; }
        public string UserName { get; set; }
    }
}