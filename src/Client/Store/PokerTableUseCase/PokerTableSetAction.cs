namespace PlanningPoker.Client.Store.PokerTableUseCase
{
	using PlanningPoker.SharedKernel.Models.Generated;

	public class PokerTableSetAction
	{
		public PokerTableSetAction()
		{
		}

		public PokerTableSetAction(TableModel table) => this.Table = table;

		public TableModel Table { get; }
	}
}
