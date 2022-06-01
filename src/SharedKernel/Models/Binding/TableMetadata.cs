namespace PlanningPoker.SharedKernel.Models.Binding
{
	using FluentValidation;

	/// <summary>
	/// Represents the information for creating or updating an existing poker table.
	/// </summary>
	public sealed class TableBindingModel
	{
		public TableBindingModel()
		{
		}

		public TableBindingModel(string name, int code)
		{
			this.Name = name;
			this.Code = code;
		}

		public int Code { get; set; }

		public string Name { get; set; }
	}

	/// <summary>
	/// Validates table binding models.
	/// </summary>
	public class TableBindingModelValidator : AbstractValidator<TableBindingModel>
	{
		public TableBindingModelValidator()
		{
			this.RuleFor(tm => tm.Name).NotEmpty().MinimumLength(3);
			this.RuleFor(tm => tm.Code).NotEmpty();
		}
	}
}
