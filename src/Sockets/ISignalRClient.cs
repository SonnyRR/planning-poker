namespace PlanningPoker.Sockets
{
    using System.Threading.Tasks;

    /// <summary>
    /// Interface that provides support for SignalR clients.
    ///</summary>
    public interface ISignalRClient
    {
        /// <summary>
        /// Flag that indicates that a connection to a given SignalR hub is established.
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Starts a new SignalR connection.
        /// </summary>
        Task Start();
    }
}