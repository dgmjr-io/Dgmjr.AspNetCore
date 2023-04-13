/* 
 * JwtAuthenticationScheme.cs
 * 
 *   Created: 2023-04-04-03:10:50
 *   Modified: 2023-04-04-03:10:50
 * 
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *   
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Abstractions;

namespace Dgmjr.AspNetCore.Authentication.Schemes;

public class JwtAuthenticationScheme : AuthenticationScheme, IAuthenticationScheme
{
    public JwtAuthenticationScheme(string name, string? displayName, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] type handlerType) : base(name, displayName, handlerType)
    {
    }
}
