namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.Card
{
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [HtmlTargetElement("card-header", ParentTag = "card")]
    [OutputElementHint("div")]
    public class CardHeaderTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.AddCssClass("card-header");
        }
    }
}
