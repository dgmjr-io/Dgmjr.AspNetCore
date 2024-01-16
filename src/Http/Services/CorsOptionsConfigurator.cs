namespace Dgmjr.AspNetCore.Http.Services;
using static Microsoft.Extensions.DependencyInjection.HttpServicesExtensions;

using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Cors.Infrastructure;
using AspNetCorsOptions = Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions;

public class CorsOptionsConfigurator(IConfiguration configuration) : IConfigureOptions<CorsOptions>, IConfigureOptions<AspNetCorsOptions>
{
    public const string CorsOptionsSectionName = $"{Http}:{Cors}";
public const string CorsOptionsPoliciesSectionName = $"{CorsOptionsSectionName}:Policies";

private IConfigurationSection CorsOptionsPoliciesSection => configuration.GetSection(CorsOptionsPoliciesSectionName);
private IConfigurationSection CorsOptionsSection => configuration.GetSection(CorsOptionsSectionName);

public void Configure(CorsOptions options)
{
    var corsPolicyDictionary = configuration.GetSection(CorsOptionsPoliciesSectionName).Get<Dictionary<string, CorsPolicy>>();
    foreach (var policy in corsPolicyDictionary)
    {
        options.AddPolicy(policy.Key, policy.Value);
    }
}

public void Configure(AspNetCorsOptions options)
{
    CorsOptionsSection.Bind(options);
    var policies = CorsOptionsPoliciesSection.GetChildren();

    foreach (var policy in policies)
    {
        var builder = new CorsPolicyBuilder();
        builder.WithExposedHeaders(policy.GetValue<string[]>(nameof(CorsPolicy.ExposedHeaders)) ?? Empty<string>())
                .WithHeaders(policy.GetValue<string[]>(nameof(CorsPolicy.Headers)) ?? Empty<string>())
                .WithMethods(policy.GetValue<string[]>(nameof(CorsPolicy.Methods)) ?? Empty<string>())
                .WithOrigins(policy.GetValue<string[]>(nameof(CorsPolicy.Origins)) ?? Empty<string>());
        if (policy.GetValue<bool>(nameof(CorsPolicy.AllowAnyHeader)))
            builder.AllowAnyHeader();
        if (policy.GetValue<bool>(nameof(CorsPolicy.AllowAnyMethod)))
            builder.AllowAnyMethod();
        if (policy.GetValue<bool>(nameof(CorsPolicy.AllowAnyOrigin)))
            builder.AllowAnyOrigin();

        options.AddPolicy(policy.Key, builder.Build());
    }
}
}
