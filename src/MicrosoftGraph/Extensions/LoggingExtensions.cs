namespace Dgmjr.Graph;

public static partial class LoggingExtensions
{
    [LoggerMessage(EventId = 1, Level = LogLevel.Information, Message = "{Method} {Path}", EventName = nameof(PageVisited))]
    public static partial void PageVisited(this ILogger logger, System.Net.Http.HttpMethod method, string path);
    [LoggerMessage(EventId = 1, Level = LogLevel.Information, Message = "{Method} {Path}", EventName = nameof(PageVisited))]
    public static partial void PageVisited(this ILogger logger, string method, string path);
}
