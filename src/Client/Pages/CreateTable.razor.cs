namespace PlanningPoker.Client.Pages
{
	using Microsoft.AspNetCore.Components;
	using Microsoft.Extensions.Logging;
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
		public ILogger<CreateTable> Logger { get; set; }

		[Inject]
		public NavigationManager NavigationManager { get; set; }

		public TableBindingModel Table { get; set; } = new();

		[Inject]
		public ITableService TableService { get; init; }

		/// <summary>
		/// Handles invalid form submits.
		/// </summary>
		/// <param name="args"></param>
		public void OnInvalidSubmit(FormInvalidSubmitEventArgs args)
		{
			this.Logger.LogInformation("Invalid Submit", JsonSerializer.Serialize(args, new JsonSerializerOptions() { WriteIndented = true }));
		}

		public async Task OnSubmit(TableBindingModel bindingModel)
		{
			this.Logger.LogInformation("Valid Submit");
			var table = await this.TableService.CreateAsync(bindingModel);
			this.NavigationManager.NavigateTo($"/table/{table.Id}");
		}
	}
}
