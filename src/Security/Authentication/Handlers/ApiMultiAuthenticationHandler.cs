/*
 * ApiMultiAuthenticationHandler.cs
 *
 *   Created: 2023-04-06-04:20:28
 *   Modified: 2023-04-06-04:20:29
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System.Text.Encodings.Web;
using Dgmjr.AspNetCore.Authentication.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Dgmjr.AspNetCore.Authentication.Handlers;

public class ApiMultiAuthenticationHandler : AuthenticationHandler<ApiAuthenticationOptions>
{
    public ApiMultiAuthenticationHandler(
        IOptionsMonitor<ApiAuthenticationOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock
    )
        : base(options, logger, encoder, clock) { }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync() { }
}
