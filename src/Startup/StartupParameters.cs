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
    /// <summary>
    /// Sets up health check with IHealthChecksBuilder.
    /// </summary>
    /// <param name="configure">Action to configure IHealthChecksBuilder</param>
    /// <returns> The updated StartupParametersBuilder.</returns>
    public StartupParametersBuilder WithHealthChecks(Action? configure)
    {
        this.WithHealthChecksConfigurator(configure);
        return this;
    }

    /// <summary>
    /// Sets up Azure App Configuration with given configurators.
    /// </summary>
    /// <param name="AzureAppConfigConfigurator">Action to configure AzureAppConfigurationOptions.</param>
    /// <param name="AzureKeyVaultConfigurator">Action to configure AzureAppConfigurationKeyVaultOptions.</param>
    /// <returns>The updated StartupParametersBuilder.</returns>
    public StartupParametersBuilder WithAzureAppConfiguration(Action<AzureAppConfigurationOptions> AzureAppConfigConfigurator, Action<AzureAppConfigurationKeyVaultOptions> AzureKeyVaultConfigurator)
    {
        this.WithAzureAppConfigConfigurator(AzureAppConfigConfigurator);
        this.WithAzureKeyVaultConfigurator(AzureKeyVaultConfigurator);
        this.WithAddAzureAppConfig(AzureAppConfigConfigurator != null && AzureKeyVaultConfigurator != null);
        return this;
    }
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

    /// <summary>
    /// Configures Azure App Configuration using Application Settings options and Key Vault options.
    /// </summary>
    /// <param name="builder">WebApplicationBuilder object</param>
    /// <returns>The updated WebApplicationBuilder object.</returns>
    public WebApplicationBuilder ConfigureAzureAppConfiguration(WebApplicationBuilder builder)
    {
        builder.Configuration.AddAzureAppConfiguration(appConfig =>
        {
            AzureAppConfigConfigurator?.Invoke(appConfig);
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

}
