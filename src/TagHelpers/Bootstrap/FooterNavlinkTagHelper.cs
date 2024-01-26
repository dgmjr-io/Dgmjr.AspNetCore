/*
 * FooterNavlinkTagHelper.cs
 *
 *   Created: 2024-16-17T22:16:59-05:00
 *   Modified: 2024-17-17T22:17:00-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using Microsoft.Extensions.DependencyInjection;

namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap;

[HtmlTargetElement(TagNames.NavLink)]
public class NavLinkTagHelper(IHtmlGenerator generator) : AnchorTagHelper(generator)
{
    protected IServiceProvider Services => ViewContext.HttpContext.RequestServices;

    private IUrlHelper _urlHelper;

    [HtmlAttributeNotBound]
    public IUrlHelper UrlHelper
    {
        get =>
            _urlHelper ??= Services
                .GetRequiredService<IUrlHelperFactory>()
                .GetUrlHelper(ViewContext);
        set => _urlHelper = value;
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

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        if (ShouldBeActive())
        {
            output.AddCssClass(CssClasses.Active);
        }
    }
}
