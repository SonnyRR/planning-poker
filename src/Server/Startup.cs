using CorrelationId;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using PlanningPoker.BFF.Extensions;
using PlanningPoker.BFF.Hubs;
using PlanningPoker.Persistence.Extensions;
using PlanningPoker.SharedKernel.Extensions;

using Serilog;

namespace PlanningPoker.BFF
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

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
                //app.UseHsts();
            }

            app.UseSecurityHeaders(GetSecurityHeaderPolicy(env.IsDevelopment(), "https://localhost:5001"));
            app.UseHttpsRedirection();
            app.UseCorrelationId();
            app.UseSerilogIngestion();
            app.UseSerilogRequestLogging();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapReverseProxy();
                endpoints.MapHub<PokerHub>("/poker");
                endpoints.MapFallbackToFile("index.html");
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSharedKernelServices();
            services.AddApiServices(this.Configuration);
            services.AddPersistanceServices();
        }

        private static HeaderPolicyCollection GetSecurityHeaderPolicy(bool isDev, string idpHost)
        {
            var policy = new HeaderPolicyCollection()
                .AddFrameOptionsDeny()
                .AddXssProtectionBlock()
                .AddContentTypeOptionsNoSniff()
                .AddReferrerPolicyStrictOriginWhenCrossOrigin()
                .AddCrossOriginOpenerPolicy(builder => builder.SameOrigin())
                .AddCrossOriginResourcePolicy(builder => builder.SameOrigin())
                .AddCrossOriginEmbedderPolicy(builder => builder.RequireCorp())
                .AddContentSecurityPolicy(builder =>
                {
                    builder.AddObjectSrc().None();
                    builder.AddBlockAllMixedContent();
                    builder.AddImgSrc().Self().From("data:");
                    builder.AddFormAction().Self().From(idpHost);
                    builder.AddFontSrc().Self();
                    builder.AddStyleSrc().Self();
                    builder.AddBaseUri().Self();
                    builder.AddFrameAncestors().None();

                    builder.AddScriptSrc()
                        .Self()
                        .WithHash256("v8v3RKRPmN4odZ1CWM5gw80QKPCCWMcpNeOmimNL2AA=")
                        .UnsafeEval();
                });

            if (!isDev)
            {
                policy.AddStrictTransportSecurityMaxAgeIncludeSubDomains(maxAgeInSeconds: 60 * 60 * 24 * 365);
            }

            return policy;
        }
    }
}
