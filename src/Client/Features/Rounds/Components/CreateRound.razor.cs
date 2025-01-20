using Ardalis.GuardClauses;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using PlanningPoker.Client.Clients;
using PlanningPoker.Client.Features.PokerTable.Store.VotingRound;
using PlanningPoker.SharedKernel;
using PlanningPoker.SharedKernel.Models.Binding;
using Radzen;
using System;
using System.Text.Json;

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

        [Inject]
        public IDispatcher Dispatcher { get; set; }

        [Inject]
        public IBlazorPokerClient PokerClient { get; set; }

        protected override void OnInitialized()
        {
            this.RoundParameters.TableId = this.TableId;

            this.PokerClient.OnVotingRoundCreated(round => this.Dispatcher.Dispatch(new SetVotingRoundAction(round)));
        }

        public void OnRoundCreateInvalidSubmit(FormInvalidSubmitEventArgs args)
        {
            Guard.Against.Null(args, nameof(args));
            this.Logger.LogError("Invalid Form Submit: {Args}", JsonSerializer.Serialize(args, this.LoggingSerializerOptions));
        }

        public void OnRoundCreateValidSubmit()
        {
            this.Logger.LogDebug("Attempting to join table {TableId}", this.RoundParameters.Description);

            this.PokerClient.CreateVotingRound(this.RoundParameters);
            this.DialogService.Close(true);
        }
    }
}