/*
 * ColorsTagHelper.cs
 *
 *   Created: 2024-40-17T09:40:05-05:00
 *   Modified: 2024-22-18T12:22:17-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.TagHelpers;

[HtmlTargetElement(TagNames.Any, Attributes = ColorAttributeName)]
[HtmlTargetElement(TagNames.Any, Attributes = BackgroundColorAttributeName)]
[HtmlTargetElement(TagNames.Any, Attributes = BorderColorAttributeName)]
public class VariantTagHelper : TagHelper
{
    #region --- Attribute Names ---

    private const string ColorAttributeName = "bs-color";

    #endregion

    #region --- Properties ---

    [HtmlAttributeName(ColorAttributeName)]
    public Color Color { get; set; } = Color.None;

    #endregion
    #region --- Attribute Names ---

    private const string BackgroundColorAttributeName = "bs-bg-color";
    private const string BorderColorAttributeName = "bs-border-color";
    #endregion

    #region --- Properties ---


    /// <summary>The color of the background of the element</summary>
    [HtmlAttributeName(BackgroundColorAttributeName)]
    public Color BackgroundColor { get; set; } = Color.None;

    /// <summary>The color of the element's border</summary>
    [HtmlAttributeName(BorderColorAttributeName)]
    public Color BorderColor { get; set; } = Color.None;

    public static string ColorCssClass(TagHelperContext context) =>
        context.TagName switch
        {
            TagNames.Span => "badge",
            TagNames.Div => "alert",
            TagNames.Alert => "alert",
            TagNames.Anchor => "link",
            TagNames.Table => "table",
            TagNames.Button => "btn",
            TagNames.Input
                when context.AllAttributes.ContainsName("type")
                    && context.AllAttributes["type"].Value.ToString() is "button"
                => "btn",
            _ => string.Empty,
        };

    #endregion

    public override int Order => int.MaxValue;

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        await output.GetChildContentAsync();

        output.AddCssClass(ColorCssClass(context));
        output.AddCssClass($"{Color.GetColorInfo().TextCssClass}");

        output.AddCssClass($"{BackgroundColor.GetColorInfo().BackgroundCssClass}");
        output.AddCssClass($"{BackgroundColor.GetColorInfo().BorderCssClass}");
    }
}
