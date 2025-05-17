namespace PlanningPoker.Identity.Models.Options
{
    public sealed class ClientMetadata
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string DisplayName { get; set; }

        public string Name { get; set; }

        public string[] PostLogoutRedirectUris { get; set; }

        public string[] RedirectUris { get; set; }
    }
}