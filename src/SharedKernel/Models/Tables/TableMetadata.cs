using FluentValidation;

namespace PlanningPoker.Client.Models
{
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

        public string Name { get; set; }

        public int Code { get; set; }

        // TODO: Add remaining properties.
    }

    public class TableMetadataValidator : AbstractValidator<TableMetadata>
    {
        public TableMetadataValidator()
        {
            RuleFor(tm => tm.Name).NotEmpty().MinimumLength(3);
            RuleFor(tm => tm.Code).NotEmpty();
        }
    }
}
