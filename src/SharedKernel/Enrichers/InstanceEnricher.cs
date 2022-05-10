namespace PlanningPoker.SharedKernel.Enrichers
{
	using Serilog.Core;
	using Serilog.Events;

	using System;

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
