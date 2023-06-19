namespace PlanningPoker.Client.Features.PokerTable.Pages
{
    using System;
    using System.Threading.Tasks;
    using Clients;
    using Fluxor;
    using Microsoft.AspNetCore.Components;
    using Microsoft.Extensions.Logging;
    using SharedKernel.Models.Tables;
    using Store;
    using Store.Actions;
    using static Constants;

    public partial class PokerTable : IDisposable
    {
        /// <summary>
        /// The fluxor action subscriber.
        /// </summary>
        [Inject]
        public IActionSubscriber ActionSubscriber { get; set; }

        /// <summary>
        /// The fluxor action dispatcher.
        /// </summary>
        [Inject]
        public IDispatcher Dispatcher { get; set; }

        /// <summary>
        /// The unique identifier of the poker table.
        /// </summary>
        [Parameter]
        public Guid Id { get; set; }

        /// <summary>
        /// The logger for this component.
        /// </summary>
        [Inject]
        public ILogger<PokerTable> Logger { get; set; }

        /// <summary>
        /// The SignalR client for interacting with poker tables.
        /// </summary>
        [Inject]
        public IPokerSignalRClient PokerClient { get; set; }

        /// <summary>
        /// The poker table's state.
        /// </summary>
        [Inject]
        public IState<PokerTableState> TableState { get; set; }

        /// <summary>
        /// The route navigation manager.
        /// </summary>
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispatches an action with the player's vote.
        /// </summary>
        public async Task Vote()
            => await this.PokerClient.VoteCasted(new PlayerVote { Estimation = 3, TableId = this.Id });

        /// <summary>
        /// Leaves the current poker table.
        /// </summary>
        public async Task Leave()
        {
            await this.PokerClient.RemovedFromTable(this.TableState.Value.Table.Id);
            this.NavigationManager.NavigateTo(Routes.INDEX);
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
                await this.PokerClient.AddedToTable(this.TableState.Value.Table.Id);
                return;
            }

            // ReSharper disable once AsyncVoidLambda
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
                
                this.StateHasChanged();
            });
        }

        private void StateHasChanged(object sender, EventArgs args)
            => this.InvokeAsync(this.StateHasChanged);
    }
}