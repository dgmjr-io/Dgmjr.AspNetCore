/* 
 * AuthMidewareBase.cs
 * 
 *   Created: 2023-04-02-05:53:30
 *   Modified: 2023-04-02-05:53:30
 * 
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *   
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Dgmjr.AspNetCore.Authentication.Middlewares;

public abstract class AuthMiddlewareBase<THandler, TOptions> : ILog, IMiddleware
    where TOptions : AuthenticationSchemeOptions, IAuthenticationSchemeOptions, new()
    where THandler : AuthenticationHandler<TOptions>
{
    protected readonly RequestDelegate _next;
    protected readonly IOptionsMonitor<TOptions> _options;
    protected readonly UrlEncoder _encoder;
    protected readonly ISystemClock _clock;
    protected readonly THandler _handler;

    public ILogger Logger { get; init; }

    protected AuthMiddlewareBase(
        RequestDelegate next,
        IOptionsMonitor<TOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        THandler handler)
    {
        _next = next;
        _options = options;
        Logger = logger.CreateLogger(GetType().FullName);
        _encoder = encoder;
        _clock = clock;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var options = _options.Get(_options.CurrentValue?.ForwardDefault);
        if (options == null)
        {
            Logger.LogNoDefaultAuthenticationScheme();
            context.Response.StatusCode = 500;
            return;
        }

        if (ShouldHandleScheme(options.AuthenticationSchemeName))
        {
            await HandleAuthenticateOnceAsync(context, options);
        }
        else
        {
            await _next(context);
        }
    }

    protected virtual bool ShouldHandleScheme(string authenticationScheme)
    {
        try { _options?.CurrentValue?.Validate(authenticationScheme); return true; }
        catch { return false; }
    }

    protected virtual async Task HandleAuthenticateOnceAsync(HttpContext context, TOptions options)
    {
        var handler = _handler;
        await handler.InitializeAsync(_options?.CurrentValue.ToAuthenticationScheme(), context);
        var authResult = await handler.AuthenticateAsync();
        if (authResult?.Principal != null)
        {
            await context.SignInAsync(authResult.Principal, authResult.Properties);
        }
        else
        {
            context.Response.StatusCode = 401;
        }
        await _next(context);
    }
}
