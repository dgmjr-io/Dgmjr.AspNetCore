/*
 * Theme.cs
 *
 *   Created: 2024-52-15T17:52:35-05:00
 *   Modified: 2024-52-15T17:52:35-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.TagHelpers.Enumerations;

public enum Theme
{
    Default,
    @default = Default,

    [EnumInfo("dark")]
    Dark,

    [EnumInfo("dark")]
    dark = Dark,

    [EnumInfo("light")]
    Light,

    [EnumInfo("light")]
    light = Light
}
