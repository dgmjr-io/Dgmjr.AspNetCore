/*
 * BasicAuthenticationSchemeOptions.cs
 *
 *   Created: 2023-04-02-08:17:37
 *   Modified: 2023-04-02-08:17:37
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using Microsoft.AspNetCore.Authentication;

namespace Dgmjr.AspNetCore.Authentication.Options;

using Dgmjr.AspNetCore.Authentication.Handlers;
using Microsoft.AspNetCore.Authentication.Options;

public class BasicAuthenticationSchemeOptions
    : AuthenticationSchemeOptions,
        IBasicAuthenticationSchemeOptions
{
    public const string Basic = nameof(Basic);
    public const string DefaultAuthenticationSchemeName = Basic;
    public const string DefaultAuthenticationSchemeDisplayName =
        $"{Basic} Authentication (Client ID + Client Secret)";

    public BasicAuthenticationSchemeOptions()
    {
        ((IBasicAuthenticationSchemeOptions)this).AuthenticationSchemeName = Basic;
        ClaimsIssuer = DgmjrCt.DgmjrClaims.UriString;
        ForwardAuthenticate = ((IBasicAuthenticationSchemeOptions)this).AuthenticationSchemeName;
        ForwardChallenge = ((IBasicAuthenticationSchemeOptions)this).AuthenticationSchemeName;
        ForwardDefault = ((IBasicAuthenticationSchemeOptions)this).AuthenticationSchemeName;
        ForwardForbid = ((IBasicAuthenticationSchemeOptions)this).AuthenticationSchemeName;
        ForwardForbid = ((IBasicAuthenticationSchemeOptions)this).AuthenticationSchemeName;
        ForwardSignIn = ((IBasicAuthenticationSchemeOptions)this).AuthenticationSchemeName;
        ForwardSignOut = ((IBasicAuthenticationSchemeOptions)this).AuthenticationSchemeName;
    }

    public AuthenticationScheme ToAuthenticationScheme() =>
        new(
            ((IBasicAuthenticationSchemeOptions)this).AuthenticationSchemeName,
            ((IBasicAuthenticationSchemeOptions)this).AuthenticationSchemeDisplayName,
            typeof(BasicApiAuthHandler<AppUser, AppRole>)
        );

    AuthenticationScheme IAuthenticationSchemeOptions.ToAuthenticationScheme()
    {
        throw new NotImplementedException();
    }

    string IAuthenticationSchemeOptions.AuthenticationSchemeName { get; set; }
    string IAuthenticationSchemeOptions.AuthenticationSchemeDisplayName { get; set; }

    public override void Validate() { }

    public override void Validate(string scheme)
    {
        Validate();
    }
}
