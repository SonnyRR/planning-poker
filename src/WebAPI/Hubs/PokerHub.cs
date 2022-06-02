namespace PlanningPoker.WebAPI.Hubs
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.SignalR;

	using System.Threading.Tasks;

	/// <summary>
	/// SignalR hub for interacting with poker tables.
	/// </summary>
	[Authorize]
	public sealed class PokerHub : Hub
    {
		/// <summary>
		/// Adds a user to specified table.
		/// </summary>
		/// <param name="tableName">The table name.</param>
        public async Task AddToTable(string tableName)
        {
            await this.Groups.AddToGroupAsync(this.Context.ConnectionId, tableName);

            await this.Clients
                .Group(tableName)
                .SendAsync("AddedToTable", $"{this.Context.ConnectionId} has joined the group {tableName}.");
        }

		/// <summary>
		/// Removes a user from a specified table.
		/// </summary>
		/// <param name="tableName">The table name.</param>
        public async Task RemoveFromTable(string tableName)
        {
            await this.Groups.RemoveFromGroupAsync(this.Context.ConnectionId, tableName);

            await this.Clients
                .Group(tableName)
                .SendAsync("Send", $"{this.Context.ConnectionId} has left the group {tableName}.");
        }
    }
}
