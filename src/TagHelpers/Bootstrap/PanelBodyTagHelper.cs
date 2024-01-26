namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap
{
    /// <summary>
    /// Panel Body Tag Helper
    /// </summary>
    [HtmlTargetElement("panel-body", ParentTag = "panel")]
    public class PanelBodyTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            var modalContext = (PanelContext)context.Items[typeof(PanelTagHelper)];
            modalContext.Body = childContent;
            output.SuppressOutput();
        }
    }
}
