using Ardalis.GuardClauses;

using CorrelationId.DependencyInjection;

using Microsoft.Extensions.DependencyInjection;

using PlanningPoker.SharedKernel.Enrichers;

namespace PlanningPoker.SharedKernel.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSharedKernelServices(this IServiceCollection services)
        {
            Guard.Against.Null(services, nameof(services));

            services.AddScoped<CorrelationIdEnricher>();
            services.AddDefaultCorrelationId(cfg =>
            {
                cfg.IncludeInResponse = true;
                cfg.UpdateTraceIdentifier = true;
                cfg.AddToLoggingScope = true;
                cfg.CorrelationIdGenerator = () => Guid.NewGuid().ToString();
            });

            return services;
        }
    }
}
