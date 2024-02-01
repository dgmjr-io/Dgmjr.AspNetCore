using System.Collections;
using System.Runtime.Loader;

namespace Dgmjr.AspNetCore.Mvc;

public class TypeNameAndAssemblyConfigurator<T, U>(
    IConfiguration configuration,
    string? configurationSectionKey = null,
    Expression<Func<T, IList<U>>>? property = null
) : IConfigureOptions<T>
    where T : class
    where U : class
{
    public virtual void Configure(T options)
    {
        var configurationSection = configuration;
        if (configurationSectionKey is not null)
        {
            configurationSection = configuration.GetRequiredSection(configurationSectionKey);
        }

        var list = property.Compile().Invoke(options);

        foreach (var (assemblyName, typeName) in configurationSection.GetChildren().Select(GetType))
        {
            var u = Activator.CreateInstance(assemblyName, typeName).Unwrap() as U;
            if(u is not null)
            {
                list.Add(u);
            }
        }
    }

    private (string assemblyName, string typeName) GetType(IConfigurationSection section)
    {
        var parts = section.Value.Split(
            ',',
            StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries
        );
        var assemblyName = parts[1];
        var typeName = parts[0];
        return (assemblyName, typeName);
        // var assembly = AssemblyLoadContext.Default.LoadFromAssemblyName(
        //     new AssemblyName(assemblyName)
        // );
        // return assembly.GetType(typeName);
    }
}
