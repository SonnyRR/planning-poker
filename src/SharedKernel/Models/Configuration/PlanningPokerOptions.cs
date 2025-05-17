namespace PlanningPoker.SharedKernel.Models.Configuration
{
    public sealed class PlanningPokerOptions
    {
        public ConnectionStrings ConnectionStrings { get; init; }

        public OidcConfiguration OidcConfiguration { get; set; }
    }
}