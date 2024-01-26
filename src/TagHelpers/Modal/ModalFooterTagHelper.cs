namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.Modal
{
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using System.Threading.Tasks;

    [HtmlTargetElement("modal-footer", ParentTag = "modal")]
    [OutputElementHint("div")]
    public class ModalFooterTagHelper : TagHelper
    {
        #region --- Properties ---

        [HtmlAttributeNotBound]
        [Context]
        public ModalTagHelper ModalContext { get; set; }

        #endregion

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await output.LoadChildContentAsync();

            output.TagName = "div";
            output.AddCssClass("modal-footer");
        }
    }
}
