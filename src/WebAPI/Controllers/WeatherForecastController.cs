namespace PlanningPoker.WebAPI.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using System.Collections.Generic;

	[ApiController]
	[Route("/api/[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		[HttpGet(Name = "GetWeatherForecast")]
		public IEnumerable<string> Get()
		{
			return Summaries;
		}
	}
}
