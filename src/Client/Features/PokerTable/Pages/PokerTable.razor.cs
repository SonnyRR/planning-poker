namespace PlanningPoker.Client.Features.PokerTable.Pages
{
	using Fluxor;
	using Microsoft.AspNetCore.Components;
	using Microsoft.Extensions.Logging;
	using PlanningPoker.Client.Clients;
	using PlanningPoker.Client.Features.PokerTable.Store.Actions;
	using Store;
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public partial class PokerTable : IAsyncDisposable
	{
		private readonly List<string> messages = new();
		private string messageInput;
		private string userInput;

		[Inject]
		public IDispatcher Dispatcher { get; set; }

		[Parameter]
		public Guid Id { get; set; }

		[Inject]
		public ILogger<PokerTable> Logger { get; set; }

		[Inject]
		public IPokerSignalRClient PokerClient { get; set; }

		[Inject]
		public IState<PokerTableState> TableState { get; set; }

		public async ValueTask DisposeAsync()
		{
			this.TableState.StateChanged -= this.StateHasChanged;
		}

		public async Task Vote()
		{
			await this.PokerClient.VoteCasted(3);
		}

		protected override async Task OnInitializedAsync()
		{
			this.TableState.StateChanged += this.StateHasChanged;

			this.LoadTableIfMissing();
			this.RegisterHubMethodHandlers();
			await this.PokerClient.Start();
		}

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
		/// Registers handlers for hub methods.
		/// </summary>
		private void RegisterHubMethodHandlers()
		{
			this.PokerClient.OnVoteCasted((vote) =>
			{
				this.Logger.LogError("WRKING");
				this.StateHasChanged();
			});
		}

		private void StateHasChanged(object sender, EventArgs args)
			=> this.InvokeAsync(this.StateHasChanged);
	}
}
