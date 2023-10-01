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

[GenerateInterface(typeof(JwtBearerOptions))]
public interface IJwtConfigurationOptions
{
    string? ClaimsIssuer { get; set; }
    string? Audience { get; set; }
    TimeSpan TokenLifetime { get; set; }
}
