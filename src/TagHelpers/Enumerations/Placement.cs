/*
 * Placement.cs
 *
 *   Created: 2024-36-17T10:36:46-05:00
 *   Modified: 2024-36-17T10:36:47-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.TagHelpers.Enumerations;

public enum Placement
{
    [EnumInfo("top")]
    Top,

    [EnumInfo("bottom")]
    Bottom,

    [EnumInfo("left")]
    Left,

    [EnumInfo("right")]
    Right
}
