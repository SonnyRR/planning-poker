namespace PlanningPoker.WebAPI
{
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.Extensions.Hosting;

	using PlanningPoker.SharedKernel.Extensions;

	using Serilog;

	using System;

	public static class Program
	{
		public static IHostBuilder CreateHostBuilder(string[] args)
			=> Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());

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
	}
}

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
