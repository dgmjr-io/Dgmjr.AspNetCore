namespace Microsoft.Extensions.DependencyInjection;

using Dgmjr.Configuration.Extensions;
using Microsoft.AspNetCore.Builder;

public static class AutoConfigureIApplicationBuilderExtensions
{
    public static IApplicationBuilder AutoConfigure(this IApplicationBuilder builder)
    {
        var configurators = AssemblyLoadExtensions
            .GetTypesAssignableTo<IConfigureIApplicationBuilder>()
            .Select(Activator.CreateInstance)
            .OfType<IConfigureIApplicationBuilder>()
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
