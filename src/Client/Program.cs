using System;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

using PlanningPoker.SharedKernel.Extensions;

using Serilog;

namespace PlanningPoker.Client
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                var builder = WebAssemblyHostBuilder.CreateDefault(args);

                builder.Logging.AddSerilog(builder.Configuration);

                builder.RootComponents.Add<App>("#app");

                builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

                await builder
                    .Build()
                    .RunAsync();
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