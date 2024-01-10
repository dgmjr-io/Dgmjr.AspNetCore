namespace Dgmjr.AspNetCore.Middleware.RequestLogging;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

public class RequestLoggingMiddleware(ILogger<RequestLoggingMiddleware> logger) : IMiddleware
{
    public ILogger Logger => logger;

public Task InvokeAsync(HttpContext context, RequestDelegate next)
{
    throw new NotImplementedException();
}
}
