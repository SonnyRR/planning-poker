namespace PlanningPoker.Client.Features.PokerTable.Store
{
	using Fluxor;

	public class PokerTableCreateFeature : Feature<PokerTableCreationState>
	{
		public override string GetName() => nameof(PokerTableCreationState);

		protected override PokerTableCreationState GetInitialState()
			=> new();
	}

	public class PokerTableFeature : Feature<PokerTableState>
	{
		public override string GetName() => nameof(PokerTableState);

		protected override PokerTableState GetInitialState()
			=> new();
	}
}
