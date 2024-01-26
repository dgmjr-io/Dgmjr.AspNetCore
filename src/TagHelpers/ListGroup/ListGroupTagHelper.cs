namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.ListGroup
{
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using System.Threading.Tasks;

    [ContextClass]
    [RestrictChildren("list-group-item", "list-group-link", "list-group-button")]
    public class ListGroupTagHelper : TagHelper
    {
        [HtmlAttributeNotBound]
        public bool IsLinkGroup { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await output.GetChildContentAsync();

            output.TagName = this.IsLinkGroup ? "div" : "ul";
            output.AddCssClass("list-group");
        }
    }
}
