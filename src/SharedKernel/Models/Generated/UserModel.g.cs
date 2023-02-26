using System;
using System.Collections.Generic;
using PlanningPoker.SharedKernel.Models.Generated;

namespace PlanningPoker.SharedKernel.Models.Generated
{
    public partial class UserModel
    {
        public IList<TableModel> Tables { get; set; }
        public Guid Id { get; set; }
        public string UserName { get; set; }
    }
}
