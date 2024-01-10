namespace Dgmjr.AspNetCore.Http.Services;
using static Microsoft.Extensions.DependencyInjection.HttpServicesExtensions;

using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

public class CorsOptionsConfigurator(IConfiguration configuration) : IConfigureOptions<CorsOptions>
{
    public const string CorsOptionsSection = $"{Http}:{Cors}";

    private readonly IConfiguration _configuration = configuration;

    public void Configure(CorsOptions options)
    {
        var corsPolicyDictionary = _configuration.GetSection(CorsOptionsSection).Get<Dictionary<string, CorsPolicy>>();
    }
}
