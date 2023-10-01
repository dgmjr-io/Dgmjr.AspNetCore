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

[GenerateInterface(typeof(AuthenticationSchemeOptions))]
public partial interface IAuthenticationSchemeOptions
{
    string AuthenticationSchemeName { get; set; }
    string AuthenticationSchemeDisplayName { get; set; }
    AuthenticationScheme ToAuthenticationScheme();
}
