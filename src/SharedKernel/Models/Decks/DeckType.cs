namespace PlanningPoker.SharedKernel.Models.Decks
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represets a type of card deck.
    /// </summary>
    public enum DeckType
    {
        Fibonacci = 1,

        [Display(Name = "Fibonacci Unsure")]
        FibonacciUnsure,

        [Display(Name = "Fibonacci Coffee")]
        FibonacciCoffee,
        Size
    }
}
