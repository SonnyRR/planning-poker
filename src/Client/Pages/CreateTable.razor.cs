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
		[Inject]
		public ILogger<CreateTable> Logger { get; set; }

		[Inject]
		public ITableService TableService { get; init; }

		public TableBindingModel Table { get; set; } = new();

		public static IEnumerable<DropDownEntry<DeckType>> DeckTypeEntries { get; } = Enum
			.GetValues<DeckType>()
			.Select(e => new DropDownEntry<DeckType>(e.GetEnumDisplayName(), e));

		public async Task OnSubmit(TableBindingModel bindingModel)
		{
			await this.TableService.CreateAsync(bindingModel);
			this.Logger.LogInformation("Valid Submit");
		}

		/// <summary>
		/// Handles invalid form submits.
		/// </summary>
		/// <param name="args"></param>
		public void OnInvalidSubmit(FormInvalidSubmitEventArgs args)
		{
			this.Logger.LogInformation("Invalid Submit", JsonSerializer.Serialize(args, new JsonSerializerOptions() { WriteIndented = true }));
		}
	}
}
