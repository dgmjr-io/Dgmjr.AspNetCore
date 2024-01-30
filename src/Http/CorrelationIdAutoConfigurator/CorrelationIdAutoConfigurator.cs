namespace Microsoft.Extensions.DependencyInjection;

using CorrelationId;
using CorrelationId.DependencyInjection;
using Dgmjr.Configuration.Extensions;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

public class CorrelationIdAutoConfigurator
    : IConfigureIHostApplicationBuilder,
        IConfigureIApplicationBuilder
{
    public ConfigurationOrder Order => ConfigurationOrder.VeryEarly;

    public void Configure(WebApplicationBuilder builder)
    {
        builder.Services.AddDefaultCorrelationId(
            options => builder.Configuration.GetSection(nameof(CorrelationId)).Bind(options)
        );
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseCorrelationId();
    }
}
