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

// [GenerateInterface(typeof(JwtBearerOptions))]
public class JwtConfigurationOptions
    : JwtBearerOptions,
        IJwtConfigurationOptions,
        IAuthenticationSchemeOptions
{
    public const int DefaultTokenLifetimeMinutes = 60;

    public string Secret { get; set; } = default!;
    public string Issuer { get; set; } = default!;

    public JwtConfigurationOptions()
    {
        TokenLifetime = duration.FromMinutes(DefaultTokenLifetimeMinutes);
        ClaimsIssuer = DgmjrCt.DgmjrClaims.BaseUri;
        Audience = DgmjrCt.DgmjrClaims.BaseUri;
        AuthenticationSchemeName = AuthenticationSchemes.JwtBearer.Name;
        AuthenticationSchemeDisplayName = JwtBearerDefaults.AuthenticationScheme;
        RequireHttpsMetadata = true;
        SaveToken = true;
        base.TokenValidationParameters = new()
        {
            ValidIssuer = DgmjrCt.DgmjrClaims.BaseUri,
            ValidAudience = DgmjrCt.DgmjrClaims.BaseUri,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            RequireExpirationTime = true,
            RequireSignedTokens = true,
            RequireAudience = true,
            NameClaimType = DgmjrCt.Name.UriString,
            RoleClaimType = DgmjrCt.Role.UriString,
            AuthenticationType = AuthenticationSchemes.JwtBearer.Name,
        };
    }

    public duration TokenLifetime { get; set; }
    public string AuthenticationSchemeName { get; set; }
    public string AuthenticationSchemeDisplayName { get; set; }

    public AuthenticationScheme ToAuthenticationScheme()
    {
        return new JwtAuthenticationScheme(
            AuthenticationSchemeName,
            AuthenticationSchemeName,
            typeof(JwtAuthHandler<AppUser, AppRole>)
        );
    }

    public override void Validate()
    {
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
