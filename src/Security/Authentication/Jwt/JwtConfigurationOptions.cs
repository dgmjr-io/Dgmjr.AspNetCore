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

namespace Dgmjr.AspNetCore.Authentication.JwtBearer;

public struct JwtConfigurationOptions
{
    public JwtConfigurationOptions()
    {
        TokenLifetime = TimeSpan.FromMinutes(30);
        Issuer = Dgmjr.Identity.ClaimType.BaseUri.Uri;
        Audience = Dgmjr.Identity.ClaimType.BaseUri.Uri;
        Secret = guid.NewGuid().ToString();
    }

    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string Secret { get; set; }
    public TimeSpan TokenLifetime { get; set; }
}
