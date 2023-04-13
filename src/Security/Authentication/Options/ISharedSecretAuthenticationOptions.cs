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

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Options;

namespace Dgmjr.AspNetCore.Authentication.Options;

public partial interface ISharedSecretAuthenticationSchemeOptions : IAuthenticationSchemeOptions
{
    string Secret { get; set; }
    long UserId { get; set; }
}
