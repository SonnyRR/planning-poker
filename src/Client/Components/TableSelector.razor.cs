namespace PlanningPoker.Client.Components
{
    using Ardalis.GuardClauses;
    using Microsoft.AspNetCore.Components;
    using Microsoft.Extensions.Logging;
    using PlanningPoker.SharedKernel;
    using PlanningPoker.SharedKernel.Models.Tables;

    using Radzen;
    using System.Text.Json;
    using System.Threading.Tasks;

    /// <summary>
    /// Prompts the user to enter an existing poker table room or create a new one.
    /// </summary>
    public partial class TableSelector
    {
        public JoinExistingTableRequest JoinTableParameters { get; set; } = new();

        [Inject]
        public ILogger<TableSelector> Logger { get; init; }

        [Inject]
        public NavigationManager NavigationManager { get; init; }

        [Parameter]
        public EventCallback OnTableCreationCallback { get; set; }

        public bool ShowTableIdentifierInput { get; set; }

        [Parameter]
        public EventCallback<JoinExistingTableRequest> TableIdChanged { get; set; }

        [Inject(Key = nameof(JsonSerializerConfigurations.LoggingSettings))]
        private JsonSerializerOptions LoggingSerializerOptions { get; init; }

        public async Task OnTableCreationSubmit()
        {
            await this.OnTableCreationCallback.InvokeAsync();
        }

        public void OnTableJoinInvalidSubmit(FormInvalidSubmitEventArgs args)
        {
            Guard.Against.Null(args, nameof(args));
            this.Logger.LogError("Invalid Form Submit: {Args}", JsonSerializer.Serialize(args, this.LoggingSerializerOptions));
        }

        public async Task OnTableJoinValidSubmitAsync()
        {
            this.Logger.LogDebug("Attempting to join table {TableId}", this.JoinTableParameters.Code);
            await this.TableIdChanged.InvokeAsync(this.JoinTableParameters);
        }
    }
}
