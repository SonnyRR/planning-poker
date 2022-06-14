namespace PlanningPoker.Client.Features.PokerTable.Store.Actions
{
	using PlanningPoker.SharedKernel.Models.Binding;
	using PlanningPoker.SharedKernel.Models.Generated;
	using System;

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
	}

	public class PokerTableSubmitAction
	{
		public PokerTableSubmitAction(TableBindingModel bindingModel)
			=> this.BindingModel = bindingModel;

		public TableBindingModel BindingModel { get; init; }
	}

	public class PokerTableSuccessfulSubmitAction
	{
	}

	public class PokerTableUnsuccessfulSubmitAction
	{
		public PokerTableUnsuccessfulSubmitAction(string errorMessage)
			=> this.ErrorMessage = errorMessage;

		public string ErrorMessage { get; init; }
	}

	public class PokerTableLeaveAction
	{
		public Guid Id { get; set; }

		public PokerTableLeaveAction(Guid id) => this.Id = id;
	}
}
