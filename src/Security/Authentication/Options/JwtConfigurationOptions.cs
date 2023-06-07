/*
 * JwtConfigurationOptions.cs
 *
 *   Created: 2023-03-29-04:13:06
 *   Modified: 2023-03-29-04:13:06
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */


using Dgmjr.AspNetCore.Authentication.Handlers;
using Dgmjr.AspNetCore.Authentication.Schemes;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Options;
using Microsoft.IdentityModel.Tokens;

namespace Dgmjr.AspNetCore.Authentication.Options;

public class JwtConfigurationOptions
    : JwtBearerOptions,
        IJwtConfigurationOptions,
        IAuthenticationSchemeOptions
{
    public const int DefaultTokenLifetimeMinutes = 60;

    public JwtConfigurationOptions()
    {
        TokenLifetime = TimeSpan.FromMinutes(DefaultTokenLifetimeMinutes);
        ClaimsIssuer = DgmjrId.ClaimType.BaseUri.Uri;
        Audience = DgmjrId.ClaimType.BaseUri.Uri;
        AuthenticationSchemeName = Constants.AuthenticationSchemes.JwtBearer.Name;
        AuthenticationSchemeDisplayName = JwtBearerDefaults.AuthenticationScheme;
        RequireHttpsMetadata = true;
        SaveToken = true;
        base.TokenValidationParameters = new()
        {
            ValidIssuer = DgmjrId.ClaimType.BaseUri.Uri,
            ValidAudience = DgmjrId.ClaimType.BaseUri.Uri,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            RequireExpirationTime = true,
            RequireSignedTokens = true,
            RequireAudience = true,
            NameClaimType = DgmjrId.ClaimType.NameClaim.Uri,
            RoleClaimType = DgmjrId.ClaimType.Role.Uri,
            AuthenticationType = Bearer,
        };
    }

    public TimeSpan TokenLifetime { get; set; }
    public string AuthenticationSchemeName { get; set; }
    public string AuthenticationSchemeDisplayName { get; set; }

    public AuthenticationScheme ToAuthenticationScheme()
    {
        return new JwtAuthenticationScheme(
            AuthenticationSchemeName,
            AuthenticationSchemeName,
            typeof(JwtAuthHandler)
        );
    }
}
