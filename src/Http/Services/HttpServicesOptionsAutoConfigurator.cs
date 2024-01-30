namespace Microsoft.Extensions.DependencyInjection;

using Dgmjr.Configuration.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

public class HttpServicesOptionsAutoConfigurator
    : IConfigureIHostApplicationBuilder,
        IConfigureIApplicationBuilder
{
    public ConfigurationOrder Order => ConfigurationOrder.AnyTime;

    public void Configure(WebApplicationBuilder builder)
    {
        builder.AddHttpServices();
    }

    public void Configure(IApplicationBuilder builder)
    {
        builder.UseHttpServices();
    }
}
