namespace Microsoft.Extensions.DependencyInjection;

using Dgmjr.Configuration.Extensions;

using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System.Reflection;

public static class AutoConfigureIApplicationHostBuilderExtensions
{
    public static IHostApplicationBuilder AutoConfigure<TProgram>(
        this IHostApplicationBuilder builder
    )
    {
        builder.Configuration.AddKeyPerJsonFile(
            Path.Join(Path.GetDirectoryName(typeof(TProgram).Assembly.Location), "./Configuration/")
        );

        var autoConfigurationConfig = new AutoConfiguratorConfiguration();
        var autoConfiguratorConfigurator = new AutoConfiguratorConfigurator(builder.Configuration);
        autoConfiguratorConfigurator.Configure(autoConfigurationConfig);

        var hostBuilderConfiguratorTypes = autoConfigurationConfig.Where(
            type => typeof(IConfigureIHostApplicationBuilder).IsAssignableFrom(type)
        );
        var appBuilderConfiguratorTypes = autoConfigurationConfig.Where(
            type => typeof(IConfigureIApplicationBuilder).IsAssignableFrom(type)
        );

        // var hostBuilderConfiguratorTypes = AssemblyLoadExtensions
        //     .GetTypesAssignableTo<IConfigureIHostApplicationBuilder>();

        // var appBuilderConfiguratorTypes = AssemblyLoadExtensions
        //     .GetTypesAssignableTo<IConfigureIApplicationBuilder>();

        var services = new ServiceCollection();
        foreach (var serviceDescriptor in builder.Services)
        {
            services.Add(serviceDescriptor);
        }

        foreach (var configuratorType in hostBuilderConfiguratorTypes)
        {
            services.TryAddEnumerable(
                new ServiceDescriptor(
                    typeof(IConfigureIHostApplicationBuilder),
                    configuratorType,
                    ServiceLifetime.Singleton
                )
            );
            builder.Services.TryAddEnumerable(
                new ServiceDescriptor(
                    typeof(IConfigureIHostApplicationBuilder),
                    configuratorType,
                    ServiceLifetime.Singleton
                )
            );
        }

        foreach (var configuratorType in appBuilderConfiguratorTypes)
        {
            services.TryAddEnumerable(
                new ServiceDescriptor(
                    typeof(IConfigureIApplicationBuilder),
                    configuratorType,
                    ServiceLifetime.Singleton
                )
            );
            builder.Services.TryAddEnumerable(
                new ServiceDescriptor(
                    typeof(IConfigureIApplicationBuilder),
                    configuratorType,
                    ServiceLifetime.Singleton
                )
            );
        }

        var configurators = services
            .BuildServiceProvider()
            .GetServices<IConfigureIHostApplicationBuilder>()
            .OrderBy(configurator => configurator.Order)
            .ToList();

        Console.WriteLine(
            $"Configuring IHostApplicationBuilder with the following configurators: {Join(", ", configurators.Select(configurator => configurator.GetType().Name))}."
        );

        foreach (var configurator in configurators)
        {
            Console.WriteLine(
                $"Configuring IHostApplicationBuilder with {configurator.GetType().Name}."
            );
            configurator.Configure(builder);
        }

        return builder;
    }
}
