/*
 * ContextClassAttributeExtensions.cs
 *
 *   Created: 2024-04-16T00:04:30-05:00
 *   Modified: 2024-04-16T00:04:30-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.TagHelpers.Extensions;

public static class ContextClassAttributeExtensions
{
    public static void SetContext<T>(this T target, TagHelperContext context)
        where T : TagHelper
    {
        if (target == null)
        {
            throw new ArgumentNullException(nameof(target));
        }
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }
        var type = typeof(T);
        var customAttribute = type.GetTypeInfo().GetCustomAttribute<ContextClassAttribute>();
        if (customAttribute != null)
        {
            if (IsNullOrEmpty(customAttribute.Key))
            {
                context.SetContextItem(customAttribute.Type ?? type, target);
            }
            else
            {
                context.SetContextItem(customAttribute.Key, target);
            }
        }
    }
}
