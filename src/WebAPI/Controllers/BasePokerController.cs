namespace PlanningPoker.WebAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Base controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BasePokerController : ControllerBase
    {
    }
}