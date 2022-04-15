using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

using PlanningPoker.Client.Models;

namespace PlanningPoker.Client.Pages
{
    public partial class CreateTable
    {
        [Inject]
        public ILogger<CreateTable> Logger { get; set; }

        public TableMetadata Table { get; set; } = new();
    }
}
