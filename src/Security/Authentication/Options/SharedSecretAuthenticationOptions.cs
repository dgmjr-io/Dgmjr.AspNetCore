/*
 * SharedSecretAuthenticationOptions.cs
 *
 *   Created: 2023-03-18-02:56:43
 *   Modified: 2023-04-03-08:38:22
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */


// #pragma warning disable
namespace Dgmjr.AspNetCore.Authentication.Options;

using System.Diagnostics;
using Dgmjr.AspNetCore.Authentication.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Options;

[DebuggerDisplay($"Scheme: {{{nameof(IAuthenticationSchemeOptions.AuthenticationSchemeName)}}}")]
public class SharedSecretAuthenticationOptions
    : AuthenticationSchemeOptions,
        ISharedSecretAuthenticationSchemeOptions
{
    public SharedSecretAuthenticationOptions()
    {
        ClaimsIssuer = DgmjrCt.DgmjrClaims.UriString;
        Secret = guid.NewGuid().ToByteArray().ToHexString();
        UserId = DefaultUserIdForSharedSecret;
        ForwardAuthenticate = SharedSecretAuthenticationSchemeName;
        ForwardChallenge = SharedSecretAuthenticationSchemeName;
        ForwardForbid = SharedSecretAuthenticationSchemeName;
        ForwardSignIn = SharedSecretAuthenticationSchemeName;
        ForwardSignOut = SharedSecretAuthenticationSchemeName;
        ForwardDefault = SharedSecretAuthenticationSchemeName;
        ((ISharedSecretAuthenticationSchemeOptions)this).AuthenticationSchemeName =
            SharedSecretAuthenticationSchemeName;
        ((ISharedSecretAuthenticationSchemeOptions)this).AuthenticationSchemeDisplayName =
            AuthenticationSchemeDisplayName;
    }

    public string Audience { get; set; } = string.Empty;

    public long UserId { get; set; }

    public string Secret { get; set; } = string.Empty;
    string IAuthenticationSchemeOptions.AuthenticationSchemeName { get; set; } =
        SharedSecretAuthenticationSchemeName;
    string IAuthenticationSchemeOptions.AuthenticationSchemeDisplayName { get; set; } =
        AuthenticationSchemeDisplayName;

    public const int DefaultUserIdForSharedSecret = -1;
    public const string SharedSecretAuthenticationSchemeName = "SharedSecret";
    public const string AuthenticationSchemeDisplayName = "Shared Secret";
    public const string AuthenticationSchemeDescription =
        "Insecure authentication with a common shared secret";

    public AuthenticationScheme ToAuthenticationScheme()
    {
        throw new NotImplementedException();
    }

    public override void Validate()
    {
        if (IsNullOrWhiteSpace(Secret))
        {
            throw new ArgumentNullException(
                nameof(Secret),
                "The JWT Secret cannot be null or empty."
            );
        }

        if (IsNullOrWhiteSpace(ClaimsIssuer))
        {
            throw new ArgumentNullException(
                nameof(ClaimsIssuer),
                "The JWT Claims Issuer cannot be null or empty."
            );
        }

        if (IsNullOrWhiteSpace(Audience))
        {
            throw new ArgumentNullException(
                nameof(Audience),
                "The JWT Audience cannot be null or empty."
            );
        }
    }

    public override void Validate(string scheme)
    {
        Validate();
    }
}
