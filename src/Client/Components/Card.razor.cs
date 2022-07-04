namespace PlanningPoker.Client.Components
{
	using Microsoft.AspNetCore.Components;

	public partial class Card
	{
		[Parameter]
		public int UnicodeValue { get; set; }

		[Parameter]
		public int Value { get; set; }
	}
}
