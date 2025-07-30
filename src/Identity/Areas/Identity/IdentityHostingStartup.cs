using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(PlanningPoker.Identity.Areas.Identity.IdentityHostingStartup))]
namespace PlanningPoker.Identity.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((_, _) => { });
        }
    }
}
