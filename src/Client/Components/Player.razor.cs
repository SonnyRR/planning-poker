namespace PlanningPoker.Client.Components
{
	using Microsoft.AspNetCore.Components;
	using Microsoft.Extensions.Logging;
	using System;
	using static Constants.Cards;

	public partial class Player
	{
		[Inject]
		public ILogger<Player> Logger { get; set; }

		[Parameter]
		public string PlayerName { get; set; }

		[Parameter]
		public Guid PlayerId { get; set; }

		public int? Vote { get; private set; }

		public bool IsVoteRevealed { get; private set; }

		public string Styles { get; private set; }

		public void RevealCard()
			=> this.Styles = CARD_STYLES.Value[CardStates.Revealing];

		public void RemoveAnimation()
		{
			this.Logger.LogInformation("Removing animation...");
			this.Styles = CARD_STYLES.Value[CardStates.Revealed];
			this.IsVoteRevealed = true;
		}

		public void SetVoted()
		{
			this.Styles = CARD_STYLES.Value[CardStates.Voted];
			this.Vote = 3;
		}

		public void Reset()
			=> this.Styles = CARD_STYLES.Value[CardStates.Pending];

		protected override void OnInitialized()
		{
			base.OnInitialized();
			this.Styles = CARD_STYLES.Value[CardStates.Pending];
		}
	}
}
