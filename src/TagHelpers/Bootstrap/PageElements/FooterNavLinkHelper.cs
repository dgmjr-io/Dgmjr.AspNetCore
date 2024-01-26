/*
 * FooterNavLinkHelper.cs
 *
 *   Created: 2024-46-16T16:46:00-05:00
 *   Modified: 2024-46-16T16:46:22-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System.Threading.Tasks;

namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap;

[HtmlTargetElement(TagNames.NavLink, ParentTag = TagNames.Footer)]
// [HtmlTargetElement(TagNames.NavLink, ParentTag = TagNames.Container)]
public class FooterNavLinkTagHelper(IHtmlGenerator generator) : AnchorTagHelper(generator)
{
    public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        base.ProcessAsync(context, output);
        output.TagName = "a";

        if (ShouldBeActive())
        {
            MakeActive(output);
        }
        return Task.CompletedTask;
    }

    private bool ShouldBeActive()
    {
        var currentController = ViewContext.RouteData.Values["Controller"]?.ToString();
        var currentAction = ViewContext.RouteData.Values["Action"]?.ToString();

        if (
            !IsNullOrWhiteSpace(Controller) && Controller?.ToLower() != currentController?.ToLower()
        )
        {
            return false;
        }

        if (!IsNullOrWhiteSpace(Action) && Action?.ToLower() != currentAction?.ToLower())
        {
            return false;
        }

        foreach (var routeValue in RouteValues)
        {
            if (
                !ViewContext.RouteData.Values.ContainsKey(routeValue.Key)
                || ViewContext.RouteData.Values[routeValue.Key].ToString() != routeValue.Value
            )
            {
                return false;
            }
        }

        return true;
    }

    private static void MakeActive(TagHelperOutput output)
    {
        output.AddCssClass("active");
    }
}
