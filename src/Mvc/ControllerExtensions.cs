/*
 * ControllerExtensions.cs
 *
 *   Created: 2024-13-16T04:13:05-05:00
 *   Modified: 2024-13-16T04:13:05-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Microsoft.AspNetCore.Mvc;

public static class ControllerExtensions
{
    public static IActionResult Result<T>(
        this ControllerBase controller,
        T value,
        string contentType
    ) => new Result<T>(value, contentType).Convert();
}
