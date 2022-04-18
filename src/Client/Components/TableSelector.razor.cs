using System.Text.Json;
using System.Threading.Tasks;

using Ardalis.GuardClauses;

using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

using Radzen;

namespace PlanningPoker.Client.Components
{
    /// <summary>
    /// Prompts the user to enter an existing poker table room or create a new one.
    /// </summary>
    public partial class TableSelector
    {
        [Inject]
        public ILogger<TableSelector> Logger { get; set; }

        [Parameter]
        public EventCallback OnTableCreationCallback { get; set; }

        public bool ShowTableIdentifierInput { get; set; }

        public string TableId { get; set; }

        [Parameter]
        public EventCallback<string> TableIdChanged { get; set; }

        public void OnInvalidSubmit(FormInvalidSubmitEventArgs args)
        {
            Guard.Against.Null(args, nameof(args));
            this.Logger.LogError("Invalid Form Submit", JsonSerializer.Serialize(args, new JsonSerializerOptions() { WriteIndented = true }));
        }

        public async Task OnTableCreationSubmit()
        {
            await this.OnTableCreationCallback.InvokeAsync();
        }

        public async Task OnValidSubmitAsync()
        {
            this.Logger.LogDebug("Attempting to join table {TableId}", this.TableId);
            await this.TableIdChanged.InvokeAsync(this.TableId);
        }
    }
}
