using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PlanningPoker.Server.Models.View
{
    public sealed class LogoutViewModel
    {
        [BindNever]
        public string RequestId { get; set; }
    }
}
