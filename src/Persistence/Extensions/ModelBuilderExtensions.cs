namespace PlanningPoker.Persistence.Extensions
{
    using Microsoft.EntityFrameworkCore;

    internal static class ModelBuilderExtensions
    {
        internal static ModelBuilder RemoveIdentityTablesPrefix(this ModelBuilder builder)
        {
            const string PREFIX = "AspNet";

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();

                if (!string.IsNullOrWhiteSpace(tableName) && tableName.StartsWith(PREFIX))
                {
                    entityType.SetTableName(tableName[PREFIX.Length..]);
                }
            }

            return builder;
        }
    }
}
