#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace PlanningPoker.WebAPI
{
    using CorrelationId;
    using Extensions;
    using Hubs;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using PlanningPoker.SharedKernel.Extensions;
    using Serilog;
    using static SharedKernel.Constants.Hubs;

    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCorrelationId();
            app.UseSerilogIngestion();
            app.UseSerilogRequestLogging();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapHub<PokerHub>(POKER_HUB_URI);
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSharedKernelServices();
            services.AddApiServices(this.Configuration);
        }
    }
}
