/*
 * MandatoryPropertiesExtensions.cs
 *
 *   Created: 2024-13-16T00:13:49-05:00
 *   Modified: 2024-13-16T00:13:49-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.TagHelpers.Extensions;

public static class MandatoryPropertiesExtensions
{
    public static void CheckMandatoryProperties<T>(this T tagHelper)
        where T : TagHelper
    {
        foreach (var item in from pi in tagHelper.GetType().GetProperties()
                                    where pi.HasCustomAttribute<MandatoryAttribute>()
                                    select pi)
        {
            var value = item.GetValue(tagHelper);
            var htmlAttributeName = item.GetHtmlAttributeName();
            if (item.PropertyType == typeof(string) && IsNullOrEmpty((string)value))
            {
                throw new MandatoryAttributeException(htmlAttributeName, tagHelper.GetType());
            }
            if (typeof(IEnumerable).IsAssignableFrom(item.PropertyType) && !((IEnumerable)value).GetEnumerator().MoveNext())
            {
                throw new MandatoryAttributeException(htmlAttributeName, tagHelper.GetType());
            }
            if (value == null)
            {
                throw new MandatoryAttributeException(htmlAttributeName, tagHelper.GetType());
            }
        }
    }
}
