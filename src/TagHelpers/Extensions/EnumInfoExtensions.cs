/*
 * EnumInfoExtensions.cs
 *
 *   Created: 2024-54-15T17:54:58-05:00
 *   Modified: 2024-54-15T17:54:58-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.TagHelpers.Extensions;

public static class EnumExtensions
{
    public static EnumInfoAttribute? GetEnumInfo(this Enum e)
    {
        var memberInfo = e.GetType().GetMember(e.ToString()).FirstOrDefault();
        if (memberInfo != null)
        {
            return memberInfo.GetCustomAttribute<EnumInfoAttribute>();
        }
        throw new InvalidOperationException(
            "It is not possible to read EnumInfoAttribute from enumeration."
        );
    }

    public static string? GetName(this Enum e)
    {
        try
        {
            return e.GetEnumInfo()?.Name ?? e.ToString();
        }
        catch
        {
            return e.ToString();
        }
    }
}
