namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.Table
{
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [OutputElementHint("td")]
    [HtmlTargetElement("td", ParentTag = "tr")]
    public class TdTagHelper : TagHelper
    {
        #region --- Attribute Names ---

        private const string BackgroundAttributeName = "background";

        #endregion

        #region --- Properties ---

        [HtmlAttributeName(BackgroundAttributeName)]
        public Color BackgroundColor { get; set; } = Color.None;

        #endregion

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            // Background
            if (BackgroundColor != Color.None)
            {
                output.AddCssClass($"table-{BackgroundColor.GetColorInfo().Name}");
            }
        }
    }
}
