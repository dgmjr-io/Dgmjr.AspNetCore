namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.Modal
{
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [HtmlTargetElement("button", Attributes = ModalTargetAttributeName)]
    public class ModalToggleTagHelper : TagHelper
    {
        #region --- Attribute Names ---

        private const string ModalTargetAttributeName = "modal-target";

        #endregion

        #region --- Properties ---

        [HtmlAttributeName(ModalTargetAttributeName)]
        public string ModalTarget { get; set; }

        #endregion

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.Add("data-target", "#" + this.ModalTarget);
            output.Attributes.Add("data-toggle", "modal");
        }
    }
}
