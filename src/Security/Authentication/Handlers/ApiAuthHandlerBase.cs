/* 
 * ApiAuthHandlerBase.cs
 * 
 *   Created: 2023-04-07-07:41:16
 *   Modified: 2023-04-07-07:41:16
 * 
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *   
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System.Text.Encodings.Web;
using Dgmjr.AspNetCore.Authentication.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Dgmjr.AspNetCore.Authentication.Handlers;

public abstract class ApiAuthHandlerBase<TOptions> : AuthenticationHandler<TOptions>, IAuthenticationSignOutHandler, IAuthenticationSignInHandler, ILog
    where TOptions : AuthenticationSchemeOptions, IAuthenticationSchemeOptions, new()
{
    public new virtual ILogger Logger { get; init; }

    public ApiAuthHandlerBase(IOptionsMonitor<TOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
    {
        Logger = logger.CreateLogger(GetType().FullName);
    }

    public abstract Task SignInAsync(ClaimsPrincipal user, AuthenticationProperties? properties);
    public abstract Task SignOutAsync(AuthenticationProperties? properties);
}
