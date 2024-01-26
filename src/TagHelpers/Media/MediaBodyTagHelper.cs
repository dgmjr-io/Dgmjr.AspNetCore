namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.Media
{
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [OutputElementHint("div")]
    [HtmlTargetElement("media-body", ParentTag = "media")]
    public class MediaBodyTagHelper : TagHelper
    {
        #region --- Attribute Names ---

        private const string HeaderAttributeName = "header";

        #endregion

        #region --- Properties ---

        [HtmlAttributeName(HeaderAttributeName)]
        public string Header { get; set; }

        #endregion

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.AddCssClass("media-body");

            // Header
            if (!IsNullOrEmpty(this.Header))
            {
                output.PreContent.AppendHtml($"<h5 class=\"mt-0\">{this.Header}</h5>");
            }
        }
    }
}
