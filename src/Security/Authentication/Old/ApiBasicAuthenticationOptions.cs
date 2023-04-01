/*
 * ApiAuthorizationServerProvider.cs
 *
 *   Created: 2022-12-10-07:18:59
 *   Modified: 2022-12-10-07:18:59
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
#pragma warning disable
namespace Dgmjr.AspNetCore.Authentication;

using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;

[DebuggerDisplay($"Scheme: {{{ApiBasicAuthenticationOptions.AuthenticationSchemeName}}}")]
public class ApiBasicAuthenticationOptions : AuthenticationSchemeOptions
{
    public const string AuthenticationSchemeName = "Basic";
    public ApiBasicAuthenticationOptions()
    {
        this.ClaimsIssuer = Dgmjr.Identity.ClaimType.BaseUri.Uri;
        this.ForwardAuthenticate = AuthenticationSchemeName;
        this.ForwardChallenge = AuthenticationSchemeName;
        this.ForwardForbid = AuthenticationSchemeName;
        this.ForwardSignIn = AuthenticationSchemeName;
        this.ForwardSignOut = AuthenticationSchemeName;
        this.ForwardDefault = AuthenticationSchemeName;
        this.Audience = Dgmjr.Identity.ClaimType.BaseUri.Uri;
        this.Secret = Guid.NewGuid().ToString();
        this.TokenLifetime = TimeSpan.FromMinutes(60);
    }

    public string Secret { get; set; }
    public string Audience { get; set; }
    public TimeSpan TokenLifetime { get; set; }

    public const string AuthenticationSchemeDisplayName = "API Basic Authentication";
    public const string AuthenticationSchemeDescription =
        "Basic Authentication for the API with a username and password";
}
