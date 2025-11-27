namespace PlanningPoker.SharedKernel.Models.Authorization;

using System.Collections.Generic;

public class UserInfo
{
    public static readonly UserInfo Anonymous = new();

    public ICollection<ClaimValue> Claims { get; set; } = [];

    public string EmailClaimType { get; set; }

    public bool IsAuthenticated { get; set; }

    public string NameClaimType { get; set; }

    public string RoleClaimType { get; set; }
}
