namespace PlanningPoker.Client
{
	using Microsoft.AspNetCore.Components;
	using System;

	[EventHandler("ontransitionend", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: false)]
	[EventHandler("onanimationend", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: false)]
	public static class EventHandlers
	{
	}
}
