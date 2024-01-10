namespace Microsoft.Extensions.DependencyInjection;

using Dgmjr.Configuration.Extensions;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System.Reflection;

public static class AutoConfigureIApplicationHostBuilderExtensions
{
    public static IHostApplicationBuilder AutoConfigure(this IHostApplicationBuilder builder)
    {
        var configurators = AssemblyLoadExtensions
            .GetTypesAssignableTo<IConfigureIHostApplicationBuilder>()
            .Select(Activator.CreateInstance)
            .OfType<IConfigureIHostApplicationBuilder>()
            .OrderBy(configurator => configurator.Order)
            .ToList();

        foreach (var configurator in configurators)
        {
            Console.WriteLine($"Configuring {configurator.GetType().Name}.");
            configurator.Configure(builder);
        }

        return builder;
    }
}
