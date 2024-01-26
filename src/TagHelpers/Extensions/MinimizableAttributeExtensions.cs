/*
 * MinimizableAttributeExtensions.cs
 *
 *   Created: 2024-07-16T00:07:41-05:00
 *   Modified: 2024-07-16T00:07:41-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.TagHelpers.Extensions;

public static class MinimizableAttributeExtensions
{
    public static void FillMinimizableAttributes<T>(this T target, TagHelperContext context)
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
            var item in from pI in target.GetType().GetProperties()
                        where pI.GetCustomAttribute<HtmlAttributeMinimizableAttribute>() != null
                        select pI
        )
        {
            var htmlAttributeName = item.GetHtmlAttributeName();
            if (context.AllAttributes.ContainsName(htmlAttributeName))
            {
                var tagHelperAttribute = context.AllAttributes[htmlAttributeName];
                if (tagHelperAttribute.Value is bool)
                {
                    item.SetValue(target, tagHelperAttribute.Value);
                }
                else
                {
                    item.SetValue(
                        target,
                        !(tagHelperAttribute.Value ?? "").ToString().Equals("false")
                    );
                }
            }
        }
    }

    public static void RemoveMinimizableAttributes<T>(this T @this, TagHelperOutput output)
    {
        output.Attributes.RemoveAll(
            (
                from pI in typeof(T).GetTypeInfo().GetProperties()
                where pI.GetCustomAttribute<HtmlAttributeMinimizableAttribute>() != null
                select pI.GetHtmlAttributeName()
            ).ToArray()
        );
    }
}
