namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.Modal
{
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using System.Threading.Tasks;

    [HtmlTargetElement("modal-body", ParentTag = "modal")]
    public class ModalBodyTagHelper : TagHelper
    {
        [HtmlAttributeNotBound]
        [Context]
        public ModalTagHelper ModalContext { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await output.LoadChildContentAsync();

            output.TagName = "div";
            output.AddCssClass("modal-body");
        }
    }
}
