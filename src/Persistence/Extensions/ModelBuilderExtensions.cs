
using Microsoft.EntityFrameworkCore;

namespace PlanningPoker.Persistence.Extensions
{
    internal static class ModelBuilderExtensions
    {
        internal static ModelBuilder RemoveIdentityTablesPrefix(this ModelBuilder builder)
        {
            const string prefix = "AspNet";

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();

                if (!string.IsNullOrWhiteSpace(tableName) && tableName.StartsWith(prefix))
                {
                    entityType.SetTableName(tableName[prefix.Length..]);
                }
            }

            return builder;
        }
    }
}
