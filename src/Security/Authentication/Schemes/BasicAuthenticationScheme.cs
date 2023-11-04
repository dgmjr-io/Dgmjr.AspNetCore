/*
 * BasicAuthenticationScheme.cs
 *
 *   Created: 2023-04-04-12:58:12
 *   Modified: 2023-04-04-12:58:12
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System.Net;
using Dgmjr.AspNetCore.Authentication.Handlers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Abstractions;

namespace Dgmjr.AspNetCore.Authentication.Schemes;

public class BasicAuthenticationScheme : AuthenticationScheme, IAuthenticationScheme
{
    public BasicAuthenticationScheme(
        string name = Constants.AuthenticationSchemes.Basic.Name,
        string? displayName = Constants.AuthenticationSchemes.Basic.DisplayName,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
            type? handlerType = default
    )
        : base(name, displayName, handlerType ?? typeof(BasicApiAuthHandler<AppUser, AppRole>)) { }
}
