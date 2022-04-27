using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PlanningPoker.Identity.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return this.View();
    }

    public IActionResult Privacy()
    {
        return this.View();
    }

    public IActionResult Error()
    {
        return this.View();
    }
}
