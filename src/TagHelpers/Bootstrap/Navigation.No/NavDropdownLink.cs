/*
 * DropdownLink.cs
 *
 *   Created: 2024-09-17T12:09:28-05:00
 *   Modified: 2024-09-17T12:09:28-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace No.Dgmjr.AspNetCore.TagHelpers.Bootstrap;

[HtmlTargetElement(TagNames.NavDropdownLink)]
public class NavDropdownLink(IHtmlGenerator generator) : AnchorTagHelper(generator)
{
    #region --- Attribute Names ---

    private const string TitleAttributeName = "title";

    #endregion

    #region --- Properties ---

    [HtmlAttributeName(TitleAttributeName)]
    public string Title { get; set; }

    #endregion

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var childContent = await output.GetChildContentAsync();

        output.TagName = TagNames.Anchor;
        output.AddCssClass("dropdown-item");
    }
}
