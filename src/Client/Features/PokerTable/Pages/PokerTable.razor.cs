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
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public partial class PokerTable : IDisposable
	{
		private readonly List<string> messages = new();
		private string messageInput;
		private string userInput;

		private bool isTablePresent;

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

		[Inject]
		public IActionSubscriber ActionSubscriber { get; set; }

		public void Dispose()
		{
			this.TableState.StateChanged -= this.StateHasChanged;
			this.ActionSubscriber.UnsubscribeFromAllActions(this);
		}

		public async Task Vote()
		{
			await this.PokerClient.VoteCasted(new PlayerVote { Estimation = 3, TableId = this.Id });
		}

		protected override async Task OnInitializedAsync()
		{
			this.TableState.StateChanged += this.StateHasChanged;
			this.isTablePresent = this.Id == this.TableState.Value.Table.Id;

			this.RegisterHubMethodHandlers();
			await this.PokerClient.Start();

			this.LoadTableIfMissing();
			await this.JoinPokerTable();
		}

		private async Task JoinPokerTable()
		{
			if (this.isTablePresent)
			{
				await this.PokerClient.AddedToTable(this.TableState.Value.Table.Id);
				return;
			}

			this.ActionSubscriber.SubscribeToAction<PokerTableSetAction>(this, async action =>
			{
				if (action.Table is not null && action.Table.Id != Guid.Empty)
				{
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
				this.Dispatcher.Dispatch(new PokerTableLoadAction(this.Id));
			}
		}

		/// <summary>
		/// Registers handlers for hub methods.
		/// </summary>
		private void RegisterHubMethodHandlers()
		{
			this.PokerClient.OnAddedToTable(id =>
			{
				this.Logger.LogError("Successfully joined tabe: {id}.", id);
			});

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
