namespace PlanningPoker.Core.Services;
    using System.Threading.Tasks;

    using PlanningPoker.SharedKernel.Models.Tables;

    public interface IVotingService
    {
        Task Vote(PlayerVote vote);
    }
