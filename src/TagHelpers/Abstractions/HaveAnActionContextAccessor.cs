/*
 * HaveAnActionContextAccessor.cs
 *
 *   Created: 2024-59-16T00:59:45-05:00
 *   Modified: 2024-59-16T00:59:45-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.TagHelpers.Abstractions;

public interface IHaveAnActionContextAccessor
{
    IActionContextAccessor ActionContextAccessor { get; }
}
