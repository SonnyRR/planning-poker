using System;
using PlanningPoker.SharedKernel.Models.Generated;

namespace PlanningPoker.SharedKernel.Models.Generated
{
    public partial class VoteModel
    {
        public Guid RoundId { get; set; }
        public RoundModel Round { get; set; }
        public float Estimation { get; set; }
        public TimeSpan Duration { get; set; }
        public string Username { get; set; }
        public Guid? PlayerId { get; set; }
        public UserModel Player { get; set; }
        public Guid Id { get; set; }
    }
}