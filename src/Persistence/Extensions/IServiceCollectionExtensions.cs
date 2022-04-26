﻿using Ardalis.GuardClauses;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using PlanningPoker.SharedKernel.Models.Configuration;

namespace PlanningPoker.Persistence.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services)
        {
            Guard.Against.Null(services, nameof(services));

            using var serviceProvider = services.BuildServiceProvider();

            var applicationOptions = serviceProvider.GetService<IOptions<PlanningPokerOptions>>()?.Value;
            Guard.Against.Null(applicationOptions, nameof(applicationOptions));
            Guard.Against.NullOrEmpty(applicationOptions.ConnectionStrings.Main, nameof(applicationOptions.ConnectionStrings.Main));

            services.AddDbContext<PlanningPokerDbContext>(options =>
            {
                options.UseSqlServer(applicationOptions.ConnectionStrings.Main);
                options.UseOpenIddict();
            });

            return services;
        }
    }
}
