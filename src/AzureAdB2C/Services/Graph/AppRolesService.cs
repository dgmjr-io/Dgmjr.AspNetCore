namespace Dgmjr.AzureAdB2C.Services.Graph;

using System;
using System.Security.Claims;

using Dgmjr.AzureAdB2C.Models;
using Dgmjr.Graph.Constants;
using Dgmjr.Graph.Options;
using Dgmjr.Graph.Services;
using Dgmjr.Graph.TokenProviders;
using Dgmjr.AspNetCore.Authentication.Basic;

using Microsoft.Extensions.Options;
using Microsoft.Graph;
using System.Net.Http.Headers;
using Microsoft.Identity.Client;

public interface IAppRolesService
{
    Version Version { get; }

    Task<ApiResponse> GenerateClaimsAsync(
        ApiRequest request,
        CancellationToken cancellationToken = default
    );
}

public class AppRolesService(
    IOptionsMonitor<Dgmjr.AzureAd.Web.MicrosoftIdentityOptions> msidOptions,
    IOptions<Version> version,
    IOptions<AzureAdB2CGraphOptions> graphClientOptions,
    GraphServiceClient graph,
    ILogger<AppRolesService> logger
) : IClaimsGenerator, IAppRolesService, ILog
{
    public ILogger Logger => logger;
    private readonly Dgmjr.AzureAd.Web.MicrosoftIdentityOptions _msidOptions =
        msidOptions.CurrentValue;
    public Version Version => version.Value;

    private string clientId => _msidOptions.ClientId;
    private string clientSecret => _msidOptions.ClientSecret;
    private string tenantId => _msidOptions.TenantId;

    private GraphServiceClient _graph;
    private GraphServiceClient Graph => _graph ??= GetGraphServiceClient().Result;

    private readonly AzureAdB2CGraphOptions _graphClientOptions = graphClientOptions.Value;

    public async Task<ApiResponse> GenerateClaimsAsync(
        ApiRequest request,
        CancellationToken cancellationToken = default
    )
    {
        Logger.LogDebug("request: {request}", request);

        var app = await Graph.Applications[
            _graphClientOptions.AzureAdB2CExtensionsApplicationId.ToString()
        ]
            .Request()
            .GetAsync(cancellationToken);
        Logger.LogDebug("app: {app}", app);

        var user = await Graph.Users[request.ObjectId.ToString()]
            // .Request(new Option[] { new QueryOption("$expand", "appRoleAssignments") })
            .Request()
            .Expand("appRoleAssignments")
            .GetAsync(cancellationToken);
        Logger.LogDebug("user: {user}", user);

        var appRoles = app.AppRoles;
        var myAppRoles = user.AppRoleAssignments
            .Where(x => x.ResourceId == _graphClientOptions.AzureAdB2CExtensionsApplicationId)
            .ToList();
        var myAppsAppRoles = myAppRoles.Select(
            appRole => appRoles.FirstOrDefault(x => x.Id.ToString() == appRole.Id)
        );
        return new ApiContinueResponse
        {
            Claims = new StringDictionary() { { ClaimTypes.Role, Serialize(myAppsAppRoles) } },
            Version = Version
        };
    }


    private async Task<GraphServiceClient> GetGraphServiceClient()
    {
        var app = ConfidentialClientApplicationBuilder
            .Create(clientId)
            .WithClientSecret(clientSecret)
            .WithAuthority($"https://login.microsoftonline.com/{tenantId}")
            .Build();

        var authResult = await app.AcquireTokenForClient(new[] { "https://graph.microsoft.com/.default" })
            .ExecuteAsync();

        var graphClient = new GraphServiceClient(
            new DelegateAuthenticationProvider((requestMessage) =>
            {
                requestMessage.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", authResult.AccessToken);

                return Task.CompletedTask;
            }));
        return graphClient;
    }


    //     public static async Task<List<string>> GetApplicationRolesForUserAsync(string userId)
    //     {
    //         var applicationRoles = new List<string>();

    //         var app = ConfidentialClientApplicationBuilder
    //             .Create(clientId)
    //             .WithClientSecret(clientSecret)
    //             .WithAuthority($"https://login.microsoftonline.com/{tenantId}")
    //             .Build();

    //         var authResult = await app.AcquireTokenForClient(new[] { "https://graph.microsoft.com/.default" })
    //             .ExecuteAsync();

    //         var graphClient = new GraphServiceClient(
    //             new DelegateAuthenticationProvider((requestMessage) =>
    //             {
    //                 requestMessage.Headers.Authorization =
    //                     new AuthenticationHeaderValue("Bearer", authResult.AccessToken);

    //                 return Task.CompletedTask;
    //             }));

    //         try
    //         {
    //             // Query Microsoft Graph to get the user's assigned directory roles
    //             var userDirectoryRoles = await graphClient.Users[userId].MemberOf.Request().GetAsync();

    //             foreach (var directoryRole in userDirectoryRoles.OfType<DirectoryRole>())
    //             {
    //                 // Query each directory role to get its assigned application roles
    //                 var applicationRoleAssignments = await graphClient.DirectoryRoles[directoryRole.Id].AppRoleAssignedTo.Request().GetAsync();

    //                 foreach (var applicationRoleAssignment in applicationRoleAssignments)
    //                 {
    //                     applicationRoles.Add(applicationRoleAssignment.AppRoleId);
    //                 }
    //             }
    //         }
    //         catch (ServiceException ex)
    //         {
    //             Console.WriteLine($"Error retrieving application roles: {ex.Message}");
    //         }

    //         return applicationRoles;
    //     }

    //     public static async Task Main(string[] args)
    //     {
    //         string userId = "user_id_goes_here";
    //         List<string> applicationRoles = await GetApplicationRolesForUserAsync(userId);

    //         // Print the application roles for the user
    //         foreach (var role in applicationRoles)
    //         {
    //             Console.WriteLine(role);
    //         }
    //     }
    // }
}
