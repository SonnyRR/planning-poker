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

		public void Dispose() => this.TableState.StateChanged -= this.StateHasChanged;

		/// <summary>
		/// Handles invalid form submits.
		/// </summary>
		/// <param name="args">The invalid submit event arguments.</param>
		public void OnInvalidSubmit(FormInvalidSubmitEventArgs args)
		{
			var json = JsonSerializer.Serialize(args, new JsonSerializerOptions() { WriteIndented = true });
			this.Logger.LogInformation("Invalid Submit", json);
			this.Dispatcher.Dispatch(new PokerTableUnsuccessfulSubmitAction(json));
		}

		/// <summary>
		/// Handles valid form submits.
		/// </summary>
		/// <param name="bindingModel">The binding model.</param>
		public void OnSubmit(TableBindingModel bindingModel)
		{
			this.Logger.LogInformation("Valid Submit");
			this.Dispatcher.Dispatch(new PokerTableSubmitAction(bindingModel));
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			this.TableState.StateChanged += this.StateHasChanged;
		}

		private void StateHasChanged(object sender, EventArgs e)
		{
			this.NavigationManager.NavigateTo($"/table/{this.TableState.Value.Table.Id}");
		}
	}
}
