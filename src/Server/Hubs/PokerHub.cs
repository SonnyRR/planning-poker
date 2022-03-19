using System.Threading.Tasks;

using Microsoft.AspNetCore.SignalR;

namespace PlanningPoker.Server.Hubs
{
    public sealed class PokerHub : Hub
    {
        public async Task AddToTable(string tableName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, tableName);

            await Clients
                .Group(tableName)
                .SendAsync("AddedToTable", $"{Context.ConnectionId} has joined the group {tableName}.");
        }

        public async Task RemoveFromTable(string tableName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, tableName);

            await Clients
                .Group(tableName)
                .SendAsync("Send", $"{Context.ConnectionId} has left the group {tableName}.");
        }
    }
}
