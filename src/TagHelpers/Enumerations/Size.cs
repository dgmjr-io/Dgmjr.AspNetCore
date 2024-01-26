/*
 * Size.cs
 *
 *   Created: 2024-30-17T10:30:45-05:00
 *   Modified: 2024-30-17T10:30:45-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.TagHelpers.Enumerations;

public enum Size
{
    Default,

    [EnumInfo("lg")]
    Large,

    [EnumInfo("sm")]
    Small
}
