/*
 * NavbarDropdownDivider.cs
 *
 *   Created: 2024-08-17T16:08:29-05:00
 *   Modified: 2024-08-17T16:08:29-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace No.Dgmjr.AspNetCore.TagHelpers.Bootstrap;

public class NavbarDropdownDividerTagHelper() : DgmjrTagHelperBase(TagNames.Divider)
{
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        await base.ProcessAsync(context, output);
        output.TagName = TagNames.Divider;
        output.AddCssClass(CssClasses.DropdownDivider);
        output.WrapOutside($"<{TagNames.Li}>", $"</{TagNames.Li}>");
    }
};
