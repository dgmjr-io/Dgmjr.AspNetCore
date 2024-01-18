/*
 * ControllerBase.cs
 *
 *   Created: 2024-10-16T04:10:42-05:00
 *   Modified: 2024-10-16T04:10:42-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;

public class ApiControllerBase : ControllerBase
{
    public IActionResult Result<T>(T value, string contentType) =>
        ControllerExtensions.Result(this, value, contentType);
}
