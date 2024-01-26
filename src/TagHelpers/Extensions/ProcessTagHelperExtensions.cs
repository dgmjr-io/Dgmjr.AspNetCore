/*
 * ProcessTagHelperExtensions.cs
 *
 *   Created: 2024-30-16T00:30:37-05:00
 *   Modified: 2024-30-16T00:30:37-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.TagHelpers.Extensions;

public static class ProcessTagHelperExtensions
{
    public static T Process<T>(this T @this, Action<TagHelperContext, TagHelperOutput> process, TagHelperContext context, TagHelperOutput output)
        where T : TagHelper
    {
        @this.CopyPropertiesToOutput(output);
        @this.CheckMandatoryProperties();
        @this.CopyIdentifier();
        process(context, output);
        if(@this is IIdentifiable<string> iis)
        {
            iis.RenderIdentifier(output);
        }
        @this.RemoveMinimizableAttributes(output);
        return @this;
    }
}
