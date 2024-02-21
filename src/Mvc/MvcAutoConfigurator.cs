namespace Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Builder;
using Dgmjr.Configuration.Extensions;
using static Microsoft.Extensions.DependencyInjection.IHostApplicationBuilderMvcExtensions;
using Microsoft.Extensions.Logging;
using Dgmjr.Abstractions;

public class MvcAutoConfigurator(ILogger<MvcAutoConfigurator> logger)
    : IConfigureIHostApplicationBuilder,
        IConfigureIApplicationBuilder,
        ILog
{
    public ILogger? Logger => logger;
private const string Mvc = nameof(Mvc);
private const string JsonSerializer = nameof(JsonSerializer);
public ConfigurationOrder Order => ConfigurationOrder.Late;

public void Configure(WebApplicationBuilder builder)
{
    Logger?.MvcAutoConfiguratorConfigureWebApplicationBuilder();
    builder.AddMvc(Mvc, Logger);
}

public void Configure(IApplicationBuilder builder)
{
    Logger.MvcAutoConfiguratorConfigureIApplicationBuilder();
    builder.UseMvc(Mvc, Logger);
}
}
