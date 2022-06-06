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
		public async Task LoadTable(PokerTableLoadAction action, IDispatcher dispatcher)
		{
			dispatcher.Dispatch(new PokerTableSetLoadingAction());
			var table = await this.tableService.GetByIdAsync(action.Id);
			dispatcher.Dispatch(new PokerTableSetAction(table));
		}
	}
}
