using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace Dgmjr.Web.DownstreamApis;

public class DownstreamApisAutoConfigurator
    : IConfigureIHostApplicationBuilder,
        IConfigureIApplicationBuilder
{
    public ConfigurationOrder Order => ConfigurationOrder.AnyTime;

    public void Configure(IHostApplicationBuilder builder) { }

    public void Configure(IApplicationBuilder app) { }
}
