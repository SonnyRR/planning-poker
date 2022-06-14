namespace PlanningPoker.Client.Features.PokerTable.Store
{
	using Fluxor;

	public class PokerTableCreateFeature : Feature<PokerTableSubmissionState>
	{
		public override string GetName() => nameof(PokerTableSubmissionState);

		protected override PokerTableSubmissionState GetInitialState()
			=> new();
	}

	public class PokerTableFeature : Feature<PokerTableState>
	{
		public override string GetName() => nameof(PokerTableState);

		protected override PokerTableState GetInitialState()
			=> new()
			{
				IsLoading = true,
				Table = new()
			};
	}
}
