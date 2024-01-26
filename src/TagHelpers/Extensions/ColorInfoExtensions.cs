/*
 * ColorInfoExtensions.cs
 *
 *   Created: 2024-00-15T18:00:46-05:00
 *   Modified: 2024-00-15T18:00:46-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.TagHelpers.Extensions;

using Dgmjr.AspNetCore.TagHelpers.Enumerations;

internal static class ColorInfoExtensions
{
    public static ColorInfo GetColorInfo(this Color color)
    {
        var memberInfo = color.GetType().GetMember(color.ToString()).FirstOrDefault();

        return memberInfo != null
            ? new(memberInfo.GetCustomAttribute<ColorInfoAttribute>())
            : throw new InvalidOperationException(
                "It is not possible to read ColorInfoAttribute from enumeration."
            );
    }

    public static string? GetName(this Color color)
    {
        try
        {
            return color.GetColorInfo().Name ?? color.ToString();
        }
        catch
        {
            return color.ToString();
        }
    }
}

public readonly record struct ColorInfo(ColorInfoAttribute? ColorInfoAttribute)
{
    public string Name => ColorInfoAttribute?.Name ?? string.Empty;

public string TextCssClass => ColorInfoAttribute?.TextCssClass ?? string.Empty;

public string BackgroundCssClass => ColorInfoAttribute?.BackgroundCssClass ?? string.Empty;

public string BorderCssClass => ColorInfoAttribute?.BorderCssClass ?? string.Empty;
}
