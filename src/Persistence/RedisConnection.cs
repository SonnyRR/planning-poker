using StackExchange.Redis;
using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace PlanningPoker.Persistence
{
#pragma warning disable IDE0007 // Use implicit type
    public class RedisConnection : IDisposable
    {
        private long lastReconnectTicks = DateTimeOffset.MinValue.UtcTicks;
        private DateTimeOffset firstErrorTime = DateTimeOffset.MinValue;
        private DateTimeOffset previousErrorTime = DateTimeOffset.MinValue;

        // StackExchange.Redis will also be trying to reconnect internally,
        // so limit how often we recreate the ConnectionMultiplexer instance
        // in an attempt to reconnect
        private readonly TimeSpan reconnectMinInterval = TimeSpan.FromSeconds(60);

        // If errors occur for longer than this threshold, StackExchange.Redis
        // may be failing to reconnect internally, so we'll recreate the
        // ConnectionMultiplexer instance
        private readonly TimeSpan reconnectErrorThreshold = TimeSpan.FromSeconds(30);
        private readonly TimeSpan estartConnectionTimeout = TimeSpan.FromSeconds(15);
        private const int RetryMaxAttempts = 5;

        private readonly SemaphoreSlim reconnectSemaphore = new(initialCount: 1, maxCount: 1);
        private readonly string connectionString;
        private ConnectionMultiplexer connection;
        private IDatabase database;

        private RedisConnection(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public static async Task<RedisConnection> InitializeAsync(string connectionString)
        {
            var redisConnection = new RedisConnection(connectionString);
            await redisConnection.ForceReconnectAsync(initializing: true);

            return redisConnection;
        }

        // In real applications, consider using a framework such as
        // Polly to make it easier to customize the retry approach.
        // For more info, please see: https://github.com/App-vNext/Polly
        public async Task<T> BasicRetryAsync<T>(Func<IDatabase, Task<T>> func)
        {
            int reconnectRetry = 0;

            while (true)
            {
                try
                {
                    return await func(this.database);
                }
                catch (Exception ex) when (ex is RedisConnectionException || ex is SocketException || ex is ObjectDisposedException)
                {
                    reconnectRetry++;
                    if (reconnectRetry > RetryMaxAttempts)
                    {
                        throw;
                    }

                    try
                    {
                        await this.ForceReconnectAsync();
                    }
                    catch (ObjectDisposedException)
                    {
                        // An error occurred during the disposal.
                    }
                }
            }
        }

        /// <summary>
        /// Force a new ConnectionMultiplexer to be created.
        /// NOTES:
        ///     1. Users of the ConnectionMultiplexer MUST handle ObjectDisposedExceptions, which can now happen as a result of calling ForceReconnectAsync().
        ///     2. Call ForceReconnectAsync() for RedisConnectionExceptions and RedisSocketExceptions. You can also call it for RedisTimeoutExceptions,
        ///         but only if you're using generous ReconnectMinInterval and ReconnectErrorThreshold. Otherwise, establishing new connections can cause
        ///         a cascade failure on a server that's timing out because it's already overloaded.
        ///     3. The code will:
        ///         a. wait to reconnect for at least the "ReconnectErrorThreshold" time of repeated errors before actually reconnecting
        ///         b. not reconnect more frequently than configured in "ReconnectMinInterval"
        /// </summary>
        /// <param name="initializing">Should only be true when ForceReconnect is running at startup.</param>
        private async Task ForceReconnectAsync(bool initializing = false)
        {
            long previousTicks = Interlocked.Read(ref this.lastReconnectTicks);
            var previousReconnectTime = new DateTimeOffset(previousTicks, TimeSpan.Zero);
            TimeSpan elapsedSinceLastReconnect = DateTimeOffset.UtcNow - previousReconnectTime;

            // We want to limit how often we perform this top-level reconnect, so we check how long it's been since our last attempt.
            if (elapsedSinceLastReconnect < this.reconnectMinInterval)
            {
                return;
            }

            bool lockTaken = await this.reconnectSemaphore.WaitAsync(this.estartConnectionTimeout);
            if (!lockTaken)
            {
                // If we fail to enter the semaphore, then it is possible that another thread has already done so.
                // ForceReconnectAsync() can be retried while connectivity problems persist.
                return;
            }

            try
            {
                var utcNow = DateTimeOffset.UtcNow;
                previousTicks = Interlocked.Read(ref this.lastReconnectTicks);
                previousReconnectTime = new DateTimeOffset(previousTicks, TimeSpan.Zero);
                elapsedSinceLastReconnect = utcNow - previousReconnectTime;

                if (this.firstErrorTime == DateTimeOffset.MinValue && !initializing)
                {
                    // We haven't seen an error since last reconnect, so set initial values.
                    this.firstErrorTime = utcNow;
                    this.previousErrorTime = utcNow;
                    return;
                }

                if (elapsedSinceLastReconnect < this.reconnectMinInterval)
                {
                    return; // Some other thread made it through the check and the lock, so nothing to do.
                }

                TimeSpan elapsedSinceFirstError = utcNow - this.firstErrorTime;
                TimeSpan elapsedSinceMostRecentError = utcNow - this.previousErrorTime;

                bool shouldReconnect =
                    elapsedSinceFirstError >= this.reconnectErrorThreshold // Make sure we gave the multiplexer enough time to reconnect on its own if it could.
                    && elapsedSinceMostRecentError <= this.reconnectErrorThreshold; // Make sure we aren't working on stale data (e.g. if there was a gap in errors, don't reconnect yet).

                // Update the previousErrorTime timestamp to be now (e.g. this reconnect request).
                this.previousErrorTime = utcNow;

                if (!shouldReconnect && !initializing)
                {
                    return;
                }

                this.firstErrorTime = DateTimeOffset.MinValue;
                this.previousErrorTime = DateTimeOffset.MinValue;

                // Create a new connection
                ConnectionMultiplexer _newConnection = await ConnectionMultiplexer.ConnectAsync(this.connectionString);

                // Swap current connection with the new connection
                ConnectionMultiplexer oldConnection = Interlocked.Exchange(ref this.connection, _newConnection);

                Interlocked.Exchange(ref this.lastReconnectTicks, utcNow.UtcTicks);
                IDatabase newDatabase = this.connection.GetDatabase();
                Interlocked.Exchange(ref this.database, newDatabase);

                if (oldConnection != null)
                {
                    try
                    {
                        await oldConnection.CloseAsync();
                    }
                    catch
                    {
                        // Ignore any errors from the old connection
                    }
                }
            }
            finally
            {
                this.reconnectSemaphore.Release();
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            try
            {
                this.connection?.Dispose();
            }
            catch
            {
                // An error occurred when disposing the connection.
            }
        }
    }
#pragma warning restore IDE0007 // Use implicit type
}
