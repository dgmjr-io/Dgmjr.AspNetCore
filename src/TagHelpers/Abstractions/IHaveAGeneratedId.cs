/*
 * IHaveAGeneratedId.cs
 *
 *   Created: 2024-17-16T00:17:11-05:00
 *   Modified: 2024-17-16T00:17:12-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.TagHelpers.Abstractions;

public interface IHaveAGeneratedId
{
    string GeneratedId { get; set; }
}
