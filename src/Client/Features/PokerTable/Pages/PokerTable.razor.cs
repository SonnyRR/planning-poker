namespace PlanningPoker.Client.Features.PokerTable.Pages
{
	using Fluxor;
	using Microsoft.AspNetCore.Components;
	using Microsoft.AspNetCore.SignalR.Client;
	using Microsoft.Extensions.Logging;
	using Store;
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public partial class PokerTable : IAsyncDisposable
	{
		private readonly List<string> messages = new();
		private HubConnection hubConnection;
		private string messageInput;
		private string userInput;

		[Inject]
		public IDispatcher Dispatcher { get; set; }

		[Parameter]
		public Guid Id { get; set; }

		public bool IsConnected => this.hubConnection?.State == HubConnectionState.Connected;

		[Inject]
		public NavigationManager NavigationManager { get; set; }

		[Inject]
		public IState<PokerTableState> TableState { get; set; }

		[Inject]
		public ILogger<PokerTable> Logger { get; set; }

		public async ValueTask DisposeAsync()
		{
			this.TableState.StateChanged -= this.StateHasChanged;

			if (this.hubConnection is not null)
			{
				await this.hubConnection.DisposeAsync();
			}
		}

		protected override async Task OnInitializedAsync()
		{
			this.TableState.StateChanged += this.StateHasChanged;
			this.Logger.LogInformation("WORKING");

			//if (this.Id != this.TableState.Value.Table.Id)
			//{
			//	this.Dispatcher.Dispatch(new PokerTableLoadAction(this.Id));
			//}

			this.hubConnection = new HubConnectionBuilder()
				.WithUrl(this.NavigationManager.ToAbsoluteUri("/poker"))
				.Build();

			this.hubConnection.On<string>("AddedToTable", (name) =>
			{
				var encodedMsg = $"User has been added to: {name}";
				this.messages.Add(encodedMsg);
				this.StateHasChanged();
			});

			await this.hubConnection.StartAsync();

			//await this.hubConnection.SendAsync("AddToTable", this.Id);
		}

		private async Task Send()
		{
			if (this.hubConnection is not null)
			{
				await this.hubConnection.SendAsync("AddToTable", this.userInput);
			}
		}

		private void StateHasChanged(object sender, EventArgs args)
			=> this.InvokeAsync(this.StateHasChanged);
	}
}
