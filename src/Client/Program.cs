using System;
using System.Net.Http;
using System.Threading.Tasks;

using AntDesign.ProLayout;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

using PlanningPoker.Services;
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

            builder.Services.Configure<ProSettings>(builder.Configuration.GetSection("ProSettings"));

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IChartService, ChartService>();
            builder.Services.AddScoped<IProjectService, ProjectService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IProfileService, ProfileService>();

            await builder
                .Build()
                .RunAsync();
        }
    }
}