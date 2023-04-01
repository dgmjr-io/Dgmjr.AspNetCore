/* 
 * GeneratedAuthenticationSchemeOptions.cs
 * 
 *   Created: 2023-04-01-02:39:31
 *   Modified: 2023-04-01-02:39:31
 * 
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *   
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using Microsoft.AspNetCore.Authentication;

namespace Dgmjr.AspNetCore.Authentication.Generated;

public class GeneratedAuthenticationSchemeOptions : AuthenticationSchemeOptions
{
    public string Secret { get; set; } = default!;
    public string Issuer { get; set; } = Dgmjr.Identity.ClaimType.BaseUri.Uri;
    public string Audience { get; set; } = Dgmjr.Identity.ClaimType.BaseUri.Uri;
    public TimeSpan TokenLifetime { get; set; } = TimeSpan.FromMinutes(60);
}
