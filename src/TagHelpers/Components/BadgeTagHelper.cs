namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.Components
{
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [OutputElementHint("span")]
    public class BadgeTagHelper : TagHelper
    {
        #region --- Attribute Names ---

        private const string ColorAttributeName = "color";
        private const string PillAttributeName = "pill";

        #endregion

        #region --- Properties ---

        [HtmlAttributeName(ColorAttributeName)]
        public Color Color { get; set; } = Color.Secondary;

        [HtmlAttributeName(PillAttributeName)]
        public bool IsPill { get; set; }

        #endregion

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";
            output.AddCssClass("badge");

            // Color
            if (Color != Color.None)
            {
                output.AddCssClass($"badge-{Color.GetColorInfo().Name}");
            }

            // Pill
            if (IsPill)
            {
                output.AddCssClass("badge-pill");
            }
        }
    }
}
