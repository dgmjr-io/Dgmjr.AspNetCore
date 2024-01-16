namespace Dgmjr.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Dgmjr.Configuration.Extensions;
using static Microsoft.Extensions.DependencyInjection.IHostApplicationBuilderMvcExtensions;
public class MvcAutoConfigurator : IConfigureIHostApplicationBuilder, IConfigureIApplicationBuilder
{
    private const string Mvc = nameof(Mvc);
    private const string JsonSerializer = nameof(JsonSerializer);
    public ConfigurationOrder Order => ConfigurationOrder.AnyTime;

    public void Configure(IHostApplicationBuilder builder)
    {
        builder.AddMvc();
    }

    public void Configure(IApplicationBuilder builder)
    {
        builder.UseMvc(Mvc);
    }
}
