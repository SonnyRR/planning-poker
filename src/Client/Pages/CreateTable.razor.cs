using System.Collections.Generic;

using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

using PlanningPoker.Client.Models;

namespace PlanningPoker.Client.Pages
{
    public class DropdownEntry
    {
        public string A { get; set; }

        public int B { get; set; }
    }

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
}
