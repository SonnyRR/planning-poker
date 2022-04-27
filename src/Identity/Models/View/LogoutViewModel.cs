using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PlanningPoker.Identity.Models.View
{
    public sealed class LogoutViewModel
    {
        [BindNever]
        public string RequestId { get; set; }
    }
}
