using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Dgmjr.AspNetCore.Middleware.RequestLogging;

public static partial class LoggerExtensions
{
    [LoggerMessage(EventId = 1, Level = LogLevel.Information, Message = "Begin Request: {Message}", EventName = "BeginRequest")]
    public static partial void LogBeginRequest(this ILogger logger, HttpContext context, string message = null, params object[] args);
}
