namespace Dgmjr.Graph.Services;

public class UsersService(GraphServiceClient graph, ILogger<UsersService> logger, IOptionsMonitor<MicrosoftB2CGraphOptions> options, IOptionsMonitor<MicrosoftIdentityOptions> msidOptions, IDistributedCache cache) : MsGraphService(graph, logger, options, msidOptions, cache), IUsersService
{
    public async Task<User> GetMeAsync(CancellationToken cancellationToken = default)
{
    return await Graph.Me.Request().GetAsync(cancellationToken);
}
public async Task<guid> GetMyIdAsync(CancellationToken cancellationToken = default)
{
    return new((await GetMeAsync(cancellationToken)).Id);
}

public async Task<User> UpdateAsync(User user, CancellationToken cancellationToken = default)
{
    return await Graph.Users[user.Id].Request().UpdateAsync(user, cancellationToken);
}

public async Task<User> UpdateAsync(guid id, string property, string value, CancellationToken cancellationToken = default)
    => await UpdateAsync(id.ToString(), property, value, cancellationToken);

public async Task<User> UpdateAsync(string id, string property, string value, CancellationToken cancellationToken = default)
{
    var user = await Graph.Users[id].Request().GetAsync(cancellationToken);
    user.AdditionalData[property] = value;
    return await Graph.Users[id].Request().UpdateAsync(user, cancellationToken);
}

public async Task<User> GetAsync(string id, CancellationToken cancellationToken = default)
{
    return await Graph.Users[id].Request().GetAsync(cancellationToken);
}

public async Task<User> GetAsync(string id, string property, CancellationToken cancellationToken = default)
{
    var extensionPropertyName = (property, ExtensionsAppClientId).GetExtensionPropertyName();
    return await Graph.Users[id].Request().Select(property).Select(extensionPropertyName).GetAsync(cancellationToken);
}

public async Task<User> CreateAsync(User user, CancellationToken cancellationToken = default)
{
    return await Graph.Users.Request().AddAsync(user, cancellationToken);
}

public async Task DeleteAsync(string id, CancellationToken cancellationToken = default)
{
    await Graph.Users[id].Request().DeleteAsync(cancellationToken);
}

public async Task<bool> IsInAppRoleAsync(string id, string appId, string appRoleId, CancellationToken cancellationToken = default)
    => (await Graph.Users[id].Request().GetAsync(cancellationToken)).AppRoleAssignments.Any(a => a.AppRoleId == new guid(appRoleId) && a.ResourceId == new guid(appId));

public async Task<AppRoleAssignment> AssignToAppRoleAsync(string userId, string appId, string appRoleId, CancellationToken cancellationToken = default)
    => await AssignToAppRoleAsync(new guid(userId), new guid(appId), new guid(appRoleId), cancellationToken);

public async Task<AppRoleAssignment> AssignToAppRoleAsync(guid userId, guid appId, guid appRoleId, CancellationToken cancellationToken = default)
{
    return await Graph.Users[userId.ToString()].AppRoleAssignments.Request().AddAsync(new AppRoleAssignment
    {
        PrincipalId = userId,
        ResourceId = appId,
        AppRoleId = appRoleId
    }, cancellationToken);
}

public async Task UnassignAppRoleAsync(string userId, string appId, string appRoleId, CancellationToken cancellationToken = default)
    => await UnassignAppRoleAsync(new guid(userId), new(appId), new(appRoleId), cancellationToken);

public async Task UnassignAppRoleAsync(guid userId, guid appId, guid appRoleId, CancellationToken cancellationToken = default)
{
    var assignments = await Graph.Users[userId.ToString()].AppRoleAssignments.Request().GetAsync(cancellationToken);
    var assignment = assignments.FirstOrDefault(a => a.AppRoleId == appRoleId && a.ResourceId == appId) ?? throw new KeyNotFoundException($"No app role assignment found for user {userId} with app {appId} and role {appRoleId}");
    await Graph.Users[userId.ToString()].AppRoleAssignments[assignment.Id].Request().DeleteAsync(cancellationToken);
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
            .UpdateAsync(user, cancellationToken);

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
    var extensionAttribute = new DGraphExtensionProperty(attributeName, ExtensionsAppClientId);

    Logger.LogInformation($"Getting list of users with the custom attributes '{attributeName}' (string)");

    // Get all users (one page)
    var result = await graphClient.Users
        .Request()
        .Select($"id,displayName,identities,{extensionAttribute}")
        .GetAsync(cancellationToken);

    return [..result];
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
