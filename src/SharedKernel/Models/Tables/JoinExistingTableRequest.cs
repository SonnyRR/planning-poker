namespace PlanningPoker.SharedKernel.Models.Tables
{
    using FluentValidation;
    using System;

    /// <summary>
    /// An application/request for joining an existing poker table.
    /// </summary>
    public sealed class JoinExistingTableRequest
	{
		/// <summary>
		/// The table's unique identifier.
		/// </summary>
		public string Code { get; set; }
	}

	public sealed class JoinExistingTableRequestValidator : AbstractValidator<JoinExistingTableRequest>
	{
		public JoinExistingTableRequestValidator()
		{
			this.RuleFor(jetr => jetr.Code)
				.NotEmpty()
				.Must(IsValidGuid)
				.WithMessage("Not a valid code");
        }

        private static bool IsValidGuid(string value) => Guid.TryParse(value, out _);
	}
}
