namespace PlanningPoker.Client.Features.PokerTable.Pages
{
	using Fluxor;
	using Microsoft.AspNetCore.Components;
	using Microsoft.Extensions.Logging;
	using PlanningPoker.Client.Clients;
	using PlanningPoker.Client.Features.PokerTable.Store.Actions;
	using PlanningPoker.SharedKernel.Models.Tables;
	using Store;
	using System;
	using System.Threading.Tasks;

	public partial class PokerTable : IDisposable
	{
		private bool isTablePresent;
		private string messageInput;
		private string userInput;

		[Inject]
		public IActionSubscriber ActionSubscriber { get; set; }

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

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		public async Task Vote()
		{
			await this.PokerClient.VoteCasted(new PlayerVote { Estimation = 3, TableId = this.Id });
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.TableState.StateChanged -= this.StateHasChanged;
				this.ActionSubscriber.UnsubscribeFromAllActions(this);
			}
		}
		protected override async Task OnInitializedAsync()
		{
			this.TableState.StateChanged += this.StateHasChanged;
			this.isTablePresent = this.Id == this.TableState.Value.Table.Id;

			this.LoadTableIfMissing();

			this.RegisterHubMethodHandlers();
			await this.PokerClient.Start();

			await this.JoinPokerTable();
		}

		private async Task JoinPokerTable()
		{
			if (this.isTablePresent)
			{
				this.Logger.LogWarning("Table is present in store, attempting to add user.");
				await this.PokerClient.AddedToTable(this.TableState.Value.Table.Id);
				return;
			}

			this.ActionSubscriber.SubscribeToAction<PokerTableSetAction>(this, async action =>
			{
				if (action.Table is not null && action.Table.Id != Guid.Empty)
				{
					this.Logger.LogDebug("Table was missing from store and loaded explicitly, attempting to add user.");
					await this.PokerClient.AddedToTable(this.TableState.Value.Table.Id);
					return;
				}

				this.Logger.LogWarning("Cannot join poker table with ID: '{id}'", this.Id);
			});
		}

		/// <summary>
		/// Loads a given poker table by ID if it wasn't loaded before.
		/// </summary>
		private void LoadTableIfMissing()
		{
			if (!this.isTablePresent)
			{
				this.Logger.LogDebug("Table is not present in the store, attemting to load: '{id}'.", this.Id);
				this.Dispatcher.Dispatch(new PokerTableLoadAction(this.Id));
			}
		}

		/// <summary>
		/// Registers handlers for hub methods.
		/// </summary>
		private void RegisterHubMethodHandlers()
		{
			this.PokerClient.OnAddedToTable(id => this.Logger.LogError("Successfully joined tabe: {id}.", id));

			this.PokerClient.OnVoteCasted((vote) =>
			{
				this.Logger.LogInformation("Voted: {vote} in table {id}", vote.Estimation, vote.TableId);
				this.StateHasChanged();
			});
		}

		private void StateHasChanged(object sender, EventArgs args)
			=> this.InvokeAsync(this.StateHasChanged);
	}
}
