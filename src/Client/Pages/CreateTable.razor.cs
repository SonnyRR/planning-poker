namespace PlanningPoker.Client.Pages
{
	using Microsoft.AspNetCore.Components;
	using Microsoft.Extensions.Logging;
	using PlanningPoker.Client.Records;
	using PlanningPoker.Client.Services;
	using PlanningPoker.SharedKernel.Extensions;
	using PlanningPoker.SharedKernel.Models.Binding;
	using PlanningPoker.SharedKernel.Models.Decks;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	public partial class CreateTable
	{
		[Inject]
		public ILogger<CreateTable> Logger { get; set; }

		[Inject]
		public ITableService TableService { get; init; }

		public TableBindingModel Table { get; set; } = new();

		public static IEnumerable<DropDownEntry<int>> DeckTypeEntries { get; } = Enum
			.GetValues<DeckType>()
			.Select(e => new DropDownEntry<int>(e.GetEnumDisplayName(), (int)e));

		protected override async Task OnInitializedAsync()
		{
			await base.OnInitializedAsync();
			var a = await this.TableService.GetByIdAsync(Guid.Parse("C2599A2F-F634-487A-9F7B-57DCC6927AF4"));
		}
	}
}
