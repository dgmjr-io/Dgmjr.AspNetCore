/*
 * ColorInfo.cs
 *
 *   Created: 2024-59-15T17:59:25-05:00
 *   Modified: 2024-59-15T17:59:26-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.TagHelpers.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public class ColorInfoAttribute : EnumInfoAttribute
{
    public string TextCssClass { get; set; }

    public string BackgroundCssClass { get; set; }

    public string BorderCssClass { get; set; }

    public ColorInfoAttribute(string name)
        : base(name)
    {
    }
}
