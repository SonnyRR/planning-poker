namespace PlanningPoker.Client.Features.PokerTable.Pages
{
	using Fluxor;
	using Microsoft.AspNetCore.Components;
	using Microsoft.AspNetCore.SignalR.Client;
	using Microsoft.Extensions.Logging;
	using PlanningPoker.Client.Features.PokerTable.Store.Actions;
	using Store;
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using static SharedKernel.Constants.Hubs;

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
		public ILogger<PokerTable> Logger { get; set; }

		[Inject]
		public NavigationManager NavigationManager { get; set; }

		[Inject]
		public IState<PokerTableState> TableState { get; set; }

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

			this.LoadTableIfMissing();
			this.BuildHubConnection();
			this.RegisterHubMethodHandlers();

			await this.hubConnection.StartAsync();
			await this.hubConnection.SendAsync("AddToTable", this.Id);
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

		/// <summary>
		/// Loads a given poker table by ID if it wasn't loaded before.
		/// </summary>
		private void LoadTableIfMissing()
		{
			if (this.Id != this.TableState.Value.Table.Id)
			{
				this.Dispatcher.Dispatch(new PokerTableLoadAction(this.Id));
			}
		}

		/// <summary>
		/// Builds a SignalR hub connection.
		/// </summary>
		private void BuildHubConnection()
		{
			this.hubConnection = new HubConnectionBuilder()
				.WithUrl(this.NavigationManager.ToAbsoluteUri("/poker"))
				.Build();
		}

		/// <summary>
		/// Registers handlers for hub methods.
		/// </summary>
		private void RegisterHubMethodHandlers()
		{
			this.hubConnection.On<string>(ADDED_TO_TABLE_FUNC, (name) =>
			{
				var encodedMsg = $"User has been added to: {name}";
				this.messages.Add(encodedMsg);
				this.StateHasChanged();
			});
		}
	}
}
