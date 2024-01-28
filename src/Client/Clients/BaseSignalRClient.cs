namespace PlanningPoker.Client.Clients
{
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.SignalR.Client;
    using PlanningPoker.Client.Authorization;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    public abstract class BaseSignalRClient : ISignalRClient, IAsyncDisposable
    {
		private readonly HostAuthenticationStateProvider hostAuthenticationStateProvider;
        
        protected BaseSignalRClient(
            NavigationManager navigationManager,
            string hubPath,
            HostAuthenticationStateProvider hostAuthenticationStateProvider)
        {
            this.hostAuthenticationStateProvider = hostAuthenticationStateProvider;
            
            this.HubConnection = new HubConnectionBuilder()
                    .WithUrl(navigationManager.ToAbsoluteUri(hubPath))
                    .WithAutomaticReconnect()
                    .Build();
        }

        /// <summary>
        /// Flag which indicates if a connection is established.
        /// </summary>
        public bool IsConnected => this.HubConnection.State == HubConnectionState.Connected;

        /// <summary>
        /// Flag which indicates if a connection has already been started.
        /// </summary>
        protected bool HasStarted { get; private set; }

        /// <summary>
        /// The SignalR Hub connection.
        /// </summary>
        protected HubConnection HubConnection { get; }

        /// <summary>
        /// Disposes the connection.
        /// </summary>
        public async ValueTask DisposeAsync()
        {
            await this.DisposeAsync(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Starts a new connection if the <see cref="HasStarted"/> is <see cref="false"/>.
        /// </summary>
        public async Task Start()
        {
            if (!this.HasStarted)
            {
                try
                {
                    await this.HubConnection.StartAsync();
                    this.HasStarted = true;
                }
                catch (HttpRequestException ex)
                {
                    if (ex.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        this.hostAuthenticationStateProvider.SignIn();
                    }
                }
            }
        }

        protected virtual async Task DisposeAsync(bool disposing)
        {
            if (disposing && this.HubConnection != null)
            {
                await this.HubConnection.DisposeAsync();
            }
        }
    }
}
