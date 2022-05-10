namespace PlanningPoker.Client
{
	using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

	using PlanningPoker.Client.Extensions;
	using PlanningPoker.SharedKernel.Extensions;

	using Serilog;

	using System;
	using System.Threading.Tasks;

	public static class Program
	{
		public static async Task Main(string[] args)
		{
			try
			{
				var builder = WebAssemblyHostBuilder.CreateDefault(args);

				builder.Logging.AddSerilog(builder.Configuration);
				builder.RootComponents.Add<App>("#app");
				builder.Services.AddClientLayer(builder.HostEnvironment);

				await builder.Build().RunAsync();
			}
			catch (Exception ex)
			{
				if (Log.Logger == null || Log.Logger.GetType().Name == "SilentLogger")
				{
					Log.Logger = new LoggerConfiguration()
						.MinimumLevel.Debug()
						.WriteTo.BrowserConsole()
						.CreateLogger();
				}

				Log.Fatal(ex, "Host terminated unexpectedly");
			}
			finally
			{
				Log.Information("Shut down complete");
				Log.CloseAndFlush();
			}
		}
	}
}
