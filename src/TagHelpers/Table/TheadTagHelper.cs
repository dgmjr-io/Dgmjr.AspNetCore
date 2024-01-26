namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.Table
{
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [OutputElementHint("thead")]
    [HtmlTargetElement("thead", ParentTag = "table")]
    public class TheadTagHelper : TagHelper
    {
        #region --- Attribute Names ---

        private const string ThemeAttributeName = "theme";

        #endregion

        #region --- Properties ---

        [HtmlAttributeName(ThemeAttributeName)]
        public Theme Theme { get; set; } = Theme.Default;

        #endregion

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            // Theme
            output.AddCssClass(
                Theme != Theme.Default ? $"thead-{Theme.GetEnumInfo().Name}" : string.Empty
            );
        }
    }
}
