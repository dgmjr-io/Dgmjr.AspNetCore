namespace Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Builder;

public class SwaggerAutoConfigurator
    : IConfigureIHostApplicationBuilder,
        IConfigureIApplicationBuilder
{
    public ConfigurationOrder Order => ConfigurationOrder.AnyTime;

    public void Configure(WebApplicationBuilder builder)
    {
        builder.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseCustomSwaggerUI();
    }
}
