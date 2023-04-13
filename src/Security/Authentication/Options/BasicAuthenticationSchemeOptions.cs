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

public class BasicAuthenticationSchemeOptions : AuthenticationSchemeOptions, IBasicAuthenticationSchemeOptions
{
    public const string Basic = nameof(Basic);
    public const string DefaultAithenticationSchemeName = Basic;
    public const string DefaultAuthenticationSchemeDisplayName = $"{Basic} Authentication (Client ID + Client Secret)";

    public BasicAuthenticationSchemeOptions()
    {
        ((IBasicAuthenticationSchemeOptions)this).AuthenticationSchemeName = Basic;
        this.ClaimsIssuer = DgmjrId.ClaimType.BaseUri.Uri;
        this.ForwardAuthenticate = ((IBasicAuthenticationSchemeOptions)this).AuthenticationSchemeName;
        this.ForwardChallenge = ((IBasicAuthenticationSchemeOptions)this).AuthenticationSchemeName;
        this.ForwardDefault = ((IBasicAuthenticationSchemeOptions)this).AuthenticationSchemeName;
        this.ForwardForbid = ((IBasicAuthenticationSchemeOptions)this).AuthenticationSchemeName;
        this.ForwardForbid = ((IBasicAuthenticationSchemeOptions)this).AuthenticationSchemeName;
        this.ForwardSignIn = ((IBasicAuthenticationSchemeOptions)this).AuthenticationSchemeName;
        this.ForwardSignOut= ((IBasicAuthenticationSchemeOptions)this).AuthenticationSchemeName;
    }

    public  AuthenticationScheme ToAuthenticationScheme() 
        
        => new (((IBasicAuthenticationSchemeOptions)this).AuthenticationSchemeName, ((IBasicAuthenticationSchemeOptions)this).AuthenticationSchemeDisplayName, typeof(BasicApiAuthHandler));

    AuthenticationScheme IAuthenticationSchemeOptions.ToAuthenticationScheme()
    {
        throw new NotImplementedException();
    }

    string IAuthenticationSchemeOptions.AuthenticationSchemeName { get; set; }
    string IAuthenticationSchemeOptions.AuthenticationSchemeDisplayName { get; set; }
}
