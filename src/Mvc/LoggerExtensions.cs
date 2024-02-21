using Microsoft.Extensions.Logging;

namespace Dgmjr.AspNetCore.Mvc;

public static partial class LoggerExtensions
{
    // [LoggerMessage(
    //     EventId = 1,
    //     Level = LogLevel.Information,
    //     Message = "MvcServicesOptionsAutoConfigurator.Configure(WebApplicationBuilder)")]
    // public static partial void MvcServicesOptionsAutoConfiguratorConfigureWebApplicationBuilder(this ILogger logger);

    // [LoggerMessage(
    //     EventId = 2,
    //     Level = LogLevel.Information,
    //     Message = "MvcServicesOptionsAutoConfigurator.Configure(IApplicationBuilder)")]
    // public static partial void MvcServicesOptionsAutoConfiguratorConfigureIApplicationBuilder(this ILogger logger);

    [LoggerMessage(
        EventId = 3,
        Level = LogLevel.Information,
        Message = "MvcAutoConfigurator.Configure(WebApplicationBuilder)"
    )]
    public static partial void MvcAutoConfiguratorConfigureWebApplicationBuilder(
        this ILogger logger
    );

    [LoggerMessage(
        EventId = 4,
        Level = LogLevel.Information,
        Message = "MvcAutoConfigurator.Configure(IApplicationBuilder)"
    )]
    public static partial void MvcAutoConfiguratorConfigureIApplicationBuilder(this ILogger logger);

    [LoggerMessage(
        EventId = 5,
        Level = LogLevel.Information,
        Message = "Setting up Mvc service: {ServiceName}"
    )]
    public static partial void SettingUpMvcService(this ILogger logger, string serviceName);

    [LoggerMessage(
        EventId = 6,
        Level = LogLevel.Information,
        Message = "Setting up Mvc service: {ServiceName} with options: {Options}"
    )]
    public static partial void SettingUpMvcService(
        this ILogger logger,
        string serviceName,
        object options
    );

    [LoggerMessage(
        EventId = 7,
        Level = LogLevel.Information,
        Message = "Adding Mvc service to the pipeline: {ServiceName}"
    )]
    public static partial void AddingMvcServiceToThePipeline(
        this ILogger logger,
        string serviceName
    );
}
