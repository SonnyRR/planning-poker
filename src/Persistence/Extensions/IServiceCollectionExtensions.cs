namespace PlanningPoker.Persistence.Extensions
{
    using Ardalis.GuardClauses;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;

    using PlanningPoker.SharedKernel.Models.Configuration;

    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services)
        {
            Guard.Against.Null(services, nameof(services));

            using var serviceProvider = services.BuildServiceProvider();

            var applicationOptions = serviceProvider.GetService<IOptions<PlanningPokerOptions>>()?.Value;
            Guard.Against.Null(applicationOptions, nameof(applicationOptions));
            Guard.Against.NullOrEmpty(applicationOptions.ConnectionStrings.Database, nameof(applicationOptions.ConnectionStrings.Database));

            services.AddDbContext<PlanningPokerDbContext>(options =>
            {
                options.UseSqlServer(applicationOptions.ConnectionStrings.Database);
                options.UseOpenIddict();
            });

            Guard.Against.NullOrEmpty(applicationOptions.ConnectionStrings.Redis, nameof(applicationOptions.ConnectionStrings.Redis));
            services.AddSingleton(async x => await RedisConnection.InitializeAsync(applicationOptions.ConnectionStrings.Redis));

            return services;
        }
    }
}