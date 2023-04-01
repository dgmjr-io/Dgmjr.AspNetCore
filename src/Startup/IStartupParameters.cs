namespace Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
public interface IStartupParameters
{
    type? ThisAssemblyProject { get; set; }
    IEnumerable<type>? TypesForAutoMapperAndMediatR { get; set; }
    bool AddIdentity { get; set; }
    bool AddSwagger { get; set; }
    IEnumerable<string> AuthenticationSchemes { get; set; }
    bool AddXmlSerialization { get; set; }
    bool SearchEntireAppDomainForAutoMapperAndMediatRTypes { get; set; }
    bool AddRazorPages { get; set; }
    bool AddJsonPatch { get; set; }
    bool AddApiAuthentication { get; set; }
    bool AddAzureAppConfig { get; set; }
    bool AddHashids { get; set; }
    bool AddMediatR { get; set; }
    bool AddAutoMapper { get; set; }
    bool AddLogging { get; set; }
    bool AddHttpLogging { get; set; }
    bool AddConsoleLogger { get; set; }
    bool AddDebugLogger { get; set; }
    bool AddDefaultIdentityUI { get; set; }

    WebApplicationBuilder ConfigureAzureAppConfiguration(WebApplicationBuilder builder);
    WebApplicationBuilder ConfigureHealthChecks(WebApplicationBuilder builder);

    bool Equals(object obj);
    bool Equals(StartupParameters other);
    int GetHashCode();
    string ToString();
}
