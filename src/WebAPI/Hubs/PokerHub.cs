namespace PlanningPoker.WebAPI.Hubs
{
	using Microsoft.AspNetCore.SignalR;

	using System.Threading.Tasks;

	public sealed class PokerHub : Hub
    {
        public async Task AddToTable(string tableName)
        {
            await this.Groups.AddToGroupAsync(this.Context.ConnectionId, tableName);

            await this.Clients
                .Group(tableName)
                .SendAsync("AddedToTable", $"{this.Context.ConnectionId} has joined the group {tableName}.");
        }

        public async Task RemoveFromTable(string tableName)
        {
            await this.Groups.RemoveFromGroupAsync(this.Context.ConnectionId, tableName);

            await this.Clients
                .Group(tableName)
                .SendAsync("Send", $"{this.Context.ConnectionId} has left the group {tableName}.");
        }
    }
}
