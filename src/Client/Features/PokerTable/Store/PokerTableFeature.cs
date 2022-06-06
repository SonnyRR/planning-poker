namespace PlanningPoker.Client.Features.PokerTable.Store
{
	using Fluxor;

	public class PokerTableFeature : Feature<PokerTableState>
	{
		public override string GetName() => nameof(PokerTableState);

		protected override PokerTableState GetInitialState() => new() { Table = new() };
	}
}
