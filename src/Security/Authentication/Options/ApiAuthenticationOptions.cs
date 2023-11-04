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
using static Dgmjr.AspNetCore.Authentication.Constants.AuthenticationSchemes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;

public class ApiAuthenticationOptions
    : AuthenticationSchemeOptions,
        IAuthenticationSchemeOptions,
        IJwtConfigurationOptions,
        IBasicAuthenticationSchemeOptions,
        ISharedSecretAuthenticationSchemeOptions
{
    public const string BasicAuthenticationSchemeName = AuthenticationSchemes.Basic.Name;
    public const string BasicAuthenticationSchemeDisplayName = AuthenticationSchemes
        .Basic
        .DisplayName;

    public string AuthenticationSchemeName { get; set; } = Api.Name;
    public string AuthenticationSchemeDisplayName { get; set; } = Api.DisplayName;

    public ApiAuthenticationOptions()
    {
        this.ClaimsIssuer = Dgmjr.Identity.ClaimTypes.DgmjrClaims.BaseUri;
        this.ForwardAuthenticate = Basic.AuthenticationSchemeName;
        this.ForwardChallenge = Basic.AuthenticationSchemeName;
        this.ForwardForbid = Basic.AuthenticationSchemeName;
        this.ForwardSignIn = Basic.AuthenticationSchemeName;
        this.ForwardSignOut = Basic.AuthenticationSchemeName;
        this.ForwardDefault = Basic.AuthenticationSchemeName;
    }

    public ISharedSecretAuthenticationSchemeOptions SharedSecret { get; set; } =
        new SharedSecretAuthenticationOptions();
    public IBasicAuthenticationSchemeOptions Basic { get; set; } =
        new BasicAuthenticationSchemeOptions();
    public IJwtConfigurationOptions Jwt { get; set; } = new JwtConfigurationOptions();

    #region IJwtConfigurationOptions
    string? IJwtConfigurationOptions.ClaimsIssuer
    {
        get => Jwt.ClaimsIssuer;
        set => Jwt.ClaimsIssuer = value;
    }
    public duration TokenLifetime
    {
        get => Jwt.TokenLifetime;
        set => Jwt.TokenLifetime = value;
    }
    public duration AutomaticRefreshInterval
    {
        get => Jwt.AutomaticRefreshInterval;
        set => Jwt.AutomaticRefreshInterval = value;
    }
    public duration RefreshInterval
    {
        get => Jwt.RefreshInterval;
        set => Jwt.RefreshInterval = value;
    }
    public bool RequireHttpsMetadata
    {
        get => Jwt.RequireHttpsMetadata;
        set => Jwt.RequireHttpsMetadata = value;
    }
    public bool RefreshOnIssuerKeyNotFound
    {
        get => Jwt.RefreshOnIssuerKeyNotFound;
        set => Jwt.RefreshOnIssuerKeyNotFound = value;
    }
    public bool SaveToken
    {
        get => Jwt.SaveToken;
        set => Jwt.SaveToken = value;
    }
    public bool IncludeErrorDetails
    {
        get => Jwt.IncludeErrorDetails;
        set => Jwt.IncludeErrorDetails = value;
    }
    public bool MapInboundClaims
    {
        get => Jwt.MapInboundClaims;
        set => Jwt.MapInboundClaims = value;
    }
    public bool UseSecurityTokenValidators
    {
        get => Jwt.UseSecurityTokenValidators;
        set => Jwt.UseSecurityTokenValidators = value;
    }
    public string MetadataAddress
    {
        get => Jwt.MetadataAddress;
        set => Jwt.MetadataAddress = value;
    }
    public string Authority
    {
        get => Jwt.Authority;
        set => Jwt.Authority = value;
    }
    public string Challenge
    {
        get => Jwt.Challenge;
        set => Jwt.Challenge = value;
    }
    public string Audience
    {
        get => Jwt.Audience;
        set => Jwt.Audience = value;
    }
    public virtual global::System.Net.Http.HttpMessageHandler BackchannelHttpHandler
    {
        get => Jwt.BackchannelHttpHandler;
        set => Jwt.BackchannelHttpHandler = value;
    }
    public virtual global::System.Net.Http.HttpClient Backchannel
    {
        get => Jwt.Backchannel;
        set => Jwt.Backchannel = value;
    }
    public virtual duration BackchannelTimeout
    {
        get => Jwt.BackchannelTimeout;
        set => Jwt.BackchannelTimeout = value;
    }
    public virtual JwtBearerEvents Events
    {
        get => Jwt.Events;
        set => Jwt.Events = value;
    }
    public Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectConfiguration Configuration
    {
        get => Jwt.Configuration;
        set => Jwt.Configuration = value;
    }
    public Microsoft.IdentityModel.Protocols.IConfigurationManager<Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectConfiguration> ConfigurationManager
    {
        get => Jwt.ConfigurationManager;
        set => Jwt.ConfigurationManager = value;
    }
    public IList<Microsoft.IdentityModel.Tokens.ISecurityTokenValidator> SecurityTokenValidators =>
        Jwt.SecurityTokenValidators;
    public IList<Microsoft.IdentityModel.Tokens.TokenHandler> TokenHandlers => Jwt.TokenHandlers;
    public Microsoft.IdentityModel.Tokens.TokenValidationParameters TokenValidationParameters
    {
        get => Jwt.TokenValidationParameters;
        set => Jwt.TokenValidationParameters = value;
    }
    #endregion

    #region ISharedSecretAuthenticationSchemeOptions
    string ISharedSecretAuthenticationSchemeOptions.Secret
    {
        get => this.SharedSecret.Secret;
        set => SharedSecret.Secret = value;
    }
    long ISharedSecretAuthenticationSchemeOptions.UserId
    {
        get => SharedSecret.UserId;
        set => SharedSecret.UserId = value;
    }

    public AuthenticationScheme ToAuthenticationScheme()
    {
        return new ApiMultiAuthenticationScheme(
            this.AuthenticationSchemeName,
            this.AuthenticationSchemeDisplayName,
            typeof(Handlers.ApiMultiAuthenticationHandler)
        );
    }
    #endregion

    public virtual void Validate()
    {
        if (IsNullOrWhiteSpace(this.AuthenticationSchemeName))
        {
            throw new ArgumentNullException(
                nameof(this.AuthenticationSchemeName),
                "The Authentication Scheme Name cannot be null or empty."
            );
        }

        if (IsNullOrWhiteSpace(this.AuthenticationSchemeDisplayName))
        {
            throw new ArgumentNullException(
                nameof(this.AuthenticationSchemeDisplayName),
                "The Authentication Scheme Display Name cannot be null or empty."
            );
        }

        if (IsNullOrWhiteSpace(this.SharedSecret.Secret))
        {
            throw new ArgumentNullException(
                nameof(this.SharedSecret.Secret),
                "The Shared Secret cannot be null or empty."
            );
        }

        if (IsNullOrWhiteSpace(this.Jwt.ClaimsIssuer))
        {
            throw new ArgumentNullException(
                nameof(this.Jwt.ClaimsIssuer),
                "The JWT Claims Issuer cannot be null or empty."
            );
        }

        if (IsNullOrWhiteSpace(this.Jwt.Audience))
        {
            throw new ArgumentNullException(
                nameof(this.Jwt.Audience),
                "The JWT Audience cannot be null or empty."
            );
        }
    }

    public virtual void Validate(string scheme)
    {
        Validate();
    }
}
