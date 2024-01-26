/*
 * ConvertUrlAttributeExtensions.cs
 *
 *   Created: 2024-03-16T00:03:29-05:00
 *   Modified: 2024-03-16T00:03:29-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.TagHelpers.Extensions;

public static class ConvertUrlAttributeExtensions
{
    public static void ConvertUrls<T>(this T target, IActionContextAccessor accessor)
        where T : TagHelper
    {
        if (target == null)
        {
            throw new ArgumentNullException(nameof(target));
        }
        var convertVirtualUrlAttributeProperties = (from pi in target.GetType().GetProperties()
                                                    where pi.HasCustomAttribute<ConvertVirtualUrlAttribute>()
                                                    select pi).ToList();
        if (!convertVirtualUrlAttributeProperties.Any())
        {
            return;
        }
        if (accessor == null)
        {
            throw new ArgumentNullException(nameof(accessor));
        }
        var urlHelper = new UrlHelper(accessor.ActionContext);
        foreach (var item in convertVirtualUrlAttributeProperties)
        {
            if (item.PropertyType != typeof(string))
            {
                throw new ArgumentException("Decorated property must be a string");
            }
            item.SetValue(target, urlHelper.Content((string)item.GetValue(target)));
        }
    }
}
