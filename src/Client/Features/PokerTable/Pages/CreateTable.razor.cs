namespace PlanningPoker.Client.Features.PokerTable.Pages
{
	using Fluxor;
	using Microsoft.AspNetCore.Components;
	using Microsoft.Extensions.Logging;
	using PlanningPoker.Client.Features.PokerTable.Store;
	using PlanningPoker.Client.Features.PokerTable.Store.Actions;
	using PlanningPoker.Client.Records;
	using PlanningPoker.Client.Services;
	using PlanningPoker.SharedKernel.Extensions;
	using PlanningPoker.SharedKernel.Models.Binding;
	using PlanningPoker.SharedKernel.Models.Decks;
	using Radzen;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text.Json;
	using System.Threading.Tasks;

	public partial class CreateTable
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
		public ITableService TableService { get; init; }

		[Inject]
		public IState<PokerTableState> TableState { get; set; }

		/// <summary>
		/// Handles invalid form submits.
		/// </summary>
		/// <param name="args">The invalid submit event arguments.</param>
		public void OnInvalidSubmit(FormInvalidSubmitEventArgs args)
		{
			this.Logger.LogInformation("Invalid Submit", JsonSerializer.Serialize(args, new JsonSerializerOptions() { WriteIndented = true }));
		}

		/// <summary>
		/// Handles valid form submits.
		/// </summary>
		/// <param name="bindingModel">The binding model.</param>
		public async Task OnSubmit(TableBindingModel bindingModel)
		{
			this.Logger.LogInformation("Valid Submit");
			var table = await this.TableService.CreateAsync(bindingModel);
			this.Dispatcher.Dispatch(new PokerTableSetAction(table));

			this.NavigationManager.NavigateTo($"/table/{table.Id}");
		}
	}
}
