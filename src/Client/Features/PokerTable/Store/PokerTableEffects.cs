namespace PlanningPoker.Client.Features.PokerTable.Store
{
    using Actions;
    using Fluxor;
    using PlanningPoker.Client.Services;
    using System.Threading.Tasks;

    public class PokerTableEffects
    {
        private readonly ITableService tableService;

        public PokerTableEffects(ITableService tableService)
            => this.tableService = tableService;

        [EffectMethod]
        public async Task Create(PokerTableCreationAction action, IDispatcher dispatcher)
        {
            dispatcher.Dispatch(new PokerTableSetLoadingAction());

            var table = await this.tableService.CreateAsync(action.BindingModel);
            if (table is not null)
            {
                dispatcher.Dispatch(new PokerTableSuccessfulCreationAction());
                dispatcher.Dispatch(new PokerTableSetAction(table));
                return;
            }

            dispatcher.Dispatch(new PokerTableSetLoadingAction(false));
            dispatcher.Dispatch(new PokerTableUnsuccessfulCreationAction("Server error."));
        }

        [EffectMethod]
        public async Task Load(PokerTableLoadAction action, IDispatcher dispatcher)
        {
            dispatcher.Dispatch(new PokerTableSetLoadingAction());
            var table = await this.tableService.GetByIdAsync(action.Id);
            dispatcher.Dispatch(new PokerTableSetAction(table));
        }

        [EffectMethod]
        public async Task Leave(PokerTableLeaveAction action, IDispatcher dispatcher)
        {
            await this.tableService.LeaveAsync(action.Id);
            dispatcher.Dispatch(new PokerTableSetAction(null));
        }
    }
}
