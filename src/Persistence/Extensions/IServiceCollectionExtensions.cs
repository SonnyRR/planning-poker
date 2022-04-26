using Ardalis.GuardClauses;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using PlanningPoker.SharedKernel.Models.Configuration;

namespace PlanningPoker.Persistence.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services)
        {
            Guard.Against.Null(services, nameof(services));

            using var serviceProvider = services.BuildServiceProvider();

            var opts = serviceProvider.GetService<IOptions<PlanningPokerOptions>>()?.Value;
            Guard.Against.Null(opts, nameof(opts));
            Guard.Against.NullOrEmpty(opts.ConnectionStrings.Main, nameof(opts.ConnectionStrings.Main));

            services.AddDbContext<PlanningPokerDbContext>(x => x.UseSqlServer(opts.ConnectionStrings.Main));

            return services;
        }
    }
}
