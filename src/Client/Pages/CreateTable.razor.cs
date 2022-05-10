namespace PlanningPoker.Client.Pages
{
	using Microsoft.AspNetCore.Components;
	using Microsoft.Extensions.Logging;

	using SharedKernel.Models.Tables;

	using System.Collections.Generic;

	public partial class CreateTable
	{
		[Inject]
		public ILogger<CreateTable> Logger { get; set; }

		public TableMetadata Table { get; set; } = new();

		public IEnumerable<DropdownEntry> TestingValues { get; } = new[]
		{
			new DropdownEntry { A = "A", B = 1 },
			new DropdownEntry { A = "B", B = 2 },
			new DropdownEntry { A = "C", B = 3 },
		};
	}

	public class DropdownEntry
	{
		public string A { get; set; }

		public int B { get; set; }
	}
}
