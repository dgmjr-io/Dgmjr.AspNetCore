namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.Breadcrumb
{
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [OutputElementHint("ol")]
    [RestrictChildren("breadcrumb-item")]
    public class BreadcrumbTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "ol";
            output.AddCssClass("breadcrumb");
        }
    }
}
