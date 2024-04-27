using System;
using System.Text.Json;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using PlanningPoker.SharedKernel;
using PlanningPoker.SharedKernel.Models.Binding;
using Radzen;

namespace PlanningPoker.Client.Features.Rounds.Components
{
    public partial class CreateRound
    {
        [Parameter]
        public Guid TableId { get; set; }

        public RoundBindingModel RoundParameters { get; set; } = new();

        [Inject]
        public ILogger<CreateRound> Logger { get; init; }

        [Inject(Key = nameof(JsonSerializerConfigurations.LoggingSettings))]
        private JsonSerializerOptions LoggingSerializerOptions { get; init; }

        [Inject]
        public DialogService DialogService { get; set; }

        protected override void OnInitialized()
        {
            this.RoundParameters.TableId = this.TableId;
            this.Logger.LogDebug(this.RoundParameters.TableId.ToString());
        }

        public void OnRoundCreateInvalidSubmit(FormInvalidSubmitEventArgs args)
        {
            Guard.Against.Null(args, nameof(args));
            this.Logger.LogError("Invalid Form Submit: {Args}", JsonSerializer.Serialize(args, this.LoggingSerializerOptions));
        }

        public async Task OnRoundCreateValidSubmitAsync()
        {
            this.Logger.LogDebug("Attempting to join table {TableId}", this.RoundParameters.Description);
            this.DialogService.Close(true);
            // await this.TableIdChanged.InvokeAsync(this.JoinTableParameters);
        }
    }
}