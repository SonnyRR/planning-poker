namespace PlanningPoker.Client.Features.PokerTable.Pages
{
	using Fluxor;
	using Microsoft.AspNetCore.Components;
	using Microsoft.Extensions.Logging;
	using PlanningPoker.Client.Features.PokerTable.Store;
	using PlanningPoker.Client.Features.PokerTable.Store.Actions;
	using PlanningPoker.Client.Records;
	using PlanningPoker.SharedKernel.Extensions;
	using PlanningPoker.SharedKernel.Models.Binding;
	using PlanningPoker.SharedKernel.Models.Decks;
	using Radzen;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text.Json;
	using static Constants;

	public partial class CreateTable : IDisposable
	{
		public static IEnumerable<DropDownEntry<DeckType>> DeckTypeEntries { get; } = Enum
			.GetValues<DeckType>()
			.Select(e => new DropDownEntry<DeckType>(e.GetEnumDisplayName(), e));

		[Inject]
		public IDispatcher Dispatcher { get; set; }

		[Inject]
		public ILogger<CreateTable> Logger { get; set; }

		[Inject]
		public NavigationManager NavigationManager { get; set; }

		public TableBindingModel Table { get; set; } = new();

		[Inject]
		public IState<PokerTableState> TableState { get; set; }

		[Inject]
		public IState<PokerTableCreationState> TableCreationState { get; set; }

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Handles invalid form submits.
		/// </summary>
		/// <param name="args">The invalid submit event arguments.</param>
		public void OnInvalidSubmit(FormInvalidSubmitEventArgs args)
		{
			var json = JsonSerializer.Serialize(args, new JsonSerializerOptions() { WriteIndented = true });
			this.Logger.LogInformation("Invalid Submit", json);
			this.Dispatcher.Dispatch(new PokerTableUnsuccessfulCreationAction(json));
		}

		/// <summary>
		/// Handles valid form submits.
		/// </summary>
		/// <param name="bindingModel">The binding model.</param>
		public void OnSubmit(TableBindingModel bindingModel)
		{
			this.Logger.LogInformation("Valid Submit");
			this.Dispatcher.Dispatch(new PokerTableCreationAction(bindingModel));
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.TableState.StateChanged -= this.StateHasChanged;
			}
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			this.TableState.StateChanged += this.StateHasChanged;
		}

		private void StateHasChanged(object sender, EventArgs e)
		{
			if (!this.TableState.Value.IsLoading)
			{
				this.NavigationManager.NavigateTo($"{Routes.TABLE_PREFIX}/{this.TableState.Value.Table.Id}");
			}
		}
	}
}
