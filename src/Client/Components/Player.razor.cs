namespace PlanningPoker.Client.Components
{
	using Microsoft.AspNetCore.Components;
	using System;

	public partial class Player
	{
		public bool HasVoted { get; set; }

		[Parameter]
		public string PlayerName { get; set; }

		[Parameter]
		public Guid PlayerId { get; set; }

		public void ChangeMe()
		{

		}
	}
}
