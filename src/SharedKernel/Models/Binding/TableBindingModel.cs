namespace PlanningPoker.SharedKernel.Models.Binding
{
    using FluentValidation;
    using PlanningPoker.SharedKernel.Models.Decks;
    using System;

    /// <summary>
    /// Represents the information for creating or updating an existing poker table.
    /// </summary>
    public sealed class TableBindingModel
    {
        public TableBindingModel()
        {
        }

        public TableBindingModel(string name, DeckType deckType)
        {
            this.Name = name;
            this.DeckType = deckType;
        }

        /// <summary>
        /// The card deck type.
        /// </summary>
        public DeckType DeckType { get; set; }

        /// <summary>
        /// The table's unique identifier.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// The name of the poker table.
        /// </summary>
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
            this.RuleFor(tm => tm.DeckType).NotEmpty();
        }
    }
}
