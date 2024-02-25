namespace PlanningPoker.Client.Features.Rounds.Components
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Components;
    using PlanningPoker.SharedKernel.Models.Generated;
    using Radzen;

    public partial class RoundList
    {
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
    }
}
