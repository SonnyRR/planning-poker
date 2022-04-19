using System;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

using PlanningPoker.SharedKernel.Extensions;

using Serilog;

namespace PlanningPoker.Server
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                CreateHostBuilder(args)
                    .UseSerilog((builderContext, loggerConfig) => loggerConfig.ConfigureFromSettings(builderContext.Configuration))
                    .Build()
                    .Run();
            }
            catch (Exception ex)
            {
                if (Log.Logger == null || Log.Logger.GetType().Name == "SilentLogger")
                {
                    Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .WriteTo.Console()
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

        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}
