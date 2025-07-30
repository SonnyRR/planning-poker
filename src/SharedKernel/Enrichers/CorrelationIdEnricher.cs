namespace PlanningPoker.SharedKernel.Enrichers
{
    using CorrelationId.Abstractions;

    using Serilog.Core;
    using Serilog.Events;

    /// <summary>
    /// Enriches the log event with a 'CorrelationId' of the currently processed request.
    /// </summary>
    public class CorrelationIdEnricher : ILogEventEnricher
    {
        private readonly ICorrelationContextAccessor correlationContextAccessor;

        public CorrelationIdEnricher(ICorrelationContextAccessor correlationContextAccessor)
        {
            this.correlationContextAccessor = correlationContextAccessor;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var correlationId = this.correlationContextAccessor.CorrelationContext.CorrelationId;
            logEvent.AddOrUpdateProperty(propertyFactory.CreateProperty("CorrelationId", correlationId));
        }
    }
}
