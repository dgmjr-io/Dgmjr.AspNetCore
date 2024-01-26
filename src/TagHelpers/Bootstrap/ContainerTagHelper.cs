/*
 * ContainerTagHelper.cs
 *
 *   Created: 2024-43-16T16:43:35-05:00
 *   Modified: 2024-43-16T16:43:35-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap;

[HtmlTargetElement(TagNames.Container)]
public class ContainerTagHelper : TagHelper
{
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = TagNames.Div;
        var childContent = await output.GetChildContentAsync();
        output.Content.AppendHtml(childContent);
        output.AddCssClass(TagNames.Container);
    }
}
