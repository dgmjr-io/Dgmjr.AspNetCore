/*
 * IJwtConfigurationOptions.cs
 *
 *   Created: 2023-04-02-04:36:58
 *   Modified: 2023-04-02-04:36:58
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Dgmjr.AspNetCore.Authentication.Options;

// [GenerateInterface(typeof(JwtBearerOptions))]
public interface IJwtConfigurationOptions
{
    string? ClaimsIssuer { get; set; }
    string? Audience { get; set; }
    TimeSpan TokenLifetime { get; set; }

    bool RequireHttpsMetadata { get; set; }

    string MetadataAddress { get; set; }
    string? Authority { get; set; }
    string Challenge { get; set; }
    global::Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents Events { get; set; }
    global::System.Net.Http.HttpMessageHandler? BackchannelHttpHandler { get; set; }
    global::System.Net.Http.HttpClient Backchannel { get; set; }
    global::System.TimeSpan BackchannelTimeout { get; set; }
    global::Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectConfiguration? Configuration { get; set; }
    global::Microsoft.IdentityModel.Protocols.IConfigurationManager<global::Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectConfiguration>? ConfigurationManager { get; set; }
    bool RefreshOnIssuerKeyNotFound { get; set; }
    global::System.Collections.Generic.IList<global::Microsoft.IdentityModel.Tokens.ISecurityTokenValidator> SecurityTokenValidators { get; }
    global::System.Collections.Generic.IList<global::Microsoft.IdentityModel.Tokens.TokenHandler> TokenHandlers { get; }
    global::Microsoft.IdentityModel.Tokens.TokenValidationParameters TokenValidationParameters { get; set; }
    bool SaveToken { get; set; }
    bool IncludeErrorDetails { get; set; }
    bool MapInboundClaims { get; set; }
    global::System.TimeSpan AutomaticRefreshInterval { get; set; }
    global::System.TimeSpan RefreshInterval { get; set; }
    bool UseSecurityTokenValidators { get; set; }
}
