using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PlanningPoker.OIDC.Models.View
{
    public sealed class LogoutViewModel
    {
        [BindNever]
        public string RequestId { get; set; }
    }
}
