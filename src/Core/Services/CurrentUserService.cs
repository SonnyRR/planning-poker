namespace PlanningPoker.Core.Services
{
    using Ardalis.GuardClauses;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Security.Claims;
    using static OpenIddict.Abstractions.OpenIddictConstants;

    ///<inheritdoc cref="ICurrentUserService"/>
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            Guard.Against.Null(httpContextAccessor, nameof(httpContextAccessor));
            this.httpContextAccessor = httpContextAccessor;
        }

        public string Email => this.ClaimsPrincipal?.FindFirstValue(Claims.Email);

        public Guid UserId
        {
            get
            {
                var idStr = this.ClaimsPrincipal?.FindFirstValue(Claims.Subject);
                return !string.IsNullOrWhiteSpace(idStr) ? Guid.Parse(idStr) : Guid.Empty;
            }
        }

        public string Username => this.ClaimsPrincipal?.FindFirstValue(Claims.Username);

        private ClaimsPrincipal ClaimsPrincipal => this.httpContextAccessor.HttpContext?.User;
    }
}
