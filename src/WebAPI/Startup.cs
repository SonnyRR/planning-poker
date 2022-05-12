namespace PlanningPoker.WebAPI
{
	using CorrelationId;

	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Hosting;

	using PlanningPoker.SharedKernel.Extensions;
	using PlanningPoker.WebAPI.Extensions;

	using Serilog;

	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}

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

			app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSharedKernelServices();
			services.AddApiServices(this.Configuration);
		}
	}
}
