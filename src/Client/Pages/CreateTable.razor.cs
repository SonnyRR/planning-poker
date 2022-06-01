namespace PlanningPoker.Client.Pages
{
	using Microsoft.AspNetCore.Components;
	using Microsoft.Extensions.Logging;
	using PlanningPoker.Client.Services;
	using PlanningPoker.SharedKernel.Models.Binding;
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public partial class CreateTable
	{
		[Inject]
		public ILogger<CreateTable> Logger { get; set; }

		[Inject]
		public ITableService TableService { get; init; }

		public TableBindingModel Table { get; set; } = new();

		public IEnumerable<DropdownEntry> TestingValues { get; } = new[]
		{
			new DropdownEntry { A = "A", B = 1 },
			new DropdownEntry { A = "B", B = 2 },
			new DropdownEntry { A = "C", B = 3 },
		};

		protected override async Task OnInitializedAsync()
		{
			await base.OnInitializedAsync();
		}
	}

	public class DropdownEntry
	{
		public string A { get; set; }

		public int B { get; set; }
	}
}
