/*
 * ContextAttributeExtensions.cs
 *
 *   Created: 2024-06-16T00:06:13-05:00
 *   Modified: 2024-06-16T00:06:13-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.TagHelpers.Extensions;

public static class ContextAttributeExtensions
{
    public static void SetContexts<T>(this T target, TagHelperContext context)
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
        foreach (
            var item in from pi in typeof(T)
                .GetTypeInfo()
                .GetProperties(
                    BindingFlags.Instance
                        | BindingFlags.Static
                        | BindingFlags.Public
                        | BindingFlags.NonPublic
                )
                        where pi.HasCustomAttribute<ContextAttribute>()
                        select pi
        )
        {
            var customAttribute = item.GetCustomAttribute<ContextAttribute>();
            if (IsNullOrEmpty(customAttribute.Key))
            {
                var contextItem = context.GetContextItem(
                    item.PropertyType,
                    customAttribute.UseInherited
                );
                if (contextItem != null)
                {
                    item.SetValue(target, contextItem);
                }
                if (customAttribute.RemoveContext)
                {
                    context.RemoveContextItem(item.PropertyType, customAttribute.UseInherited);
                }
            }
            else
            {
                item.SetValue(
                    target,
                    context.GetContextItem(item.PropertyType, customAttribute.Key)
                );
                if (customAttribute.RemoveContext)
                {
                    context.RemoveContextItem(customAttribute.Key);
                }
            }
        }
    }
}
