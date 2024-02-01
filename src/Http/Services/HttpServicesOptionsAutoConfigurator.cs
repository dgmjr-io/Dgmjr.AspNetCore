namespace Microsoft.Extensions.DependencyInjection;

using Dgmjr.AspNetCore.Http.Services;
using Dgmjr.Configuration.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class HttpServicesOptionsAutoConfigurator(ILogger<HttpServicesOptionsAutoConfigurator>? logger = null)
    : IConfigureIHostApplicationBuilder,
        IConfigureIApplicationBuilder, ILog
{
    public ILogger? Logger => logger;

    public ConfigurationOrder Order => ConfigurationOrder.VeryEarly;

    public void Configure(WebApplicationBuilder builder)
    {
        Logger?.HttpServicesOptionsAutoConfiguratorConfigureWebApplicationBuilder();
        builder.AddHttpServices(logger: Logger);
    }

    public void Configure(IApplicationBuilder app)
    {
        Logger?.HttpServicesOptionsAutoConfiguratorConfigureIApplicationBuilder();
        app.UseHttpServices(logger: Logger);
    }
}
