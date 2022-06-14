namespace PlanningPoker.Client.Pages
{
	using Ardalis.GuardClauses;
	using Fluxor;
	using Microsoft.AspNetCore.Components;
	using Microsoft.Extensions.Logging;
	using PlanningPoker.Client.Features.PokerTable.Store.Actions;
	using Radzen;

	using SharedKernel.Models.Tables;
	using System;

	public partial class Index
	{
		[Inject]
		public DialogService DialogService { get; set; }

		[Inject]
		public IDispatcher Dispatcher { get; set; }

		[Inject]
		public ILogger<Index> Logger { get; set; }

		[Inject]
		public NavigationManager NavigationManager { get; set; }

		public string RoomId { get; set; }

		public bool ShowRoomIdentifierInput { get; set; }

		public void JoinExistingTable(JoinExistingTableRequest joinTableParameters)
		{
			Guard.Against.Null(joinTableParameters, nameof(joinTableParameters));
			this.Dispatcher.Dispatch(new PokerTableLoadAction(Guid.Parse(joinTableParameters.Code)));
			this.NavigationManager.NavigateTo($"/table/{joinTableParameters.Code}");
		}

		public void OnTableCreationSubmit() => this.NavigationManager.NavigateTo("/create");
	}
}
