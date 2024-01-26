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
}
