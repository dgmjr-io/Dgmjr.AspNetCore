using System.Security.Claims;

namespace Dgmjr.Graph;

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
