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
namespace Dgmjr.AspNetCore.Authentication.Options;

using System.Diagnostics;
using Dgmjr.AspNetCore.Authentication.Options;
using Dgmjr.AspNetCore.Authentication.Schemes;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Options;
using Microsoft.Identity.Client;
using static Dgmjr.AspNetCore.Authentication.Constants;

[DebuggerDisplay($"Scheme: {{{nameof(AuthenticationSchemeName)}}}, Forward: {{{nameof(ForwardAuthenticate)}/{{{nameof(ForwardChallenge)}}}/{{{nameof(ForwardForbid)}}}/{{{nameof(ForwardSignIn)}}}/{{{nameof(ForwardSignOut)}}}/{{{nameof(ForwardDefault)}}}, Issuer: {{{nameof(ClaimsIssuer)}}}, Audience: {{{nameof(Audience)}}}, Lifetime: {{{nameof(TokenLifetime)}}}, Secret: {{{nameof(Secret)}}}")]
public class ApiAuthenticationOptions : AuthenticationSchemeOptions, IAuthenticationSchemeOptions, IJwtConfigurationOptions, IBasicAuthenticationSchemeOptions, ISharedSecretAuthenticationSchemeOptions
{
    public string AuthenticationSchemeName { get; set; } = ApiAuthenticationSchemeName;
    public string AuthenticationSchemeDisplayName { get; set; } = ApiAuthenticationSchemeDisplayName;

    public ApiAuthenticationOptions()
    {
        this.ClaimsIssuer = Dgmjr.Identity.ClaimType.BaseUri.Uri;
        this.ForwardAuthenticate = BasicAuthenticationSchemeName;
        this.ForwardChallenge = BasicAuthenticationSchemeName;
        this.ForwardForbid = BasicAuthenticationSchemeName;
        this.ForwardSignIn = BasicAuthenticationSchemeName;
        this.ForwardSignOut = BasicAuthenticationSchemeName;
        this.ForwardDefault = BasicAuthenticationSchemeName;
    }

    public ISharedSecretAuthenticationSchemeOptions SharedSecret { get; set; } = new SharedSecretAuthenticationOptions();
    public IBasicAuthenticationSchemeOptions Basic { get; set; } = new BasicAuthenticationSchemeOptions();
    public IJwtConfigurationOptions Jwt { get; set; } = new JwtConfigurationOptions();


    #region IJwtConfigurationOptions
    string? IJwtConfigurationOptions.ClaimsIssuer { get => Jwt.ClaimsIssuer; set => Jwt.ClaimsIssuer = value; }
    string IJwtConfigurationOptions.Audience { get => Jwt.Audience; set => Jwt.Audience = value; }
    string IJwtConfigurationOptions.Secret { get => Jwt.Secret; set => Jwt.Secret = value; }
    TimeSpan IJwtConfigurationOptions.TokenLifetime { get => Jwt.TokenLifetime; set => Jwt.TokenLifetime = value; }
    #endregion

    #region ISharedSecretAuthenticationSchemeOptions
    string ISharedSecretAuthenticationSchemeOptions.Secret { get => this.SharedSecret.Secret; set => SharedSecret.Secret = value; }
    long ISharedSecretAuthenticationSchemeOptions.UserId { get => SharedSecret.UserId; set => SharedSecret.UserId = value; }

    public AuthenticationScheme ToAuthenticationScheme()
    {
        return new ApiMultiAuthenticationScheme(this.AuthenticationSchemeName, this.AuthenticationSchemeDisplayName, typeof(ApiMultiAuthenticationHandler));
    }
    #endregion
}
