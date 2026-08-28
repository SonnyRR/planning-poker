namespace PlanningPoker.BFF.Utilities;

using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication;

using static OpenIddict.Abstractions.OpenIddictConstants;

/// <summary>
/// Transforms WS Federation claim types to OpenIDdict ones.
/// </summary>
public sealed class ClaimsTransformer : IClaimsTransformation
{
    public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        var claimsIdentity = principal.Identity as ClaimsIdentity;
        var claimsMap = new Dictionary<string, string>()
        {
            { ClaimTypes.Email, Claims.Email}
        };

        foreach (var claimMap in claimsMap)
        {
            var foundClaim = principal.FindFirst(claimMap.Key);
            if (foundClaim != null && claimsIdentity.TryRemoveClaim(foundClaim))
            {
                claimsIdentity.AddClaim(new Claim(claimMap.Value, foundClaim.Value));
            }
        }

        return Task.FromResult(principal);
    }
}
