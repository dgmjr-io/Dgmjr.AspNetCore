namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.Components
{
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class JumbotronTagHelper : TagHelper
    {
        #region --- Attribute Names ---

        private const string FluidAttributeName = "fluid";

        #endregion

        #region --- Properties ---

        [HtmlAttributeName(FluidAttributeName)]
        public bool IsFluid { get; set; }

        #endregion

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.AddCssClass("jumbotron");

            // Full Width
            if (this.IsFluid)
            {
                output.AddCssClass("jumbotron-fluid");

                output.PreContent.SetHtmlContent(@"<div class=""container"">");
                output.PostContent.SetHtmlContent(@"</div>");
            }
        }
    }
}
