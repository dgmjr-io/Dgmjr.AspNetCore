/*
 * AuthorizationAttributes.cs
 *
 *   Created: 2023-01-05-07:23:12
 *   Modified: 2023-01-05-07:23:12
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.Authorization;

using Microsoft.AspNetCore.Authorization;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public class AdminAttribute : AuthorizeAttribute
{
    public AdminAttribute() : base() => Roles = DgmjrR.Admin.Uri;
}

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public class AuthenticatedUserAttribute : AuthorizeAttribute
{
    public AuthenticatedUserAttribute() : base() => Roles = DgmjrR.User.Uri;
}
