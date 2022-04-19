using Serilog.Core;
using Serilog.Events;

namespace PlanningPoker.SharedKernel.Enrichers
{
    public sealed class InstanceEnricher : ILogEventEnricher
    {
        private readonly Guid id;

        public InstanceEnricher()
        {
            this.id = Guid.NewGuid();
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
            => logEvent.AddOrUpdateProperty(propertyFactory.CreateProperty("InstanceId", this.id));
    }
}
