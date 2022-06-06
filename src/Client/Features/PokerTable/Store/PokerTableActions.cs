namespace PlanningPoker.Client.Features.PokerTable.Store.Actions
{
	using PlanningPoker.SharedKernel.Models.Generated;
	using System;

	public class PokerTableLoadAction
	{
		public PokerTableLoadAction(Guid id) => this.Id = id;

		public Guid Id { get; set; }
	}

	public class PokerTableSetAction
	{
		public PokerTableSetAction(TableModel table) => this.Table = table;

		public TableModel Table { get; }
	}

	public class PokerTableSetInitializedAction
	{
	}

	public class PokerTableSetLoadingAction
	{
	}
}
