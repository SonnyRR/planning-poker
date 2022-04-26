using System.ComponentModel.DataAnnotations;

namespace PlanningPoker.SharedKernel.Models.Configuration
{
    public sealed class ConnectionStrings
    {
        [Required]
        public string Main { get; init; }
    }
}
