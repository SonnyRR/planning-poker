using Ardalis.GuardClauses;

using Microsoft.Extensions.Configuration;

using PlanningPoker.SharedKernel.Enrichers;

using Serilog;
using Serilog.Configuration;

namespace PlanningPoker.SharedKernel.Extensions
{
    public static class LoggingExtensions
    {
        public static void Configure(this LoggerConfiguration loggerConfiguration, IConfiguration configuration)
            => loggerConfiguration.ReadFrom.Configuration(configuration, "Logging");

        public static LoggerConfiguration WithInstanceId(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            Guard.Against.Null(enrichmentConfiguration, nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With<InstanceEnricher>();
        }
    }
}
