namespace PlanningPoker.Client.Features.PokerTable.Store.Actions
{
    using PlanningPoker.Generated.Models;
    using PlanningPoker.SharedKernel.Models.Binding;
    using System;

    public class PokerTableCreationAction
	{
		public PokerTableCreationAction(TableBindingModel bindingModel)
			=> this.BindingModel = bindingModel;

		public TableBindingModel BindingModel { get; init; }
	}

	public class PokerTableLeaveAction
	{
		public PokerTableLeaveAction(Guid id) => this.Id = id;

		public Guid Id { get; set; }
	}

	public class PokerTableLoadAction
	{
		public PokerTableLoadAction(Guid id) => this.Id = id;

		public Guid Id { get; init; }
	}

	public class PokerTableSetAction
	{
		public PokerTableSetAction(TableModel table) => this.Table = table;

		public TableModel Table { get; init; }
	}

	public class PokerTableSetInitializedAction
	{
	}

	public class PokerTableSetLoadingAction
	{
		public PokerTableSetLoadingAction(bool flag = true) => this.Flag = flag;

		public bool Flag { get; init; }
	}

	public class PokerTableSuccessfulCreationAction
	{
	}

	public class PokerTableUnsuccessfulCreationAction
	{
		public PokerTableUnsuccessfulCreationAction(string errorMessage)
			=> this.ErrorMessage = errorMessage;

		public string ErrorMessage { get; init; }
	}
}
