namespace PlanningPoker.Core
{
    using PlanningPoker.SharedKernel.Models.Tables;
    using System.Threading.Tasks;

    public interface IVotingService
    {
        Task Vote(PlayerVote vote);
    }
}