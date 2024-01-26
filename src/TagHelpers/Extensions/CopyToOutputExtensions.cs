/*
 * CopyToOutputExtensions.cs
 *
 *   Created: 2024-00-16T00:00:28-05:00
 *   Modified: 2024-00-16T00:00:28-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.TagHelpers.Extensions;

public static class CopyToOutputExtensions
{
    public static void CopyPropertiesToOutput<T>(this T target, TagHelperOutput output)
        where T : TagHelper
    {
        if (target == null)
        {
            throw new ArgumentNullException(nameof(target));
        }
        if (output == null)
        {
            throw new ArgumentNullException(nameof(output));
        }
        foreach (
            var item in from pI in target.GetType().GetProperties()
                        where pI.HasCustomAttribute<CopyToOutputAttribute>()
                        select pI
        )
        {
            var obj = item.GetValue(target);
            if (item.PropertyType.IsAssignableFrom(typeof(bool)))
            {
                obj = obj?.ToString().ToLower();
            }
            foreach (var customAttribute in item.GetCustomAttributes<CopyToOutputAttribute>())
            {
                if (obj != null || customAttribute.CopyIfValueIsNull)
                {
                    output.Attributes.Add(
                        customAttribute.Prefix
                            + (customAttribute.OutputAttributeName ?? item.GetHtmlAttributeName())
                            + customAttribute.Suffix,
                        obj
                    );
                }
            }
        }
    }
}
