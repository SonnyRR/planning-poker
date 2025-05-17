namespace PlanningPoker.BFF.Models.View
{
    using System.ComponentModel.DataAnnotations;

    public sealed class AuthorizeViewModel
    {
        [Display(Name = "Application")]
        public string ApplicationName { get; set; }

        [Display(Name = "Scope")]
        public string Scope { get; set; }
    }
}