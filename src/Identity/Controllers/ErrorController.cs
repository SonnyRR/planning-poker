namespace PlanningPoker.Identity.Controllers
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Mvc;

    using PlanningPoker.Identity.Models.View;

    public class ErrorController : Controller
    {
        [Route("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // If the error was not caused by an invalid
            // OIDC request, display a generic error page.
            var response = this.HttpContext.GetOpenIddictServerResponse();
            var model = new ErrorViewModel();

            if (response != null)
            {
                model.Error = response.Error;
                model.ErrorDescription = response.ErrorDescription;
            }

            return this.View(model);
        }
    }
}
