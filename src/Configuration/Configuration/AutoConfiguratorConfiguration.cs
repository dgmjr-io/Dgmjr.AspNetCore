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
    Console.WriteLine(section?.ToJson());
    if (section.Exists())
    {
        foreach (
            var configurator in section
                .GetChildren()
                .Select(
                    configurator =>
                        configurator.Value.Split(
                            ",",
                            StringSplitOptions.RemoveEmptyEntries
                                | StringSplitOptions.TrimEntries
                        )
                )
        )
        {
            var assembly = Assembly.Load(configurator[1]);
            if (assembly != null)
            {
                var type = assembly.GetType(configurator[0]);
                if (type != null)
                {
                    options.Add(type);
                }
            }
        }
    }
}
}
