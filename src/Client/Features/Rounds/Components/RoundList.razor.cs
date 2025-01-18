namespace PlanningPoker.Client.Features.Rounds.Components
{
    using Microsoft.AspNetCore.Components;
    using PlanningPoker.Generated.Models;
    using Radzen;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public partial class RoundList
    {
        [Parameter]
        public Guid TableId { get; set; }

        public List<RoundModel> rounds => new List<RoundModel>
        {
            new RoundModel
            {
                Description = "t1",
                StartedOn = DateTimeOffset.UtcNow.AddSeconds(-60),
                EndedOn = DateTimeOffset.UtcNow,
            },
            new RoundModel
            {
                Description = "t2",
                StartedOn = DateTimeOffset.UtcNow.AddSeconds(-60),
                EndedOn = DateTimeOffset.UtcNow,
                FinalEstimation = 3f
            },
            new RoundModel
            {
                Description = "t2",
                StartedOn = DateTimeOffset.UtcNow.AddSeconds(-60),
                EndedOn = DateTimeOffset.UtcNow,
                FinalEstimation = 3f
            },
            new RoundModel
            {
                Description = "t2",
                StartedOn = DateTimeOffset.UtcNow.AddSeconds(-60),
                EndedOn = DateTimeOffset.UtcNow,
                FinalEstimation = 3f
            },
            new RoundModel
            {
                Description = "t2",
                StartedOn = DateTimeOffset.UtcNow.AddSeconds(-60),
                EndedOn = DateTimeOffset.UtcNow,
                FinalEstimation = 3f
            },
            new RoundModel
            {
                Description = "t2",
                StartedOn = DateTimeOffset.UtcNow.AddSeconds(-60),
                EndedOn = DateTimeOffset.UtcNow,
                FinalEstimation = 3f
            },
            new RoundModel
            {
                Description = "t2",
                StartedOn = DateTimeOffset.UtcNow.AddSeconds(-60),
                EndedOn = DateTimeOffset.UtcNow,
                FinalEstimation = 3f
            },
            new RoundModel
            {
                Description = "t2",
                StartedOn = DateTimeOffset.UtcNow.AddSeconds(-60),
                EndedOn = DateTimeOffset.UtcNow,
                FinalEstimation = 3f
            },
            new RoundModel
            {
                Description = "t2",
                StartedOn = DateTimeOffset.UtcNow.AddSeconds(-60),
                EndedOn = DateTimeOffset.UtcNow,
                FinalEstimation = 3f
            },
            new RoundModel
            {
                Description = "t2",
                StartedOn = DateTimeOffset.UtcNow.AddSeconds(-60),
                EndedOn = DateTimeOffset.UtcNow,
                FinalEstimation = 3f
            },
            new RoundModel
            {
                Description = "t2",
                StartedOn = DateTimeOffset.UtcNow.AddSeconds(-60),
                EndedOn = DateTimeOffset.UtcNow,
                FinalEstimation = 3f
            },
            new RoundModel
            {
                Description = "t2",
                StartedOn = DateTimeOffset.UtcNow.AddSeconds(-60),
                EndedOn = DateTimeOffset.UtcNow,
                FinalEstimation = 3f
            },
            new RoundModel
            {
                Description = "t2",
                StartedOn = DateTimeOffset.UtcNow.AddSeconds(-60),
                EndedOn = DateTimeOffset.UtcNow,
                FinalEstimation = 3f
            },
            new RoundModel
            {
                Description = "t2",
                StartedOn = DateTimeOffset.UtcNow.AddSeconds(-60),
                EndedOn = DateTimeOffset.UtcNow,
                FinalEstimation = 3f
            },
            new RoundModel
            {
                Description = "t2",
                StartedOn = DateTimeOffset.UtcNow.AddSeconds(-60),
                EndedOn = DateTimeOffset.UtcNow,
                FinalEstimation = 3f
            },
            new RoundModel
            {
                Description = "t2",
                StartedOn = DateTimeOffset.UtcNow.AddSeconds(-60),
                EndedOn = DateTimeOffset.UtcNow,
                FinalEstimation = 3f
            }
        };

        [Inject]
        public DialogService DialogService { get; set; }

        public async Task CreateVotingRound()
        {
            var parameters = new Dictionary<string, object>
            {
                { "TableId", this.TableId }
            };

            var dialogOptions = new DialogOptions
            {
                Height = "38%",
                Width = "50%"
            };

            await this.DialogService.OpenAsync<CreateRound>("Create Round", parameters, dialogOptions);
        }
    }
}
