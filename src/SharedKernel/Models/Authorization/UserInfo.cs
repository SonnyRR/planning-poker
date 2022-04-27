using System.Collections.Generic;

namespace PlanningPoker.SharedKernel.Models.Authorization
{
    public class UserInfo
    {
        public static readonly UserInfo Anonymous = new();

        public ICollection<ClaimValue> Claims { get; set; } = new List<ClaimValue>();

        public bool IsAuthenticated { get; set; }

        public string NameClaimType { get; set; }

        public string RoleClaimType { get; set; }
    }
}
