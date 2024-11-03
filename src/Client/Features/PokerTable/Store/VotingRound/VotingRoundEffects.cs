namespace PlanningPoker.Client.Features.PokerTable.Store.VotingRound
{
    using Fluxor;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class VotingRoundEffects
    {
        private readonly IRoundService roundService;

        public VotingRoundEffects(IRoundService roundService)
            => this.roundService = roundService;

        [EffectMethod]
        public async Task Create(CreateVotingRoundAction action, IDispatcher dispatcher)
        {
            dispatcher.Dispatch(new SetVotingRoundLoadingAction());

            try
            {
                await this.roundService.CreateAsync(action.Round);
            }
            catch (HttpRequestException)
            {
                // TODO: Complete the handling of errors.
            }
        }
    }
}