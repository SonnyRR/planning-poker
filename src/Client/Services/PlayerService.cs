﻿using System.Threading;
using System.Threading.Tasks;

using Ardalis.GuardClauses;

using Blazored.LocalStorage;

using Microsoft.Extensions.Logging;

namespace PlanningPoker.Client.Services
{
    /// <inheritdoc cref="IPlayerService"/>
    public sealed class PlayerService : IPlayerService
    {
        private const string USERNAME_KEY = "userName";

        private readonly ILocalStorageService localStorageService;

        private readonly ILogger<PlayerService> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerService"/> class.
        /// </summary>
        /// <param name="localStorageService">The local storage service.</param>
        /// <param name="logger">Logger.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public PlayerService(ILogger<PlayerService> logger)
        {
            //Guard.Against.Null(localStorageService, nameof(localStorageService));
            Guard.Against.Null(logger, nameof(logger));

            //this.localStorageService = localStorageService;
            this.logger = logger;
        }

		public ValueTask<bool> CheckIfUsernameHasBeenEntered(CancellationToken? cancellationToken = null)
			=> ValueTask.FromResult(true);//this.localStorageService.ContainKeyAsync(USERNAME_KEY, cancellationToken);

        public ValueTask SaveUsername(string userName, CancellationToken? cancellationToken = null)
        {
            Guard.Against.NullOrWhiteSpace(userName, nameof(userName));

            this.logger.LogDebug("Attempting to persist username: {userName}", userName);

            return this.localStorageService.SetItemAsStringAsync(USERNAME_KEY, userName, cancellationToken);
        }
    }
}
