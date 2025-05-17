namespace PlanningPoker.Client.Components
{
    using Microsoft.AspNetCore.Components;
    using Microsoft.Extensions.Logging;
    using System;
    using static Constants.Cards;

    public partial class Player
    {
        public bool IsVoteRevealed { get; private set; }

        [Inject]
        public ILogger<Player> Logger { get; set; }

        [Parameter]
        public Guid PlayerId { get; set; }

        [Parameter]
        public string PlayerName { get; set; }

        public string Styles { get; private set; }

        public int? Vote { get; private set; }

        public void RemoveAnimation()
        {
            this.Logger.LogInformation("Removing animation...");
            this.Styles = CARD_STYLES.Value[CardStates.Revealed];
            this.IsVoteRevealed = true;
        }

        public void Reset()
        {
            this.Styles = CARD_STYLES.Value[CardStates.Pending];
            this.IsVoteRevealed = false;
        }

        public void RevealCard()
            => this.Styles = CARD_STYLES.Value[CardStates.Revealing];

        public void SetVoted()
        {
            this.Styles = CARD_STYLES.Value[CardStates.Voted];
            this.Vote = 3;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            this.Styles = CARD_STYLES.Value[CardStates.Pending];
        }
    }
}