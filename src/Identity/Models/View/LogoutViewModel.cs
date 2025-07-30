namespace PlanningPoker.Identity.Models.View
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public sealed class LogoutViewModel
    {
        [BindNever]
        public string RequestId { get; set; }
    }
}
