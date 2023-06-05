/*
 * IAuthenticationHandler.cs
 *
 *   Created: 2023-05-07-05:14:17
 *   Modified: 2023-05-07-05:14:17
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.Authentication.Handlers.Abstractions;

[GenerateInterface(typeof(Microsoft.AspNetCore.Authentication.AuthenticationHandler<>))]
public partial interface IAuthenticationHandler<TOptions> { }
