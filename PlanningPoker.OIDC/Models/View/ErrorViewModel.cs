using System.ComponentModel.DataAnnotations;

namespace PlanningPoker.OIDC.Models.View
{
    public class ErrorViewModel
    {
        [Display(Name = "Error")]
        public string Error { get; set; }

        [Display(Name = "Description")]
        public string ErrorDescription { get; set; }
    }
}
