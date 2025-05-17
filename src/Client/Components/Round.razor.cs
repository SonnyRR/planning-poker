using Microsoft.AspNetCore.Components;
using PlanningPoker.Generated.Models;
using Radzen;

namespace PlanningPoker.Client.Components
{
    public partial class Round
    {
        [Parameter]
        public DeckModel Deck { get; set; }

        [Inject]
        public DialogService DialogService { get; set; }
    }
}