namespace PlanningPoker.Client.Features.PokerTable.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Clients;
    using Fluxor;
    using Microsoft.AspNetCore.Components;
    using Microsoft.Extensions.Logging;
    using PlanningPoker.Client.Components;
    using Radzen;
    using SharedKernel.Models.Tables;
    using Store;
    using Store.Actions;
    using static Constants;

    public partial class PokerTable : IDisposable
    {
        [Inject]
        public IActionSubscriber ActionSubscriber { get; set; }

        [Inject]
        public DialogService DialogService { get; set; }

        [Inject]
        public IDispatcher Dispatcher { get; set; }

        [Parameter]
        public Guid Id { get; set; }

        [Inject]
        public ILogger<PokerTable> Logger { get; set; }

        [Inject]
        public IBlazorPokerClient PokerClient { get; set; }

        [Inject]
        public IState<PokerTableState> TableState { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public float VoteValue { get; set; }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispatches an action with the player's vote.
        /// </summary>
        public async Task Vote(float estimation)
            => await this.PokerClient.CastVoteAsync(
                new PlayerVote
                {
                    Estimation = estimation, TableId = this.Id, Timestamp = DateTimeOffset.UtcNow
                });

        /// <summary>
        /// Leaves the current poker table.
        /// </summary>
        public async Task Leave()
        {
            var dialogOptions = new ConfirmOptions
            {
                OkButtonText = "Yes",
                CancelButtonText = "No",
            };

            var exitCofirmed = await this.DialogService
                .Confirm(Table.EXIT_DIALOG_QUESTION, Table.EXIT_DIALOG_TITLE, dialogOptions);

            if (exitCofirmed.GetValueOrDefault())
            {
                await this.PokerClient.RemoveFromTableAsync(this.TableState.Value.Table.Id);
                this.NavigationManager.NavigateTo(Routes.INDEX);
            }
        }

        public async Task StartVotingRound()
        {
            var parameters = new Dictionary<string, object>
            {
                { "Deck", this.TableState.Value.Table.Deck }
            };

            var dialogOptions = new DialogOptions
            {
                Height = "50%",
                Width = "50%"
            };

            // await this.PokerClient.StartVotingRound(this.TableState.Value.Table.Id);
            await this.DialogService.OpenAsync<Round>("Voting Round", parameters, dialogOptions);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            this.TableState.StateChanged -= this.StateHasChanged;
            this.ActionSubscriber.UnsubscribeFromAllActions(this);
        }

        protected override async Task OnInitializedAsync()
        {
            this.TableState.StateChanged += this.StateHasChanged;

            this.RegisterHubMethodHandlers();
            await this.PokerClient.Start();

            this.LoadTableIfMissing();
            await this.JoinPokerTable();
        }

        /// <summary>
        /// Attempts to join the current user to the current poker table.
        /// </summary>
        private async Task JoinPokerTable()
        {
            if (!this.TableState.Value.IsLoading)
            {
                this.Logger.LogDebug("Table is present in the store, attempting to add player.");
                await this.PokerClient.AddToTableAsync(this.TableState.Value.Table.Id);
                return;
            }

            // ReSharper disable once AsyncVoidLambda
            this.ActionSubscriber.SubscribeToAction<PokerTableSetAction>(this, async action =>
            {
                if (action.Table is not null && action.Table.Id != Guid.Empty)
                {
                    this.Logger.LogDebug("Table was missing from store and loaded explicitly, attempting to add user.");
                    await this.PokerClient.AddToTableAsync(this.TableState.Value.Table.Id);
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
            if (this.TableState.Value.Table?.Id == this.Id)
                return;

            this.Logger.LogDebug("Table is not present in the store, attempting to load: '{id}'.", this.Id);
            this.Dispatcher.Dispatch(new PokerTableLoadAction(this.Id));
        }

        /// <summary>
        /// Registers handlers for hub methods.
        /// </summary>
        private void RegisterHubMethodHandlers()
        {
            this.PokerClient.OnAddedToTable(id => this.Logger.LogDebug("Successfully joined table: {id}.", id));

            this.PokerClient.OnVoteCasted((vote) =>
            {
                this.Logger.LogInformation(
                    "{player} voted: {vote} in table {id}", vote.PlayerId, vote.Estimation, vote.TableId);

                this.VoteValue = vote.Estimation;

                this.StateHasChanged(null, null);
            });

            this.PokerClient.OnVotingRoundStarted((id) =>
            {
                this.Logger.LogInformation($"Voting round for table {id} has started.");
            });
        }

        private void StateHasChanged(object sender, EventArgs args)
            => base.StateHasChanged();
    }
}