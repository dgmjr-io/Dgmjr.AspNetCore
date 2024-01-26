using System.Collections.ObjectModel;

namespace Dgmjr.Configuration.Extensions;

public class AutoConfiguratorConfiguration : Collection<type>
{
    public const string SectionName = "AutoConfigure";
}

public class AutoConfiguratorConfigurator(IConfiguration configuration)
    : IConfigureOptions<AutoConfiguratorConfiguration>
{
    public void Configure(AutoConfiguratorConfiguration options)
{
    var section = configuration.GetSection(AutoConfiguratorConfiguration.SectionName);
    Console.WriteLine(section.ToJson());
    if (section.Exists())
    {
        foreach (var configurator in section.GetChildren())
        {
            var type = Type.GetType(configurator.Value);
            if (type != null)
            {
                options.Add(type);
            }
        }
    }
}
}
