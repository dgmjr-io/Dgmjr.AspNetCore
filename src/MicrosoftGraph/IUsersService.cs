namespace Dgmjr.MicrosoftGraph;

using Microsoft.Extensions.Logging;
using Microsoft.Graph;

public interface IUsersService : ILog
{
    guid ExtensionsAppClientId { get; }
    Task<AppRoleAssignment> AssignToAppRoleAsync(string userId, string appId, string appRoleId, CancellationToken cancellationToken);
    Task<AppRoleAssignment> AssignToAppRoleAsync(guid userId, guid appId, guid appRoleId, CancellationToken cancellationToken);
    Task<User> CreateAsync(User user, CancellationToken cancellationToken);
    Task DeleteAsync(string id, CancellationToken cancellationToken);
    Task<User> GetAsync(string id, CancellationToken cancellationToken);
    Task<User> GetAsync(string id, string property, CancellationToken cancellationToken);
    Task<MgExtensionProperty[]> GetExtensionPropertiesAsync(CancellationToken cancellationToken);
    Task<User> GetMeAsync(CancellationToken cancellationToken);
    Task<User?> FindBySignInNameAsync(string name, CancellationToken cancellationToken);
    Task<List<User>> GetUsersWithCustomAttribute(
        GraphServiceClient graphClient,
        string attributeName, CancellationToken cancellationToken
    );
    Task<bool> IsInAppRoleAsync(string id, string appId, string appRoleId, CancellationToken cancellationToken);
    Task SetPasswordByUserId(
        string userId,
        string password,
        bool forceChangePasswordNextSignIn = false,
        CancellationToken cancellationToken = default
    );
    Task UnassignAppRoleAsync(string userId, string appId, string appRoleId, CancellationToken cancellationToken);
    Task UnassignAppRoleAsync(guid userId, guid appId, guid appRoleId, CancellationToken cancellationToken);
    Task<User> UpdateAsync(User user, CancellationToken cancellationToken);
    Task<User> UpdateAsync(string id, User user, CancellationToken cancellationToken);
    Task<User> UpdateAsync(string id, string property, string value, CancellationToken cancellationToken);
}
