using System;
using System.Collections;
using System.Runtime.Loader;
using System.Text.RegularExpressions;

namespace Dgmjr.AspNetCore.Mvc;

public class TypeNameAndAssemblyConfigurator<T, U>(
    IConfiguration configuration,
    string? configurationSectionKey = null,
    Expression<Func<T, IList<U>>>? property = null
) : IConfigureOptions<T>
    where T : class
    where U : class
{
    private const string TypeWithAssemblyPattern =
        @"^(?<TypeName>([A-Za-z0-9_\.]+(?:\+?[A-Za-z0-9_]+)*(\`\d+\[(?:[^\[\]]+|(\2))*\])?)),\s*(?<AssemblyName>([A-Za-z0-9_\.]+))$";
    private static readonly Regex TypeWithAssemblyRegex =
        new(TypeWithAssemblyPattern, RegexOptions.Compiled);

    public virtual void Configure(T options)
    {
        var configurationSection = configuration;
        if (configurationSectionKey is not null)
        {
            configurationSection = configuration.GetRequiredSection(configurationSectionKey);
        }

        var list = property.Compile().Invoke(options);

        foreach (var t in configurationSection.GetChildren().Select(configSection => configSection.Value).WhereNotNull().Select(type.GetType))
        {
            if(t != null)
            {
                var u = Activator.CreateInstance(t) as U;
                if (u is not null)
                {
                    list.Add(u);
                }
            }
        }
    }

    // private (string assemblyName, string typeName) GetType(IConfigurationSection section)
    // {
    //     try
    //     {
    //         var type = Type.GetType(section.Value);
    //         if (type is not null)
    //             return (type.FullName, type.Assembly.GetName().FullName);
    //         else
    //             return (section.Value, section.Value);
    //     }
    //     catch { }
    //     return (section.Value, section.Value);
        // var match = TypeWithAssemblyRegex.Match(section.Value);
        // if (!match.Success)
        // {
        //     throw new InvalidOperationException(
        //         $"Invalid type name and assembly name configuration: {section.Value}"
        //     );
        // }
        // return (match.Groups["AssemblyName"].Value, match.Groups["TypeName"].Value);
        // var parts = section.Value.Split(
        //     ',',
        //     StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries
        // );
        // var assemblyName = parts[1];
        // var typeName = parts[0];
        // return (assemblyName, typeName);
        // var assembly = AssemblyLoadContext.Default.LoadFromAssemblyName(
        //     new AssemblyName(assemblyName)
        // );
        // return assembly.GetType(typeName);
    // }
}
