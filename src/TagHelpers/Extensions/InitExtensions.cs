/*
 * InitExtensions.cs
 *
 *   Created: 2024-57-16T00:57:54-05:00
 *   Modified: 2024-58-16T00:58:20-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.TagHelpers.Extensions;

public static class InitExtensions
{
    public static T Init<T>(this T @this, TagHelperContext context)
        where T : TagHelper
    {
        @this.SetContexts(context);
        @this.SetContext(context);
        @this.FillMinimizableAttributes(context);
        if (@this is IHaveAnActionContextAccessor ihaaaca)
        {
            @this.ConvertUrls(ihaaaca.ActionContextAccessor);
        }
        return @this;
    }

    public static T Init<T>(this T @this, TagHelperContext context, IActionContextAccessor actionContextAccessor)
        where T : TagHelper
    {
        @this.SetContexts(context);
        @this.SetContext(context);
        @this.FillMinimizableAttributes(context);
        @this.ConvertUrls(actionContextAccessor);
        return @this;
    }
}
