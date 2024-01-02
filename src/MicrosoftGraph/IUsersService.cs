namespace Dgmjr.MicrosoftGraph;

using Microsoft.Extensions.Logging;
using Microsoft.Graph;

public interface IUsersService : ILog
{
    Task<AppRoleAssignment> AssignToAppRoleAsync(string userId, string appId, string appRoleId);
    Task<AppRoleAssignment> AssignToAppRoleAsync(guid userId, guid appId, guid appRoleId);
    Task<User> CreateAsync(User user);
    Task DeleteAsync(string id);
    Task<User> GetAsync(string id);
    Task<User> GetAsync(string id, string property);
    Task<User> GetMeAsync();
    Task UnassignAppRoleAsync(string userId, string appId, string appRoleId);
    Task UnassignAppRoleAsync(guid userId, guid appId, guid appRoleId);
    Task<User> UpdateAsync(User user);
    Task<User> UpdateAsync(string id, User user);
    Task<User> UpdateAsync(string id, string property, string value);
}
