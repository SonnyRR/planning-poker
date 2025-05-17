namespace PlanningPoker.Core.Services
{
    using System;

    /// <summary>
    /// Retrieves metadata for the current user.
    /// </summary>
    public interface ICurrentUserService
    {
        /// <summary>
        /// The user's email address.
        /// </summary>
        string Email { get; }

        /// <summary>
        /// The unique identifier of the user.
        /// </summary>
        Guid UserId { get; }

        /// <summary>
        /// The username.
        /// </summary>
        string Username { get; }
    }
}