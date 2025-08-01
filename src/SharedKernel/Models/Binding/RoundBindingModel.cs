using FluentValidation;
using System;

namespace PlanningPoker.SharedKernel.Models.Binding
{
    public sealed class RoundBindingModel
    {
        /// <summary>
        /// A consice description of the work item, that's going
        /// to be voted in this round.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The table identifier, in which this round should
        /// be assigned to.
        /// </summary>
        public Guid TableId { get; set; }

        /// <summary>
        /// The order index of the round.
        /// </summary>
        public short Ordinal { get; set; }
    }

    /// <summary>
	/// Validates table binding models.
	/// </summary>
	public class RoundBindingModelValidator : AbstractValidator<RoundBindingModel>
    {
        public RoundBindingModelValidator()
        {
            this.RuleFor(tm => tm.Description).NotEmpty();
            this.RuleFor(tm => tm.TableId).NotEmpty();
        }
    }
}
