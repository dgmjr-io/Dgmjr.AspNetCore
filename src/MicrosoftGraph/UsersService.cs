namespace Dgmjr.MicrosoftGraph;

using Models;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;
using Microsoft.Extensions.Options;

public class UsersService(GraphServiceClient graph, ILogger<UsersService> logger, IOptionsMonitor<MicrosoftB2CGraphOptions> options, CancellationToken cancellationToken = default) : IUsersService
{
    public ILogger Logger => logger;
private MicrosoftB2CGraphOptions _options => options.CurrentValue;
public guid ExtensionsAppClientId => _options.AzureAdB2CExtensionsApplicationId;

protected virtual GraphServiceClient Graph => graph;

public async Task<User> GetMeAsync(CancellationToken cancellationToken = default)
{
    return await Graph.Me.Request().GetAsync();
}

public async Task<User> UpdateAsync(User user, CancellationToken cancellationToken = default)
{
    return await Graph.Me.Request().UpdateAsync(user);
}

public async Task<User> UpdateAsync(string id, User user, CancellationToken cancellationToken = default)
{
    return await Graph.Users[id].Request().UpdateAsync(user);
}

public async Task<User> UpdateAsync(string id, string property, string value, CancellationToken cancellationToken = default)
{
    var user = await Graph.Users[id].Request().GetAsync();
    user.AdditionalData[property] = value;
    return await Graph.Users[id].Request().UpdateAsync(user);
}

public async Task<User> GetAsync(string id, CancellationToken cancellationToken = default)
{
    return await Graph.Users[id].Request().GetAsync();
}

public async Task<User> GetAsync(string id, string property, CancellationToken cancellationToken = default)
{
    return await Graph.Users[id].Request().Select(property).GetAsync();
}

public async Task<User> CreateAsync(User user, CancellationToken cancellationToken = default)
{
    return await Graph.Users.Request().AddAsync(user);
}

public async Task DeleteAsync(string id, CancellationToken cancellationToken = default)
{
    await Graph.Users[id].Request().DeleteAsync();
}

public async Task<bool> IsInAppRoleAsync(string id, string appId, string appRoleId, CancellationToken cancellationToken = default)
    => (await Graph.Users[id].Request().GetAsync()).AppRoleAssignments.Any(a => a.AppRoleId == new guid(appRoleId) && a.ResourceId == new guid(appId));

public async Task<AppRoleAssignment> AssignToAppRoleAsync(string userId, string appId, string appRoleId, CancellationToken cancellationToken = default)
    => await AssignToAppRoleAsync(new guid(userId), new guid(appId), new guid(appRoleId));

public async Task<AppRoleAssignment> AssignToAppRoleAsync(guid userId, guid appId, guid appRoleId, CancellationToken cancellationToken = default)
{
    return await Graph.Users[userId.ToString()].AppRoleAssignments.Request().AddAsync(new AppRoleAssignment
    {
        PrincipalId = userId,
        ResourceId = appId,
        AppRoleId = appRoleId
    });
}

public async Task UnassignAppRoleAsync(string userId, string appId, string appRoleId, CancellationToken cancellationToken = default)
    => await UnassignAppRoleAsync(new guid(userId), new(appId), new(appRoleId));

public async Task UnassignAppRoleAsync(guid userId, guid appId, guid appRoleId, CancellationToken cancellationToken = default)
{
    var assignments = await Graph.Users[userId.ToString()].AppRoleAssignments.Request().GetAsync();
    var assignment = assignments.FirstOrDefault(a => a.AppRoleId == appRoleId && a.ResourceId == appId);
    if (assignment is null)
    {
        throw new KeyNotFoundException($"No app role assignment found for user {userId} with app {appId} and role {appRoleId}");
    }
    await Graph.Users[userId.ToString()].AppRoleAssignments[assignment.Id].Request().DeleteAsync();
}

public async Task<User?> FindByEmailAsync(
    string normalizedEmail,
    CancellationToken cancellationToken = default
)
{
    return (
        await Graph.Users
            .Request()
            .Filter($"mail eq '{normalizedEmail}'")
            .GetAsync(cancellationToken)
    ).FirstOrDefault();
}

public async Task<User?> FindBySignInNameAsync(string name, CancellationToken cancellationToken = default)
{
    try
    {
        // Get user by sign-in name
        var result = (await Graph.Users
            .Request()
            .Filter($"identities/any(c:c/issuerAssignedId eq '{name}')")
            .Select(e => new
            {
                e.DisplayName,
                e.Id,
                e.Identities
            })
            .GetAsync(cancellationToken))
            .SingleOrDefault();

        if (result != null)
        {
            Logger.LogInformation(Serialize(result));
            return result;
        }

        Logger.LogError($"User  with login name {name} not found.");
        return null;
    }
    catch (Exception ex)
    {
        Logger.LogError(ex, "Error retrieving user by sign-in name.");
    }

    return null;
}

public async Task SetPasswordByUserId(string userId, string password, bool forceChangePasswordNextSignIn = false, CancellationToken cancellationToken = default)
{
    Logger.LogInformation($"Looking for user with object ID '{userId}'...");

    var user = new User
    {
        PasswordPolicies = "DisablePasswordExpiration,DisableStrongPassword",
        PasswordProfile = new PasswordProfile
        {
            ForceChangePasswordNextSignIn = forceChangePasswordNextSignIn,
            Password = password,
        }
    };

    try
    {
        // Update user by object ID
        await Graph.Users[userId]
            .Request()
            .UpdateAsync(user);

        Logger.LogInformation($"User with object ID '{userId}' successfully updated.");
    }
    catch (ClientException ex)
    {
        Logger.LogError(ex, $"Error updating user with object ID '{userId}'.");
        throw;
    }
}

public async Task<List<User>> GetUsersWithCustomAttribute(GraphServiceClient graphClient, string attributeName, CancellationToken cancellationToken = default)
{
    var extensionAttribute = new DgmjrExtensionProperty(attributeName, ExtensionsAppClientId);

    Logger.LogInformation($"Getting list of users with the custom attributes '{attributeName}' (string)");

    // Get all users (one page)
    var result = await graphClient.Users
        .Request()
        .Select($"id,displayName,identities,{extensionAttribute}")
        .GetAsync();

    return [..result];

    // foreach (var user in result.CurrentPage)
    // {
    //     Console.WriteLine(Serialize(user));

    //     // Only output the custom attributes...
    //     //Console.WriteLine(JsonSerializer.Serialize(user.AdditionalData));
    // }
}

public async Task<MgExtensionProperty[]> GetExtensionPropertiesAsync(CancellationToken cancellationToken = default)
{

    var extensionProperties = await Graph.Applications[ExtensionsAppClientId.ToString()].ExtensionProperties.Request().GetAsync();
    return extensionProperties.AsEnumerable().ToArray();
}

// public async Task RemoveAppRoleByNameAsync(string userId, string appId, string appRoleName, CancellationToken cancellationToken = default)
//     => await RemoveAppRoleByNameAsync(new guid(userId), new (appId), appRoleName);

// public async Task RemoveAppRoleByNameAsync(guid userId, guid appId, string appRoleName, CancellationToken cancellationToken = default)
// {
//     var assignments = await Graph.Users[userId.ToString()].AppRoleAssignments.Request().GetAsync();
//     graph..AppRoles.Request().Filter($"displayName eq '{appRoleName}'").GetAsync();
//     var assignment = assignments.FirstOrDefault(a => a..AppRoleId == appRoleId && a.ResourceId == appId);
//     if (assignment is null)
//     {
//         throw new KeyNotFoundException($"No app role assignment found for user {userId} with app {appId} and role {appRoleId}");
//     }
//     await Graph.Users[userId.ToString()].AppRoleAssignments[assignment.Id].Request().DeleteAsync();
// }

// public async Task<User> GetAsync(string id, string property, string value, CancellationToken cancellationToken = default)
// {
//     return await Graph.Users[id].Request().Filter($"{property} eq '{value}'").GetAsync();
// }
}
