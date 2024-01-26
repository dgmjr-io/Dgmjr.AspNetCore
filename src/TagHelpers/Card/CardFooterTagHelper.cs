namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.Card
{
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [HtmlTargetElement("card-footer", ParentTag = "card")]
    [OutputElementHint("div")]
    public class CardFooterTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.AddCssClass("card-footer");
        }
    }
}
