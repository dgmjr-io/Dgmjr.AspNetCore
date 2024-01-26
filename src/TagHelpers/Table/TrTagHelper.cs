namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.Table
{
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [OutputElementHint("tr")]
    [HtmlTargetElement("tr", ParentTag = "tbody")]
    public class TrTagHelper : TagHelper
    {
        #region --- Attribute Names ---

        private const string BackgroundAttributeName = "background";

        #endregion

        #region --- Properties ---

        [HtmlAttributeName(BackgroundAttributeName)]
        public Color Background { get; set; } = Color.None;

        #endregion

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            // Background
            if (Background != Color.None)
            {
                output.AddCssClass($"table-{Background.GetColorInfo().Name}");
            }
        }
    }
}
