namespace Microsoft.Extensions.DependencyInjection;

public class MicrosoftGraphAutoConfigurator : IConfigureIHostApplicationBuilder
{
    public ConfigurationOrder Order => ConfigurationOrder.AnyTime;

    public void Configure(WebApplicationBuilder builder)
    {
        builder.Services.AddMicrosoftGraph(builder.Configuration);
    }
}
