namespace PlanningPoker.Core
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.GuardClauses;
    using Mapster;
    using PlanningPoker.Core.Mapping;
    using PlanningPoker.Persistence;
    using PlanningPoker.SharedKernel.Models.Binding;
    using PlanningPoker.SharedKernel.Models.Generated;

    public class RoundService : IRoundService
    {
        private readonly PlanningPokerDbContext dbContext;

        public RoundService(PlanningPokerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<RoundModel> CreateAsync(RoundBindingModel model, CancellationToken ct = default)
        {
            Guard.Against.Null(model, nameof(model));

            var roundEntry = await this.dbContext.Rounds.AddAsync(model.Adapt<Round>(), ct);
            await this.dbContext.SaveChangesAsync(ct);

            return roundEntry.Entity.AdaptToModel();
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken ct = default)
        {
            Guard.Against.Null(id, nameof(id));

            this.dbContext.Rounds.Remove(new() { Id = id });
            return Convert.ToBoolean(await this.dbContext.SaveChangesAsync(ct));
        }

        public Task Finalize(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
