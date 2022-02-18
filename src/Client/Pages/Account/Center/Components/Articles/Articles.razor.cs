using System.Collections.Generic;
using PlanningPoker.Models;
using Microsoft.AspNetCore.Components;

namespace PlanningPoker.Pages.Account.Center
{
    public partial class Articles
    {
        [Parameter] public IList<ListItemDataType> List { get; set; }
    }
}