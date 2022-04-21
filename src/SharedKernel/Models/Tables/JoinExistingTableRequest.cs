using FluentValidation;
using PlanningPoker.SharedKernel.Models.Tables;

namespace PlanningPoker.SharedKernel.Models.Tables
{
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
            RuleFor(jetr => jetr.TableCode).NotEmpty();
        }
    }
}
