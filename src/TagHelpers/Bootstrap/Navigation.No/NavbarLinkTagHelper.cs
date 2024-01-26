using Microsoft.Extensions.DependencyInjection;

namespace No.Dgmjr.AspNetCore.TagHelpers.Bootstrap;

[OutputElementHint("a")]
[HtmlTargetElement(
    TagNames.NavbarLink /*, ParentTag = TagNames.NavbarNav)]
[HtmlTargetElement(TagNames.NavLink, ParentTag = TagNames.NavDropDown)]
[HtmlTargetElement(TagNames.NavLink, ParentTag = TagNames.NavForm*/
)]
public class NavbarLinkTagHelper(IHtmlGenerator generator) : AnchorTagHelper(generator)
{
    #region --- Attribute Names ---

private const string ActiveAttributeName = "active";
private const string DisableAttributeName = "disable";

#endregion

#region --- Properties ---

private bool? _active;

[HtmlAttributeName(ActiveAttributeName)]
public bool Active
{
    get => _active ?? ShouldBeActive();
    set => _active = value;
}

[HtmlAttributeName(DisableAttributeName)]
public bool IsDisabled { get; set; }

// [HtmlAttributeName("href")]
// public string Href { get; set; } = string.Empty;

// [HtmlAttributeName("asp-action")]
// public string Action { get; set; } = string.Empty;

// [HtmlAttributeName("asp-controller")]
// public string Controller { get; set; } = string.Empty;

// [HtmlAttributeName("asp-area")]
// public string Area { get; set; } = string.Empty;

// [HtmlAttributeName("asp-route-")]
// public IStringDictionary RouteValues { get; set; } = new StringDictionary();
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
#endregion

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
    output.TagName = "a";
    output.AddCssClass(
        !context.HasContextItem<NavbarDropdownTagHelper>() ? "nav-link" : "dropdown-item"
    );

    // Href
    if (!IsNullOrEmpty(Route))
    {
        output.Attributes.Add(AttributeNames.Href, Route);
    }
    else
    {
        var url = UrlHelper.ActionLink(Action, Controller, new { area = Area });
        output.Attributes.Add(AttributeNames.Href, url);
    }

    // Disabled
    if (IsDisabled)
    {
        output.AddCssClass("disabled");
    }

    // Active
    if (Active && context.HasContextItem<NavbarDropdownTagHelper>())
    {
        output.AddCssClass("active");
        output.PostContent.AppendHtml(
            $"<span class=\"sr-only visually-hidden\">(current)</span>"
        );
    }
    else if (Active && !context.HasContextItem<NavbarDropdownTagHelper>())
    {
        output.PostContent.AppendHtml(
            $"<span class=\"sr-only visually-hidden\">(current)</span>"
        );
        output.WrapHtmlOutside($"<li class=\"nav-item active\">", "</li>");
    }
    else if (!context.HasContextItem<NavbarDropdownTagHelper>())
    {
        output.WrapHtmlOutside($"<li class=\"nav-item\">", "</li>");
    }
}

// private bool IsActive()
// {
//     var path = ViewContext.HttpContext.Request.Path;
//     var href = Href;

//     if (href == "/")
//     {
//         return path == href;
//     }

//     return path.StartsWithSegments(href);
// }
}
