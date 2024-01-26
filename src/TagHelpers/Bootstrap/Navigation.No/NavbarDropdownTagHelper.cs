/*
 * NavbarDropdownTagHelper.cs
 *
 *   Created: 2024-45-15T17:45:43-05:00
 *   Modified: 2024-45-15T17:45:45-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace No.Dgmjr.AspNetCore.TagHelpers.Bootstrap;

[HtmlTargetElement(TagNames.NavDropDown, ParentTag = TagNames.Navbar)]
[HtmlTargetElement(TagNames.NavDropDown, ParentTag = TagNames.NavbarNav)]
// [RestrictChildren(TagNames.NavLink)]
[GenerateId("navbar-dropdown-", false)]
[ContextClass]
public class NavbarDropdownTagHelper() : DgmjrTagHelperBase(TagNames.Li)
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
        await output.GetChildContentAsync();

        output.TagName = "li";
        output.AddCssClass("nav-item dropdown");

        // Dropdown Button
        output.PreContent.AppendHtml(
            $"<button href=\"#\" class=\"nav-link dropdown-toggle\" id=\"{this.Id}\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\">{this.Title}</button>"
        );

        // Dropdown Items
        output.PreContent.AppendHtml(
            $"<div class=\"dropdown-menu\" aria-labelledby=\"{this.Id}\">"
        );
        output.PostContent.AppendHtml("</div>");
    }
}
