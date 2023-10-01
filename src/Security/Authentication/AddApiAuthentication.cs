/*
 * AddApiAuthentication.cs
 *
 *   Created: 2022-12-10-08:00:57
 *   Modified: 2022-12-10-08:00:57
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
#pragma warning disable
using Dgmjr.AspNetCore.Authentication;
using Dgmjr.AspNetCore.Authentication.Options;
using Dgmjr.Identity;
using Dgmjr.Identity.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using IdentityDbContext = Dgmjr.Identity.IdentityDbContext;

namespace Microsoft.Extensions.DependencyInjection;

public static class AddApiAuthenticationExtensions
{
    /// <summary>Registers the API authentication middleware.</summary>
    public static WebApplicationBuilder AddApiAuthentication(
        this WebApplicationBuilder builder,
        Action<IBasicAuthenticationSchemeOptions>? basicConfig = null,
        Action<IJwtConfigurationOptions>? jwtConfig = null,
        Action<ISharedSecretAuthenticationSchemeOptions>? sharedSecretConfig = null
    )
    {
        builder.Services.AddScoped<IBasicApiAuthMiddleware, BasicApiAuthMiddleware>();
        builder.Services.AddAuthentication(Api).AddApiBasicAuthentication();
        return builder;
    }

    /// <summary>Registers the API basic authentication middleware.</summary>
    public static WebApplicationBuilder AddApiAuthentication(
        this WebApplicationBuilder builder,
        Action<IBasicAuthenticationSchemeOptions>? basicConfig = null,
        Action<IJwtConfigurationOptions>? jwtConfig = null,
        Action<ISharedSecretAuthenticationSchemeOptions>? sharedSecretConfig = null
    )
    {
        builder.Services.AddScoped<IBasicApiAuthMiddleware, BasicApiAuthMiddleware>();
        builder.Services.AddAuthentication(Api).AddApiBasicAuthentication();
        return builder;
    }

    public static AuthenticationBuilder AddApiBasicAuthentication(
        this AuthenticationBuilder builder
    ) =>
        builder.AddScheme<ApiAuthenticationOptions, BasicApiAuthHandler>(
            ApiAuthenticationOptions.BasicAuthenticationSchemeName,
            ApiAuthenticationOptions.BasicAuthenticationSchemeName,
            _ => { }
        );

    public static WebApplication UseApiBasicAuthentication(this WebApplication app)
    {
        // app.UseAuthentication();
        // return app;
        app.UseMiddleware<IBasicApiAuthMiddleware>();
        return app;
    }
}
