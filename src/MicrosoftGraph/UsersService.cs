namespace Dgmjr.MicrosoftGraph;

using Microsoft.Extensions.Logging;
using Microsoft.Graph;



public class UsersService(GraphServiceClient graph, ILogger<UsersService> logger) : IUsersService
{
    public ILogger Logger => logger;

    protected virtual GraphServiceClient Graph => graph;

    public async Task<User> GetMeAsync()
    {
        return await Graph.Me.Request().GetAsync();
    }

    public async Task<User> UpdateAsync(User user)
    {
        return await Graph.Me.Request().UpdateAsync(user);
    }

    public async Task<User> GetAsync(string id)
    {
        return await Graph.Users[id].Request().GetAsync();
    }

    public async Task<User> UpdateAsync(string id, User user)
    {
        return await Graph.Users[id].Request().UpdateAsync(user);
    }

    public async Task<User> CreateAsync(User user)
    {
        return await Graph.Users.Request().AddAsync(user);
    }

    public async Task DeleteAsync(string id)
    {
        await Graph.Users[id].Request().DeleteAsync();
    }

    public async Task<User> GetAsync(string id, string property)
    {
        return await Graph.Users[id].Request().Select(property).GetAsync();
    }

    public async Task<User> UpdateAsync(string id, string property, string value)
    {
        var user = await Graph.Users[id].Request().GetAsync();
        user.AdditionalData[property] = value;
        return await Graph.Users[id].Request().UpdateAsync(user);
    }

    public async Task<bool> IsInAppRoleAsync(string id, string appId, string appRoleId)
        => await Grahph.Users[userId].Request().

    public async Task<AppRoleAssignment> AssignToAppRoleAsync(string userId, string appId, string appRoleId)
        => await AssignToAppRoleAsync(new guid(userId), new guid(appId), new guid(appRoleId));

    public async Task<AppRoleAssignment> AssignToAppRoleAsync(guid userId, guid appId, guid appRoleId)
    {
        return await Graph.Users[userId.ToString()].AppRoleAssignments.Request().AddAsync(new AppRoleAssignment
        {
            PrincipalId = userId,
            ResourceId = appId,
            AppRoleId = appRoleId
        });
    }

    public async Task UnassignAppRoleAsync(string userId, string appId, string appRoleId)
        => await UnassignAppRoleAsync(new guid(userId), new(appId), new(appRoleId));

    public async Task UnassignAppRoleAsync(guid userId, guid appId, guid appRoleId)
    {
        var assignments = await Graph.Users[userId.ToString()].AppRoleAssignments.Request().GetAsync();
        var assignment = assignments.FirstOrDefault(a => a.AppRoleId == appRoleId && a.ResourceId == appId);
        if (assignment is null)
        {
            throw new KeyNotFoundException($"No app role assignment found for user {userId} with app {appId} and role {appRoleId}");
        }
        await Graph.Users[userId.ToString()].AppRoleAssignments[assignment.Id].Request().DeleteAsync();
    }


    public async Task GetUserBySignInName(string name)
    {
        try
        {
            // Get user by sign-in name
            var result = await Graph.Users
                .Request()
                .Filter($"identities/any(c:c/issuerAssignedId eq '{name}'")
                .Select(e => new
                {
                    e.DisplayName,
                    e.Id,
                    e.Identities
                })
                .GetAsync();

            if (result != null)
            {
                Console.WriteLine(JsonSerializer.Serialize(result));
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }
    }

    public async Task SetPasswordByUserId(string userId, string password, bool forceChangePasswordNextSignIn = false)
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

           public static async Task<List<User>> GetUsersWithCustomAttribute(GraphServiceClient graphClient, string b2cExtensionAppClientId)
        {
            if (string.IsNullOrWhiteSpace(b2cExtensionAppClientId))
            {
                throw new ArgumentException("B2cExtensionAppClientId (its Application ID) is missing from appsettings.json. Find it in the App registrations pane in the Azure portal. The app registration has the name 'b2c-extensions-app. Do not modify. Used by AADB2C for storing user data.'.", nameof(b2cExtensionAppClientId));
            }

            // Declare the names of the custom attributes
            const string customAttributeName1 = "FavouriteSeason";
            const string customAttributeName2 = "LovesPets";

            // Get the complete name of the custom attribute (Azure AD extension)
            Helpers.B2cCustomAttributeHelper helper = new Helpers.B2cCustomAttributeHelper(b2cExtensionAppClientId);
            string favouriteSeasonAttributeName = helper.GetCompleteAttributeName(customAttributeName1);
            string lovesPetsAttributeName = helper.GetCompleteAttributeName(customAttributeName2);

            Console.WriteLine($"Getting list of users with the custom attributes '{customAttributeName1}' (string) and '{customAttributeName2}' (boolean)");
            Console.WriteLine();

            // Get all users (one page)
            var result = await graphClient.Users
                .Request()
                .Select($"id,displayName,identities,{favouriteSeasonAttributeName},{lovesPetsAttributeName}")
                .GetAsync();

            foreach (var user in result.CurrentPage)
            {
                Console.WriteLine(JsonSerializer.Serialize(user));

                // Only output the custom attributes...
                //Console.WriteLine(JsonSerializer.Serialize(user.AdditionalData));
            }
        }

    // public async Task RemoveAppRoleByNameAsync(string userId, string appId, string appRoleName)
    //     => await RemoveAppRoleByNameAsync(new guid(userId), new (appId), appRoleName);

    // public async Task RemoveAppRoleByNameAsync(guid userId, guid appId, string appRoleName)
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

    // public async Task<User> GetAsync(string id, string property, string value)
    // {
    //     return await Graph.Users[id].Request().Filter($"{property} eq '{value}'").GetAsync();
    // }
}
