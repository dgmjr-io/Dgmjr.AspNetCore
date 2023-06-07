namespace Microsoft.Extensions.DependencyInjection;

using System.Buffers;
using System.Reflection;
using System.Runtime.CompilerServices;
using BuilderGenerator;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

/// <summary>
/// This class is a builder for StartParameters object.
/// </summary>
[BuilderFor(typeof(StartupParameters))]
public partial class StartupParametersBuilder
{
}


/// <summary>
/// This record stores all parameters used in the application startup.
/// </summary>
public record class StartupParameters : IStartupParameters
{
    /// <summary>
    /// Default constructor.
    /// </summary> 
    public StartupParameters()
    {
        var entryAssebmly = Assembly.GetEntryAssembly();
        var thisAssembly = entryAssebmly.GetTypes().FirstOrDefault(t => t.Name == "ThisAssembly");

        if (thisAssembly is null)
        {
            throw new TypeLoadException("ThisAssembly class not found");
        }

        var thisAssemblyProject = thisAssembly.GetNestedType("Project");

        if (thisAssemblyProject is null)
        {
            throw new TypeLoadException("ThisAssembly.Project class not found");
        }

        ThisAssemblyProject = thisAssemblyProject;
    }

    /// <summary>
    /// The assembly that was executed to start the application.
    /// </summary>
    /// <value>Project type of ThisAssembly</value>
    public type? ThisAssemblyProject { get; internal set; }

    /// <summary>
    /// Types used by AutoMapper and MediatR in the application.
    /// </summary>
    public IEnumerable<type>? TypesForAutoMapperAndMediatR { get; internal set; } = Array.Empty<type>();

    // ...other properties implemented similarly...
    public virtual Action<AzureAppConfigurationOptions> AzureAppConfigu { get; set; }

    public virtual Action<AzureAppConfigurationKeyVaultOptions> AzureKeyVaultConfig { get; set; }

    public virtual Action<IHealthChecksBuilder> HealthChecks { get; set; }

    /// <summary>
    /// Configures Azure App Configuration using Application Settings options and Key Vault options.
    /// </summary>
    /// <param name="builder">WebApplicationBuilder object</param>
    /// <returns>The updated WebApplicationBuilder object.</returns>
    public WebApplicationBuilder ConfigureAzureAppConfiguration(WebApplicationBuilder builder)
    {
        builder.Configuration.AddAzureAppConfiguration(appConfig =>
        {
            AzureAppConfigurator?.Invoke(appConfig);
            appConfig
                .ConfigureKeyVault(kv =>
                {
                    AzureKeyVaultConfigurator?.Invoke(kv);
                });
        });
        return builder;
    }

    /// <summary>
    /// Configures health checks using provided IHealthChecksBuilder configurator.
    /// </summary>
    /// <param name="builder">WebApplicationBuilder object</param>
    /// <returns>The updated WebApplicationBuilder object.</returns>
    public Action<IHealthChecksBuilder>? HealthChecksConfigurator { get; internal set; } = default;

    public bool AppInsights { get; set; }

    public bool Identity { get; set; }

    public bool Swagger { get; set; }

    public IEnumerable<string> AuthenticationSchemes { get; set; }

    public bool XmlSerialization { get; set; }

    public bool SearchEntireAppDomainForAutoMapperAndMediatRTypes { get; set; }

    public bool RazorPages { get; set; }

    public bool JsonPatch { get; set; }

    public bool ApiAuthentication { get; set; }

    public bool AddAzureAppConfig { get; set; }

    public bool Hashids { get; set; }

    public bool MediatR { get; set; }

    public bool AutoMapper { get; set; }

    public bool Logging { get; set; }

    public bool HttpLogging { get; set; }

    public bool ConsoleLogger { get; set; }

    public bool DebugLogger { get; set; }

    public bool DefaultIdentityUI { get; set; }

    /// <summary>
    /// Adds Health Check middleware to application.
    /// </summary>
    /// <param name="configure">Action to configure IHealthChecksBuilder.</param>
    WebApplicationBuilder WithHealthChecks(Action<IHealthChecksBuilder>? configure);

    public WebApplicationBuilder ConfigureHealthChecks(WebApplicationBuilder builder)
    {
        HealthChecksConfigurator?.Invoke(builder.Services.AddHealthChecks());
        return builder;
    }

    public WebApplicationBuilder WithAzureAppConfiguration(WebApplicationBuilder builder)
    {
        throw new NotImplementedException();
    }

    WebApplicationBuilder IStartupParameters.WithHealthChecks(Action<IHealthChecksBuilder>? configure)
    {
        throw new NotImplementedException();
    }
}
