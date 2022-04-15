using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using Blazored.LocalStorage;

using FluentValidation;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

using PlanningPoker.Client.Models;
using PlanningPoker.SharedKernel.Extensions;

using Radzen;

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
                builder.Services.AddScoped<DialogService>();
                builder.Services.AddScoped<NotificationService>();
                builder.Services.AddScoped<TooltipService>();
                builder.Services.AddScoped<ContextMenuService>();

                builder.Services.AddValidatorsFromAssemblyContaining<TableMetadataValidator>();

                builder.Services.AddBlazoredLocalStorage(config =>
                {
                    config.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                    config.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    config.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    config.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
                    config.JsonSerializerOptions.WriteIndented = false;
                });

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