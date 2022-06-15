﻿namespace PlanningPoker.Client.Features.PokerTable.Store
{
	using PlanningPoker.SharedKernel.Models.Generated;

	public record PokerTableState
	{
		public bool IsInitialized { get; init; }

		public bool IsLoading { get; init; }

		public TableModel Table { get; init; }
	}

	public record PokerTableCreationState
	{
		public bool Submitting { get; init; }

		public bool Submitted { get; init; }

		public string ErrorMessage { get; init; }
	}
}
