/*
 * BasicApiAuthMiddleware.cs
 *
 *   Created: 2022-12-14-05:48:24
 *   Modified: 2022-12-14-05:48:25
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.Authentication;
using Dgmjr.Identity;
using Microsoft.AspNetCore.Http;

public interface IBasicApiAuthMiddleware : IMiddleware
{
    UserManager UserManager { get; }
}
