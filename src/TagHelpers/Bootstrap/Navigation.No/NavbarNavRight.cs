/*
 * NavbarNavRight.cs
 *
 *   Created: 2024-22-16T14:22:32-05:00
 *   Modified: 2024-22-16T14:22:32-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace No.Dgmjr.AspNetCore.TagHelpers.Bootstrap;

[HtmlTargetElement(TagNames.NavbarNav)]
// [RestrictChildren(TagNames.NavLink, TagNames.NavText, TagNames.NavDropDown, TagNames.NavItem)]
[ContextClass]
public class NavbarNavRightTagHelper(IActionContextAccessor actionContextAccessor)
    : NavbarNavTagHelper(actionContextAccessor)
{
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
{
    await base.ProcessAsync(context, output);
    output.AddCssClass(CssClasses.Nav);
    output.AddCssClass(CssClasses.NavbarNav);
    output.AddCssClass(CssClasses.NavRight);
}
}
