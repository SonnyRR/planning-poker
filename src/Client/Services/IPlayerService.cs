namespace PlanningPoker.Client.Services
{
	using System.Threading;
	using System.Threading.Tasks;

	/// <summary>
	/// Service for managing player interactions in the Blazor WASM client.
	/// </summary>
	public interface IPlayerService
	{
		/// <summary>
		/// Checks if the current player has entered an username.
		/// </summary>
		/// <returns>A flag which indicates if a username value is present.</returns>
		ValueTask<bool> CheckIfUsernameHasBeenEntered(CancellationToken? cancellationToken = null);

		/// <summary>
		/// Saves the username entered by the player to the local storage.
		/// </summary>
		/// <param name="userName">Username entered by the current visitor.</param>
		ValueTask SaveUsername(string userName, CancellationToken? cancellationToken = null);
	}
}
