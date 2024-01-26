namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.Table
{
    using Microsoft.AspNetCore.Razor.TagHelpers;

    public class TableTagHelper : TagHelper
    {
        #region --- Attribute Names ---

        private const string StripedAttributeName = "striped";
        private const string SmallAttributeName = "small";
        private const string BorderAttributeName = "border";
        private const string HoverAttributeName = "hover";
        private const string ThemeAttributeName = "theme";
        private const string ResponsiveAttributeName = "responsive";

        #endregion

        #region --- Properties ---

        [HtmlAttributeName(StripedAttributeName)]
        public bool IsStriped { get; set; }

        [HtmlAttributeName(SmallAttributeName)]
        public bool IsSmall { get; set; }

        // [HtmlAttributeName(BorderAttributeName)]
        // public TableBorder Border { get; set; } = TableBorder.Regular;

        [HtmlAttributeName(HoverAttributeName)]
        public bool IsHover { get; set; }

        [HtmlAttributeName(ThemeAttributeName)]
        public Theme Theme { get; set; }

        // [HtmlAttributeName(ResponsiveAttributeName)]
        // public Breakpoint? Responsive { get; set; }

        #endregion

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.AddCssClass("table");

            // Theme
            output.AddCssClass(
                Theme != Theme.Default ? $"table-{Theme.GetEnumInfo().Name}" : string.Empty
            );

            // Striped
            if (IsStriped)
            {
                output.AddCssClass("table-striped");
            }

            // Small
            if (IsSmall)
            {
                output.AddCssClass("table-sm");
            }

            // // Border
            // switch (Border)
            // {
            //     case TableBorder.Bordered:
            //         output.AddCssClass("table-bordered");
            //         break;
            //     case TableBorder.Borderless:
            //         output.AddCssClass("table-borderless");
            //         break;
            // }

            // Hover
            if (IsHover)
            {
                output.AddCssClass("table-hover");
            }

            // Responsive
            // if (Responsive.HasValue)
            // {
            //     output.WrapHtmlOutside(
            //         $"<div class=\"{(Responsive.Value == Breakpoint.XSmall ? "table-responsive" : $"table-responsive-{Responsive.GetEnumInfo().Name}")}\">",
            //         "</div>"
            //     );
            // }
        }
    }
}
