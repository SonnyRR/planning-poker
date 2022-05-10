namespace PlanningPoker.SharedKernel.Models.Tables
{
	using FluentValidation;

	/// <summary>
	/// An application/request for joining an existing poker table.
	/// </summary>
	public sealed class JoinExistingTableRequest
	{
		/// <summary>
		/// The table's unique identifier.
		/// </summary>
		public string TableCode { get; set; }
	}

	public sealed class JoinExistingTableRequestValidator : AbstractValidator<JoinExistingTableRequest>
	{
		public JoinExistingTableRequestValidator()
		{
			this.RuleFor(jetr => jetr.TableCode).NotEmpty();
		}
	}
}
