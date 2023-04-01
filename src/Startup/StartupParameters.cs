namespace Microsoft.Extensions.DependencyInjection;

using System.Buffers;
using System.Reflection;
using System.Runtime.CompilerServices;
using BuilderGenerator;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

[BuilderFor(typeof(StartupParameters))]
public partial class StartupParametersBuilder
{
    public StartupParametersBuilder WithHealthChecks(Action<IHealthChecksBuilder>? configure)
    {
        this.WithHealthChecksConfigurator(configure);
        return this;
    }

    public StartupParametersBuilder WithAzureAppConfiguration(Action<AzureAppConfigurationOptions> AzureAppConfigConfigurator, Action<AzureAppConfigurationKeyVaultOptions> AzureKeyVaultConfigurator)
    {
        this.WithAzureAppConfigConfigurator(AzureAppConfigConfigurator);
        this.WithAzureKeyVaultConfigurator(AzureKeyVaultConfigurator);
        this.WithAddAzureAppConfig(AzureAppConfigConfigurator != null && AzureKeyVaultConfigurator != null);
        return this;
    }
}

public record class StartupParameters : IStartupParameters
{
    public StartupParameters() 
    {
        var entryAssebmly = Assembly.GetEntryAssembly();
        var thisAssembly = entryAssebmly.GetTypes().FirstOrDefault(t => t.Name == "ThisAssembly");
        if(thisAssembly is null)
        {
            throw new TypeLoadException("ThisAssembly class not found");
        }
        var thisAssemblyProject = thisAssembly.GetNestedType("Project");
        if(thisAssemblyProject is null)
        {
            throw new TypeLoadException("ThisAssembly.Project class not found");
        }
        ThisAssemblyProject = thisAssemblyProject;
    }

    public type? ThisAssemblyProject { get; set; }
    public IEnumerable<type>? TypesForAutoMapperAndMediatR { get; set; } = Array.Empty<type>();
    public bool AddIdentity { get; set; } = true;
    public bool AddSwagger { get; set; } = true;
    public IEnumerable<string> AuthenticationSchemes { get; set; } = new[] { Dgmjr.AspNetCore.Authentication.ApiBasicAuthenticationOptions.AuthenticationSchemeName };
    public bool AddXmlSerialization { get; set; } = true;
    public bool SearchEntireAppDomainForAutoMapperAndMediatRTypes { get; set; } = true;
    public bool AddRazorPages { get; set; } = true;
    public bool AddJsonPatch { get; set; } = true;
    public bool AddApiAuthentication { get; set; } = true;
    public bool AddAzureAppConfig { get; set; } = true;
    public bool AddHashids { get; set; } = true;
    public bool AddMediatR { get; set; } = true;
    public bool AddAutoMapper { get; set; } = true;
    public bool AddLogging { get; set; } = true;
    public bool AddHttpLogging { get; set; } = true;
    public bool AddConsoleLogger { get; set; } = true;
    public bool AddDebugLogger { get; set; } = true;
    public bool AddDefaultIdentityUI { get; set; } = false;
    public bool AddSendPulseApi { get; set; } = true;
    public Action<AzureAppConfigurationOptions> AzureAppConfigConfigurator { get; set; }

    public Action<AzureAppConfigurationKeyVaultOptions> AzureKeyVaultConfigurator { get; set; }


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

    public Action<IHealthChecksBuilder>? HealthChecksConfigurator { get; set; } = default;

    public WebApplicationBuilder ConfigureHealthChecks(WebApplicationBuilder builder)
    {
        HealthChecksConfigurator?.Invoke(builder.Services.AddHealthChecks());
        return builder;
    }
}
