namespace PlanningPoker.Core
{
    using System.Threading.Tasks;
    using PlanningPoker.SharedKernel.Models.Tables;

    public interface IVotingService
    {
        Task Vote(PlayerVote vote);
    }
}
