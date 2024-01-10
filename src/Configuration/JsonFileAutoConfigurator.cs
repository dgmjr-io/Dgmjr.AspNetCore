using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dgmjr.Configuration.Extensions;

public class JsonFileAutoConfigurator : IConfigureIHostApplicationBuilder
{
    public ConfigurationOrder Order => ConfigurationOrder.VeryEarly;

    public void Configure(IHostApplicationBuilder builder)
    {
        builder.Configuration.AddKeyPerJsonFile(Path.Join(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Configuration"));
        builder.Configuration.AddSubstitution();
    }
}
