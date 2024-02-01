using Microsoft.Extensions.Logging;

namespace Dgmjr.AspNetCore.Http.Services;

public static partial class LoggerExtensions
{
    [LoggerMessage(
        EventId = 1,
        Level = LogLevel.Information,
        Message = "HttpServicesOptionsAutoConfigurator.Configure(WebApplicationBuilder)")]
    public static partial void HttpServicesOptionsAutoConfiguratorConfigureWebApplicationBuilder(this ILogger logger);

    [LoggerMessage(
        EventId = 2,
        Level = LogLevel.Information,
        Message = "HttpServicesOptionsAutoConfigurator.Configure(IApplicationBuilder)")]
    public static partial void HttpServicesOptionsAutoConfiguratorConfigureIApplicationBuilder(this ILogger logger);

    // [LoggerMessage(
    //     EventId = 3,
    //     Level = LogLevel.Information,
    //     Message = "MvcAutoConfigurator.Configure(WebApplicationBuilder)")]
    // public static partial void MvcAutoConfiguratorConfigureWebApplicationBuilder(this ILogger logger);

    // [LoggerMessage(
    //     EventId = 4,
    //     Level = LogLevel.Information,
    //     Message = "MvcAutoConfigurator.Configure(IApplicationBuilder)")]
    // public static partial void MvcAutoConfiguratorConfigureIApplicationBuilder(this ILogger logger);

    [LoggerMessage(
        EventId = 5,
        Level = LogLevel.Information,
        Message = "Setting up HTTP service: {ServiceName}")]
    public static partial void SettingUpHttpService(this ILogger logger, string serviceName);

    [LoggerMessage(
        EventId = 6,
        Level = LogLevel.Information,
        Message = "Setting up HTTP service: {ServiceName} with options: {Options}")]
    public static partial void SettingUpHttpService(this ILogger logger, string serviceName, object options);

    [LoggerMessage(
        EventId = 7,
        Level = LogLevel.Information,
        Message = "Adding HTTP service to the pipeline: {ServiceName}")]
    public static partial void AddingHttpServiceToThePipeline(this ILogger logger, string serviceName);
}
