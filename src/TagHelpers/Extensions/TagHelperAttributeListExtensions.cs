/*
 * TagHelperAttributeListExtensions.cs
 *
 *   Created: 2024-43-15T17:43:40-05:00
 *   Modified: 2024-43-15T17:43:40-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.TagHelpers.Extensions;

public static class TagHelperAttributeListExtensions
{
    public static bool RemoveAll(this TagHelperAttributeList attributeList, params string[] attributeNames)
    {
        return attributeNames.Aggregate(seed: false, (bool current, string name) => attributeList.RemoveAll(name) || current);
    }

    public static void AddAriaAttribute(this TagHelperAttributeList attributeList, string attributeName, object value)
    {
        attributeList.Add("aria-" + attributeName, value);
    }

    public static void AddDataAttribute(this TagHelperAttributeList attributeList, string attributeName, object value)
    {
        attributeList.Add("data-" + attributeName, value);
    }
}
