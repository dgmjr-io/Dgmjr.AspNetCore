namespace Microsoft.Extensions.DependencyInjection;

using Dgmjr.Configuration.Extensions;
using Microsoft.AspNetCore.Builder;

public static class AutoConfigureIApplicationBuilderExtensions
{
    public static IApplicationBuilder AutoConfigure(this IApplicationBuilder builder)
    {
        var configurators = builder.ApplicationServices
            .GetServices<IConfigureIApplicationBuilder>()
            .OrderBy(configurator => configurator.Order)
            .ToList();

        Console.WriteLine(
            $"Configuring IApplicationBuilder with the following configurators: {Join(", ", configurators.Select(configurator => configurator.GetType().Name))}."
        );

        foreach (var configurator in configurators)
        {
            Console.WriteLine(
                $"Configuring IApplicationBuilder with {configurator.GetType().Name}."
            );
            configurator.Configure(builder);
        }

        return builder;
    }
}
