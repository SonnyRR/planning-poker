using System.Collections.Generic;
using PlanningPoker.Models;
using Microsoft.AspNetCore.Components;
using AntDesign;

namespace PlanningPoker.Pages.Account.Center
{
    public partial class Projects
    {
        private readonly ListGridType _listGridType = new ListGridType
        {
            Gutter = 24,
            Column = 4
        };

        [Parameter]
        public IList<ListItemDataType> List { get; set; }
    }
}