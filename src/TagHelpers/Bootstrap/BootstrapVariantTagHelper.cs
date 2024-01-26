/*
 * BootstrapVariantTagHelper.cs
 *
 *   Created: 2024-58-15T22:58:22-05:00
 *   Modified: 2024-58-15T22:58:22-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap;

[HtmlTargetElement("*", Attributes = AttributeNames.Variant)]
public class BootstrapVariantTagHelper : TagHelper
{
    [HtmlAttributeName(AttributeNames.Variant)]
    public virtual Color Variant { get; set; } = Color.Primary;

    [HtmlAttributeName(AttributeNames.Class)]
    public virtual string CssClass { get; set; } = string.Empty;

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.Attributes.SetAttribute("class", $"{CssClass} {Variant.ToString().ToLower()}");
    }
}
