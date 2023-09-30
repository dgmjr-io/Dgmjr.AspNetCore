/*
 * IAuthenticationSchemeOptions.cs
 *
 *   Created: 2023-04-02-04:39:15
 *   Modified: 2023-04-02-04:39:15
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Microsoft.AspNetCore.Authentication.Options;

using Microsoft.AspNetCore.Authentication;

// [GenerateInterface(typeof(AuthenticationSchemeOptions))]
public partial interface IAuthenticationSchemeOptions
{
    string AuthenticationSchemeName { get; set; }
    string AuthenticationSchemeDisplayName { get; set; }
    AuthenticationScheme ToAuthenticationScheme();

    string? ClaimsIssuer { get; set; }
    object? Events { get; set; }
    type? EventsType { get; set; }
    string? ForwardDefault { get; set; }
    string? ForwardAuthenticate { get; set; }
    string? ForwardChallenge { get; set; }
    string? ForwardForbid { get; set; }
    string? ForwardSignIn { get; set; }
    string? ForwardSignOut { get; set; }
    Func<HttpContext, string?>? ForwardDefaultSelector { get; set; }
    TimeProvider? TimeProvider { get; set; }
    void Validate();
    void Validate(string scheme);
}
