namespace PlanningPoker.SharedKernel.Models.Configuration
{
	using System.ComponentModel.DataAnnotations;

	public sealed class ConnectionStrings
    {
        [Required]
        public string Database { get; init; }
    }
}
