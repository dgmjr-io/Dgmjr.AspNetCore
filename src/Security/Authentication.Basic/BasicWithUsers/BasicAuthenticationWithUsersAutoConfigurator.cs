using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Dgmjr.AspNetCore.Authentication.Basic;

public class BasicAuthenticationWithUsersAutoConfigurator
    : IConfigureIHostApplicationBuilder,
        IConfigureIApplicationBuilder
{
    public ConfigurationOrder Order => ConfigurationOrder.AnyTime;

    public void Configure(WebApplicationBuilder builder)
    {
        var config = builder.Configuration.GetSection(
            BasicAuthenticationWithUsersOptions.ConfigurationKey
        );
        builder.Services
            .AddAuthentication(BasicAuthenticationWithUsersDefaults.AuthenticationScheme)
            .AddScheme<BasicAuthenticationWithUsersOptions, BasicAuthenticationWithUsersHandler>(
                BasicAuthenticationWithUsersDefaults.AuthenticationScheme,
                config.Bind
            );
    }

    public void Configure(IApplicationBuilder app) { }
}
