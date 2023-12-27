namespace Microsoft.Extensions.DependencyInjection;

using System.Buffers;
using System.Reflection;
using System.Runtime.CompilerServices;
using BuilderGenerator;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using System.Collections;

/// <summary>This class stores all parameters used in the application startup.</summary>
public class StartupParameters : IStartupParameters, IServiceCollection
{
    /// <summary>Default constructor.</summary>
    internal StartupParameters()
    {
        var entryAssembly = Assembly.GetEntryAssembly();
        var thisAssembly = Find(entryAssembly.GetTypes(), t => t.Name == "ThisAssembly");

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

    /// <summary>The assembly that was executed to start the application.</summary>
    /// <value>Project type of ThisAssembly</value>
    public type? ThisAssemblyProject { get; set; }

    /// <summary>Types used by AutoMapper and MediatR in the application.</summary>
    public IEnumerable<type>? TypesForAutoMapperAndMediatR { get; set; } = Array.Empty<type>();

    // ...other properties implemented similarly...
    Action<AzureAppConfigurationOptions> IStartupParameters.AzureAppConfigurator { get; set; }

    Action<AzureAppConfigurationKeyVaultOptions> IStartupParameters.AzureKeyVaultConfigurator { get; set; }

    public required bool AppInsights { get; set; } = true;

    public required bool Identity { get; set; } = false;
    public required bool HealthChecks { get; set; } = true;

    public required bool Swagger { get; set; } = true;

    public required IEnumerable<string> AuthenticationSchemes { get; set; } = Empty<string>();

    public required bool XmlSerialization { get; set; } = true;

    public required bool SearchEntireAppDomainForAutoMapperAndMediatRTypes { get; set; } = true;

    public required bool RazorPages { get; set; } = false;

    public required bool JsonPatch { get; set; } = true;

    public required bool ApiAuthentication { get; set; } = false;

    public required bool AddAzureAppConfig { get; set; } = false;

    public required bool Hashids { get; set; } = true;

    public required bool MediatR { get; set; } = true;

    public required bool AutoMapper { get; set; } = true;

    public required bool Logging { get; set; } = true;

    public required bool HttpLogging { get; set; } = true;

    public required bool ConsoleLogger { get; set; } = false;

    public required bool DebugLogger { get; set; } = false;

    public required bool DefaultIdentityUI { get; set; } = false;

    public required bool AzureAppConfig { get; set; } = false;

    public Action<AzureAppConfigurationKeyVaultOptions> AzureKeyVault { get; set; }

    /// <summary>Configures health checks using provided IHealthChecksBuilder configurator.</summary>
    /// <returns>The updated <see cref="Action{IHealthChecksBuilder}" /> delegate.</returns>
    public Action<IHealthChecksBuilder> HealthChecksConfigurator { get; set; } = _ => { };

    WebApplicationBuilder IStartupParameters.ConfigureHealthChecks(WebApplicationBuilder builder)
    {
        builder.Services.AddHealthChecks();
        HealthChecksConfigurator?.Invoke(builder.Services.AddHealthChecks());
        return builder;
    }

    /// <summary>
    /// Configures Azure App Configuration using Application Settings options and Key Vault options.
    /// </summary>
    /// <param name="builder">WebApplicationBuilder object</param>
    /// <returns>The updated WebApplicationBuilder object.</returns>
    WebApplicationBuilder IStartupParameters.ConfigureAzureAppConfiguration(
        WebApplicationBuilder builder
    )
    {
        builder.Configuration.AddAzureAppConfiguration(appConfig =>
        {
            ((IStartupParameters)this).AzureAppConfigurator(appConfig);
            appConfig.ConfigureKeyVault(
                kv => ((IStartupParameters)this).AzureKeyVaultConfigurator(kv)
            );
        });
        return builder;
    }

    IServiceCollection IStartupParameters.Services { get; set; } = new ServiceCollection();

    public override int GetHashCode() =>
        HashCode.Combine(
            HashCode.Combine(
                HashCode.Combine(
                    HashCode.Combine(
                        ThisAssemblyProject,
                        TypesForAutoMapperAndMediatR,
                        AppInsights,
                        Identity,
                        Swagger,
                        AuthenticationSchemes,
                        XmlSerialization,
                        SearchEntireAppDomainForAutoMapperAndMediatRTypes
                    ),
                    RazorPages,
                    JsonPatch,
                    ApiAuthentication,
                    AddAzureAppConfig,
                    Hashids,
                    MediatR,
                    AutoMapper
                ),
                Logging,
                HttpLogging,
                ConsoleLogger,
                DebugLogger,
                DefaultIdentityUI,
                AzureAppConfig,
                AzureKeyVault
            ),
            ((IStartupParameters)this).AzureAppConfigurator,
            ((IStartupParameters)this).AzureKeyVaultConfigurator,
            ((IStartupParameters)this).HealthChecksConfigurator,
            ((IStartupParameters)this).Services
        );

    WebApplicationBuilder IStartupParameters.ConfigureServices(WebApplicationBuilder builder)
    {
        ((IStartupParameters)this).Services.ForEach(sd => builder.Services.Add(sd));
        return builder;
    }

    public virtual IStartupParameters WithService(ServiceDescriptor sd)
    {
        ((IStartupParameters)this).Services.Add(sd);
        return this;
    }

    public override bool Equals(object? obj) => GetHashCode() == obj?.GetHashCode();

    public virtual bool Equals(StartupParameters? other) => GetHashCode() == other?.GetHashCode();

    #region IServiceCollection implementation
    void IList<ServiceDescriptor>.Insert(int index, ServiceDescriptor sd) =>
        ((IStartupParameters)this).Services.Insert(index, sd);

    int IList<ServiceDescriptor>.IndexOf(ServiceDescriptor sd) =>
        ((IStartupParameters)this).Services.IndexOf(sd);

    void IList<ServiceDescriptor>.RemoveAt(int index) =>
        ((IStartupParameters)this).Services.RemoveAt(index);

    void ICollection<ServiceDescriptor>.Add(ServiceDescriptor sd) =>
        ((IStartupParameters)this).Services.Add(sd);

    bool ICollection<ServiceDescriptor>.Contains(ServiceDescriptor sd) =>
        ((IStartupParameters)this).Services.Contains(sd);

    void ICollection<ServiceDescriptor>.Clear() => ((IStartupParameters)this).Services.Clear();

    void ICollection<ServiceDescriptor>.CopyTo(ServiceDescriptor[] array, int arrayIndex) =>
        ((IStartupParameters)this).Services.CopyTo(array, arrayIndex);

    IEnumerator<ServiceDescriptor> IEnumerable<ServiceDescriptor>.GetEnumerator() =>
        ((IStartupParameters)this).Services.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => ((IStartupParameters)this).Services.GetEnumerator();

    bool ICollection<ServiceDescriptor>.Remove(ServiceDescriptor sd) =>
        ((IStartupParameters)this).Services.Remove(sd);

    ServiceDescriptor IList<ServiceDescriptor>.this[int i]
    {
        get => ((IStartupParameters)this).Services[i];
        set => ((IStartupParameters)this).Services[i] = value;
    }

    int ICollection<ServiceDescriptor>.Count => ((IStartupParameters)this).Services.Count;

    bool ICollection<ServiceDescriptor>.IsReadOnly =>
        ((IStartupParameters)this).Services.IsReadOnly;
    #endregion
}
