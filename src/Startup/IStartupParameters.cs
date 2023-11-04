namespace Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

/// <summary>
/// Represents all parameters used in the application startup.
/// </summary>
public interface IStartupParameters
{
    /// <summary>
    /// Gets or sets the project type of the assembly that was executed to start the application.
    /// </summary>
    type? ThisAssemblyProject { get; set; }

    /// <summary>
    /// Gets or sets the types used by AutoMapper and MediatR in the application.
    /// </summary>
    IEnumerable<type>? TypesForAutoMapperAndMediatR { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to use Application Insights.
    /// </summary>
    bool AppInsights { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to use identity.
    /// </summary>
    bool Identity { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to use Swagger documentation.
    /// </summary>
    bool Swagger { get; set; }

    /// <summary>
    /// Gets or sets the authentication schemes used by the application.
    /// </summary>
    IEnumerable<string> AuthenticationSchemes { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to use XML serialization.
    /// </summary>
    bool XmlSerialization { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to search the entire AppDomain for AutoMapper and MediatR types.
    /// </summary>
    bool SearchEntireAppDomainForAutoMapperAndMediatRTypes { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to use Razor Pages.
    /// </summary>
    bool RazorPages { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to use Json Patch.
    /// </summary>
    bool JsonPatch { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to use API authentication.
    /// </summary>
    bool ApiAuthentication { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to use Hashids.
    /// </summary>
    bool Hashids { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to use MediatR.
    /// </summary>
    bool MediatR { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to use AutoMapper.
    /// </summary>
    bool AutoMapper { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to use logging.
    /// </summary>
    bool Logging { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to use HTTP logging.
    /// </summary>
    bool HttpLogging { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to use console logging.
    /// </summary>
    bool ConsoleLogger { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to use debug logging.
    /// </summary>
    bool DebugLogger { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to use the default Identity UI.
    /// </summary>
    bool DefaultIdentityUI { get; set; }
    bool AzureAppConfig { get; set; }
    Action<IHealthChecksBuilder> WithHealthChecks(Action<IHealthChecksBuilder>? configure);
    Action<AzureAppConfigurationOptions> AzureAppConfigurator { get; set; }

    Action<AzureAppConfigurationKeyVaultOptions> AzureKeyVaultConfigurator { get; set; }
    WebApplicationBuilder ConfigureAzureAppConfiguration(WebApplicationBuilder builder);
    WebApplicationBuilder ConfigureHealthChecks(WebApplicationBuilder builder);
    WebApplicationBuilder ConfigureServices(WebApplicationBuilder builder);
    Action<IHealthChecksBuilder> HealthChecksConfigurator { get; set; }
    IServiceCollection Services { get; set; }

    bool Equals(object obj);
    bool Equals(StartupParameters other);
    int GetHashCode();
    string ToString();
}
