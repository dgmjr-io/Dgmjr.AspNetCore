/*
 * BasicApiAuthMiddleware.cs
 *
 *   Created: 2022-12-14-05:48:24
 *   Modified: 2022-12-14-05:48:25
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.Authentication;

using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using Dgmjr.Abstractions;
using Dgmjr.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

public class BasicApiAuthMiddleware : IBasicApiAuthMiddleware, ILog
{
    public UserManager UserManager { get; }

    public ILogger Logger { get; init; }

    public BasicApiAuthMiddleware(UserManager userManager, ILogger<BasicApiAuthMiddleware> logger)
    {
        UserManager = userManager;
        Logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        

        await next(context);
    }

    public virtual Task HandleChallengeAsync(HttpContext context)
    {
        context.Response.StatusCode = 401;
        context.Response.Headers["WWW-Authenticate"] = "Basic";
        return Task.CompletedTask;
    }
}
