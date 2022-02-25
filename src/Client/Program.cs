using System;
using System.Net.Http;
using System.Threading.Tasks;

using AntDesign.ProLayout;

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
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Logging.AddSerilog(builder.Configuration);

            builder.RootComponents.Add<App>("#app");

            builder.Services.AddAntDesign();

            builder.Services.Configure<ProSettings>(builder.Configuration.GetSection("AntSettings"));

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder
                .Build()
                .RunAsync();
        }
    }
}