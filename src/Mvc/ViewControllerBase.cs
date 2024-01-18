/*
 * ViewControllerBase.cs
 *
 *   Created: 2024-12-16T04:12:28-05:00
 *   Modified: 2024-12-16T04:12:28-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;

public class ViewControllerBase : Controller
{
    public IActionResult Result<T>(T value, string contentType) =>
        ControllerExtensions.Result(this, value, contentType);
}
