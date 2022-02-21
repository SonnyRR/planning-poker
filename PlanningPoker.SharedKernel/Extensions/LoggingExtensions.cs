﻿using Ardalis.GuardClauses;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using PlanningPoker.SharedKernel.Enrichers;

using Serilog;
using Serilog.Configuration;

namespace PlanningPoker.SharedKernel.Extensions
{
    public static class LoggingExtensions
    {
        const string DEFAULT_LOGGER_CFG_SECTION_NAME = "Serilog";

        /// <summary>
        /// Appies logger configuration from appsettings.json.
        /// </summary>
        /// <param name="loggerConfiguration">The logger configuration.</param>
        /// <param name="configuration">Application configuration.</param>
        /// <param name="configurationSection">The name of the configuration section.</param>
        /// <returns>An instance of <see cref="LoggerConfiguration"/>.</returns>
        public static LoggerConfiguration ConfigureFromSettings(
            this LoggerConfiguration loggerConfiguration, IConfiguration configuration, string configurationSection = DEFAULT_LOGGER_CFG_SECTION_NAME)
        {
            Guard.Against.Null(loggerConfiguration, nameof(loggerConfiguration));
            Guard.Against.Null(configuration, nameof(configuration));
            Guard.Against.NullOrWhiteSpace(configurationSection, nameof(configurationSection));

            return loggerConfiguration.ReadFrom.Configuration(configuration, configurationSection);
        }

        /// <summary>
        /// Adds Serilog with configuration that is read from appsettings.json.
        /// </summary>
        /// <param name="builder">The logger builder.</param>
        /// <param name="configuration">Application configuration.</param>
        /// <param name="configurationSection">The name of the configuration section.</param>
        /// <returns>An instance of <see cref="ILoggingBuilder"/>.</returns>
        public static ILoggingBuilder AddSerilog(
            this ILoggingBuilder builder, IConfiguration configuration, string configurationSection = DEFAULT_LOGGER_CFG_SECTION_NAME)
        {
            Guard.Against.Null(builder, nameof(builder));

            var logger = new LoggerConfiguration()
                .ConfigureFromSettings(configuration, configurationSection)
                .CreateLogger();

            return builder.AddSerilog(logger);
        }

        /// <summary>
        /// Adds the Instace ID enricher to the logger configuration.
        /// </summary>
        /// <param name="enrichmentConfiguration">The logger enrichment configuration.</param>
        /// <returns>An instance of <see cref="LoggerConfiguration"/>.</returns>
        public static LoggerConfiguration WithInstanceId(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            Guard.Against.Null(enrichmentConfiguration, nameof(enrichmentConfiguration));

            return enrichmentConfiguration.With<InstanceEnricher>();
        }
    }
}
