namespace Dgmjr.AspNetCore.Authentication.Basic;

using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;

public abstract class BasicAuthenticationHandler<TOptions>(
    IOptionsMonitor<TOptions> options,
    ILoggerFactory loggerFactory,
    UrlEncoder urlEncoder,
    ISystemClock clock
) : AuthenticationHandler<TOptions>(options, loggerFactory, urlEncoder, clock), ILog
    where TOptions : AuthenticationSchemeOptions, new()
{
    private ILogger _logger;
    public new virtual ILogger Logger => _logger ??= loggerFactory.CreateLogger(GetType().FullName);
}
