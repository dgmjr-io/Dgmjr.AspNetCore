namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.Modal
{
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [HtmlTargetElement("h1", ParentTag = "modal-header")]
    [HtmlTargetElement("h2", ParentTag = "modal-header")]
    [HtmlTargetElement("h3", ParentTag = "modal-header")]
    [HtmlTargetElement("h4", ParentTag = "modal-header")]
    [HtmlTargetElement("h5", ParentTag = "modal-header")]
    [HtmlTargetElement("h6", ParentTag = "modal-header")]
    public class ModalTitleTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.AddCssClass("modal-title");
        }
    }
}
