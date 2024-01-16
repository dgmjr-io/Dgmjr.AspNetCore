namespace Dgmjr.Graph.Abstractions;

using Microsoft.Extensions.Logging;
using Microsoft.Graph;

public interface IUsersService : IMsGraphService
{
    /// <summary>
    /// Assigns an app role to a user asynchronously.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="appId">The ID of the app.</param>
    /// <param name="appRoleId">The ID of the app role.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the assigned app role.</returns>
    Task<AppRoleAssignment> AssignToAppRoleAsync(
        string userId,
        string appId,
        string appRoleId,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Assigns an app role to a user asynchronously.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="appId">The ID of the app.</param>
    /// <param name="appRoleId">The ID of the app role.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the assigned app role.</returns>
    Task<AppRoleAssignment> AssignToAppRoleAsync(
        guid userId,
        guid appId,
        guid appRoleId,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a user asynchronously.
    /// </summary>
    /// <param name="user">The user object to create.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the created user.</returns>
    Task<User> CreateAsync(User user, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a user asynchronously based on their ID.
    /// </summary>
    /// <param name="id">The ID of the user to delete.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a user asynchronously based on their ID.
    /// </summary>
    /// <param name="id">The ID of the user to get.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the retrieved user.</returns>
    Task<User> GetAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a user asynchronously based on their ID and a specific property.
    /// </summary>
    /// <param name="id">The ID of the user to get.</param>
    /// <param name="property">The specific property to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the retrieved user.</returns>
    Task<User> GetAsync(string id, string property, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets extension properties asynchronously.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains an array of extension properties.</returns>
    Task<MgExtensionProperty[]> GetExtensionPropertiesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the currently logged-in user asynchronously.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the current user.</returns>
    Task<User> GetMeAsync(CancellationToken cancellationToken = default);

    /// <summary>Gets the ID of the currently logged-in user asynchronously.</summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    Task<guid> GetMyIdAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Finds a user by their sign-in name asynchronously.
    /// </summary>
    /// <param name="name">The sign-in name of the user.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the found user, or null if not found.</returns>
    Task<User?> FindBySignInNameAsync(string name, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a list of users with a specific custom attribute.
    /// </summary>
    /// <param name="graphClient">The GraphServiceClient instance.</param>
    /// <param name="attributeName">The name of the custom attribute.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains a list of users with the specified custom attribute.</returns>
    Task<List<User>> GetUsersWithCustomAttribute(
        GraphServiceClient graphClient,
        string attributeName,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Checks if a user is in an app role asynchronously.
    /// </summary>
    /// <param name="id">The ID of the user.</param>
    /// <param name="appId">The ID of the app.</param>
    /// <param name="appRoleId">The ID of the app role.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean value indicating whether the user is in the app role.</returns>
    Task<bool> IsInAppRoleAsync(
        string id,
        string appId,
        string appRoleId,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sets the password for a user by user ID asynchronously.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="password">The new password for the user.</param>
    /// <param name="forceChangePasswordNextSignIn">Optional. Specifies whether the user should be forced to change the password on the next sign-in. Default is false.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task SetPasswordByUserId(
        string userId,
        string password,
        bool forceChangePasswordNextSignIn = false,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Unassigns an app role from a user asynchronously.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="appId">The ID of the app.</param>
    /// <param name="appRoleId">The ID of the app role.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task UnassignAppRoleAsync(
        string userId,
        string appId,
        string appRoleId,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Unassigns an app role from a user asynchronously.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="appId">The ID of the app.</param>
    /// <param name="appRoleId">The ID of the app role.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task UnassignAppRoleAsync(
        guid userId,
        guid appId,
        guid appRoleId,
        CancellationToken cancellationToken = default
    );

    /// <summary>Updates a user property asynchronously.</summary>
    /// <param name="id">The ID of the user to update.</param>
    /// <param name="property">The name of the property to update.</param>
    /// <param name="value">The new value for the property.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    Task<User> UpdateAsync(guid id, string property, string value, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates a user asynchronously.
    /// </summary>
    /// <param name="user">The updated user object.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated user object.</returns>
    Task<User> UpdateAsync(User user, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates a user property asynchronously.
    /// </summary>
    /// <param name="id">The ID of the user to update.</param>
    /// <param name="property">The name of the property to update.</param>
    /// <param name="value">The new value for the property.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated user object.</returns>
    Task<User> UpdateAsync(
        string id,
        string property,
        string value,
        CancellationToken cancellationToken = default
    );
}
