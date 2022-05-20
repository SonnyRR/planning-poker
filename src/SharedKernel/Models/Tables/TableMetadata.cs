namespace PlanningPoker.SharedKernel.Models.Tables
{
	using FluentValidation;

	/// <summary>
	/// Represents the information about a given poker table.
	/// </summary>
	public sealed class TableMetadata
	{
		public TableMetadata()
		{
		}

		public TableMetadata(string name, int code)
		{
			this.Name = name;
			this.Code = code;
		}

		public int Code { get; set; }

		public string Name { get; set; }
	}

	public class TableMetadataValidator : AbstractValidator<TableMetadata>
	{
		public TableMetadataValidator()
		{
			this.RuleFor(tm => tm.Name).NotEmpty().MinimumLength(3);
			this.RuleFor(tm => tm.Code).NotEmpty();
		}
	}
}
