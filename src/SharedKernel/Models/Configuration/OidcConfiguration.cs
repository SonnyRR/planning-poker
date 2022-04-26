namespace PlanningPoker.SharedKernel.Models.Configuration
{
    public sealed class OidcConfiguration
    {
        public string Authority { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public bool GetClaimsFromUserInfoEndpoint { get; set; }

        public bool RequireHttpsMetadata { get; set; }

        public string ResponseType { get; set; }

        public bool SaveTokens { get; set; }

        public string[] Scopes { get; set; }

        public string SignInScheme { get; set; }
    }
}
