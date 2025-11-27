namespace PlanningPoker.Core.Services;
    using PlanningPoker.SharedKernel.Models.Tables;
    using System.Threading.Tasks;

    public interface IVotingService
    {
        Task Vote(PlayerVote vote);
    }
