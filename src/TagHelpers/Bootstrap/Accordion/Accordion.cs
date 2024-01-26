/*
 * Accordion.cs
 *
 *   Created: 2024-08-20T01:08:23-05:00
 *   Modified: 2024-08-20T01:08:23-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.Accordion;

public class Accordion : TagHelper
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = TagNames.Div;
        output.AddCssClass(CssClasses.Accordion);
        if (Color != Color.None)
        {
            output.AddCssClass($"{CssClasses.TextBackground_}{Color.ToString().ToLower()}");
        }
        if (BorderColor != Color.None)
        {
            output.AddCssClass($"{CssClasses.Border_}{BorderColor.ToString().ToLower()}");
        }
        output.Attributes.Add("id", Id);
    }

    [HtmlAttributeName(AttributeNames.Color)]
    public Color Color { get; set; } = Color.None;

    [HtmlAttributeName(AttributeNames.BorderColor)]
    public Color BorderColor { get; set; } = Color.None;

    [HtmlAttributeName("id")]
    public string Id { get; set; } = guid.NewGuid().ToString();
}
