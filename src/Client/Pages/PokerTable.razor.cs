namespace PlanningPoker.Client.Pages
{
	using Fluxor;
	using Fluxor.Blazor.Web.Components;
	using Microsoft.AspNetCore.Components;
	using Microsoft.AspNetCore.SignalR.Client;
	using PlanningPoker.Client.Store.PokerTableUseCase;
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public sealed partial class PokerTable : IAsyncDisposable
	{
		private readonly List<string> messages = new();
		private HubConnection hubConnection;
		private string messageInput;
		private string userInput;

		public Guid Id { get; set; }

		public bool IsConnected => this.hubConnection?.State == HubConnectionState.Connected;

		[Inject]
		public NavigationManager NavigationManager { get; set; }

		[Inject]
		public IState<PokerTableState> TableState { get; set; }

		public async ValueTask DisposeAsync()
		{
			if (this.hubConnection is not null)
			{
				await this.hubConnection.DisposeAsync();
			}
		}

		//public override async Task OnInitializedAsync()
		//{
		//	this.hubConnection = new HubConnectionBuilder()
		//		.WithUrl(this.NavigationManager.ToAbsoluteUri("/poker"))
		//		.Build();

		//	this.hubConnection.On<string>("AddedToTable", (name) =>
		//	{
		//		var encodedMsg = $"User has been added to: {name}";
		//		this.messages.Add(encodedMsg);
		//		this.StateHasChanged();
		//	});

		//	await this.hubConnection.StartAsync();
		//}

		private async Task Send()
		{
			if (this.hubConnection is not null)
			{
				await this.hubConnection.SendAsync("AddToTable", this.userInput);
			}
		}
	}
}
