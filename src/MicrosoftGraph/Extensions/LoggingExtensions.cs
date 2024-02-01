namespace Dgmjr.Graph;
using System.Security.Claims;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

using ClaimsPrincipal = System.Security.Claims.ClaimsPrincipal;

internal static partial class LoggingExtensions
{
    [LoggerMessage(
        EventId = 1,
        Level = LogLevel.Information,
        Message = "Beginning supplementary token acquisition and creation for user {User}",
        EventName = nameof(BeginningSupplementaryTokenAcquisitionAndCreation)
    )]
    public static partial void BeginningSupplementaryTokenAcquisitionAndCreation(
        this ILogger logger,
        ClaimsPrincipal user
    );

    [LoggerMessage(
        EventId = 2,
        Level = LogLevel.Information,
        Message = "Supplementary token acquisition and creation for user {User} completed",
        EventName = nameof(SupplementaryTokenAcquisitionAndCreationComplete)
    )]
    public static partial void SupplementaryTokenAcquisitionAndCreationComplete(
        this ILogger logger,
        ClaimsPrincipal user
    );

    [LoggerMessage(
        EventId = 3,
        Level = LogLevel.Information,
        Message = "Authentication failed: {Exception}",
        EventName = nameof(AuthenticationFailed)
    )]
    public static partial void AuthenticationFailed(
        this ILogger logger,
        Exception exception
    );

    [LoggerMessage(
        EventId = 4,
        Level = LogLevel.Information,
        Message = "Authorization code received: {TokenEndpointResponse}",
        EventName = nameof(AuthorizationCodeReceived)
    )]
    public static partial void AuthorizationCodeReceived(
        this ILogger logger,
        OpenIdConnectMessage tokenEndpointResponse
    );

    [LoggerMessage(
        EventId = 5,
        Level = LogLevel.Information,
        Message = "Message received: {ProtocolMessage}",
        EventName = nameof(MessageReceived)
    )]
    public static partial void MessageReceived(
        this ILogger logger,
        OpenIdConnectMessage protocolMessage
    );

    [LoggerMessage(
        EventId = 6,
        Level = LogLevel.Information,
        Message = "Redirect to identity provider: {ProtocolMessage}",
        EventName = nameof(RedirectToIdentityProvider)
    )]
    public static partial void RedirectToIdentityProvider(
        this ILogger logger,
        OpenIdConnectMessage protocolMessage
    );

    [LoggerMessage(
        EventId = 7,
        Level = LogLevel.Information,
        Message = "Remote failure: {Failure}",
        EventName = nameof(RemoteFailure)
    )]
    public static partial void RemoteFailure(
        this ILogger logger,
        Exception? failure
    );


    //     [LoggerMessage(
    //         EventId = 1,
    //         Level = LogLevel.Information,
    //         Message = "{Method} {Path}",
    //         EventName = nameof(PageVisited)
    //     )]
    //     public static partial void PageVisited(
    //         this ILogger logger,
    //         System.Net.Http.HttpMethod method,
    //         string path
    //     );

    //     [LoggerMessage(
    //         EventId = 1,
    //         Level = LogLevel.Information,
    //         Message = "{Method} {Path}",
    //         EventName = nameof(PageVisited)
    //     )]
    //     public static partial void PageVisited(this ILogger logger, string method, string path);
}
