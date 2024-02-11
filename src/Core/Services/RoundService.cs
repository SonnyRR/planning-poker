namespace PlanningPoker.Core
{
    using Microsoft.Extensions.Logging;
    using PlanningPoker.Core.Services;
    using PlanningPoker.Persistence;

    public class RoundService
    {
        private readonly ICurrentUserService currentUserService;
        private readonly PlanningPokerDbContext dbContext;
		private readonly ILogger<TableService> logger;

        public RoundService(
            ICurrentUserService currentUserService, PlanningPokerDbContext dbContext, ILogger<TableService> logger)
        {
            this.currentUserService = currentUserService;
            this.dbContext = dbContext;
            this.logger = logger;
        }
    }
}
