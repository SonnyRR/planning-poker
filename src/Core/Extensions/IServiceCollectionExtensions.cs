namespace PlanningPoker.Core.Extensions
{
    using Ardalis.GuardClauses;
    using Microsoft.Extensions.DependencyInjection;
    using PlanningPoker.Core.Services;

    /// <summary>
    /// Contains extension methods for registering application services.
    /// </summary>
    public static class IServiceCollectionExtensions
	{
		/// <summary>
		/// Registeres core services.
		/// </summary>
		/// <param name="services"></param>
		/// <returns>An instance of <see cref="IServiceCollection"/>.</returns>
		public static IServiceCollection AddCoreServices(this IServiceCollection services)
		{
			Guard.Against.Null(services, nameof(services));

			services.AddTransient<ICurrentUserService, CurrentUserService>();
			services.AddTransient<ITableService, TableService>();
            services.AddTransient<IRoundService, RoundService>();

			return services;
		}
	}
}
