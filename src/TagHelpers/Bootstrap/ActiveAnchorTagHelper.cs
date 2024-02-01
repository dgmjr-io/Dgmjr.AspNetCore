namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap;

[HtmlTargetElement(TagNames.Anchor)]
[HtmlTargetElement(TagNames.Anchor, Attributes = "asp-action")]
[HtmlTargetElement(TagNames.Anchor, Attributes = "asp-controller")]
[HtmlTargetElement(TagNames.Anchor, Attributes = "asp-area")]
[HtmlTargetElement(TagNames.Anchor, Attributes = "asp-page")]
[HtmlTargetElement(TagNames.Anchor, Attributes = "asp-page-handler")]
[HtmlTargetElement(TagNames.Anchor, Attributes = "asp-fragment")]
[HtmlTargetElement(TagNames.Anchor, Attributes = "asp-host")]
[HtmlTargetElement(TagNames.Anchor, Attributes = "asp-protocol")]
[HtmlTargetElement(TagNames.Anchor, Attributes = "asp-route")]
[HtmlTargetElement(TagNames.Anchor, Attributes = "asp-all-route-data")]
[HtmlTargetElement(TagNames.Anchor, Attributes = "asp-route-*")]
public class ActiveAnchorTagHelper(IHtmlGenerator generator)
    : Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper(generator)
{
    private bool? _isActive;
    public bool IsActive
    {
        get => _isActive ?? ShouldBeActive();
        set => _isActive = value;
    }

    public override int Order => int.MaxValue;

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        // base.Process(context, output);

        if (IsActive)
        {
            var activeClass = output.Attributes.FirstOrDefault(a => a.Name == "class");
            if (activeClass != null)
            {
                output.Attributes.SetAttribute(
                    AttributeNames.Class,
                    activeClass.Value + " " + CssClasses.Active
                );
            }
            else
            {
                output.Attributes.SetAttribute(AttributeNames.Class, CssClasses.Active);
            }
        }
    }

    private bool ShouldBeActive()
    {
        // Get the current page's area
        var currentArea = ViewContext.RouteData.Values["area"]?.ToString();

        // Get the current page's controller
        var currentController = ViewContext.RouteData.Values["controller"]?.ToString();

        // Get the current page's page name
        var currentPage = ViewContext.RouteData.Values["page"]?.ToString();

        // Get the current page's action
        var currentAction = ViewContext.RouteData.Values["action"]?.ToString();

        // Get the anchor's area
        var anchorArea = Area;

        // Get the anchor's controller
        var anchorController = Controller;

        // Get the anchor's page name
        var anchorPage = Page;

        // Get the anchor's action
        var anchorAction = Action;

        // Compare the current page's area, controller, page name, and action to the anchor's properties
        // If they all match, return true
        if (
            string.Equals(currentArea, anchorArea, OrdinalIgnoreCase)
            && string.Equals(currentController, anchorController, OrdinalIgnoreCase)
            && string.Equals(currentPage, anchorPage, OrdinalIgnoreCase)
            && string.Equals(currentAction, anchorAction, OrdinalIgnoreCase)
        )
        {
            return true;
        }

        if(anchorPage != null && currentPage?.StartsWith(anchorPage, OrdinalIgnoreCase) == true)
        {
            return true;
        }

        // If any of the above comparisons fail, return false
        return false;
    }
}
