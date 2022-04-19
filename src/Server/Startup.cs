
using System.Collections.Generic;
using System.Net.Mime;

using CorrelationId;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using PlanningPoker.Server.Hubs;
using PlanningPoker.SharedKernel;

using Serilog;

namespace PlanningPoker.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSharedKernelServices();
            services.AddSignalR();
            services.AddResponseCompression(opts =>
                opts.MimeTypes = new List<string>(ResponseCompressionDefaults.MimeTypes)
                {
                    MediaTypeNames.Application.Octet
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseCorrelationId();
            app.UseSerilogIngestion();
            app.UseSerilogRequestLogging();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapHub<PokerHub>("/poker");
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
