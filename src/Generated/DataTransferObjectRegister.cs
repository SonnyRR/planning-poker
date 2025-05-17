namespace PlanningPoker.Generated
{
    using Mapster;
    using PlanningPoker.Persistence;
    using PlanningPoker.Persistence.Entities;
    using System;
    using System.Linq;
    using System.Reflection;

    public class DataTransferObjectRegister : ICodeGenerationRegister
    {
        public void Register(CodeGenerationConfig config)
        {
            var types = Assembly
                .GetAssembly(typeof(PlanningPokerDbContext))
                .GetTypes()
                .Where(t => typeof(BaseEntity<Guid>).IsAssignableFrom(t) && !t.IsInterface)
                .ToArray();

            config.AdaptTwoWays("[name]Model")
                .ForType<Table>(cfg =>
                {
                    cfg.Ignore(e => e.CreatedOn);
                    cfg.Ignore(e => e.ModifiedOn);
                    cfg.Ignore(e => e.DeckId);
                    cfg.Ignore(e => e.OwnerId);
                })
                .ForType<Card>(cfg =>
                {
                    cfg.Ignore(e => e.CreatedOn);
                    cfg.Ignore(e => e.DeletedOn);
                    cfg.Ignore(e => e.ModifiedOn);
                    cfg.Ignore(e => e.IsDeleted);
                    cfg.Ignore(e => e.Decks);
                })
                .ForType<Deck>(cfg =>
                {
                    cfg.Ignore(e => e.CreatedOn);
                    cfg.Ignore(e => e.DeletedOn);
                    cfg.Ignore(e => e.ModifiedOn);
                    cfg.Ignore(e => e.IsDeleted);
                })
                .ForType<User>(cfg =>
                {
                    cfg.Ignore(e => e.AccessFailedCount);
                    cfg.Ignore(e => e.ConcurrencyStamp);
                    cfg.Ignore(e => e.DeletedOn);
                    cfg.Ignore(e => e.Email);
                    cfg.Ignore(e => e.EmailConfirmed);
                    cfg.Ignore(e => e.IsDeleted);
                    cfg.Ignore(e => e.LockoutEnabled);
                    cfg.Ignore(e => e.LockoutEnd);
                    cfg.Ignore(e => e.NormalizedEmail);
                    cfg.Ignore(e => e.NormalizedUserName);
                    cfg.Ignore(e => e.PasswordHash);
                    cfg.Ignore(e => e.PhoneNumber);
                    cfg.Ignore(e => e.PhoneNumberConfirmed);
                    cfg.Ignore(e => e.SecurityStamp);
                    cfg.Ignore(e => e.TwoFactorEnabled);
                    cfg.Ignore(e => e.Tables);
                })
                .ForType<Round>(cfg =>
                {
                    cfg.Ignore(e => e.CreatedOn);
                    cfg.Ignore(e => e.ModifiedOn);
                    cfg.Ignore(e => e.Table);
                })
                .ForType<Vote>(cfg =>
                {
                    cfg.Ignore(e => e.CreatedOn);
                    cfg.Ignore(e => e.ModifiedOn);
                })
                .MaxDepth(3);

            config.GenerateMapper("[name]Mapper")
                .ForTypes(types)
                .ForType<User>();
        }
    }
}