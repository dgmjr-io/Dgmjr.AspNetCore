namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.Components
{
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [HtmlTargetElement("img")]
    [OutputElementHint("img")]
    public class ImageTagHelper : TagHelper
    {
        #region --- Attribute Names ---

        private const string ThumbnailAttributeName = "thumbnail";
        private const string ResponsiveAttributeName = "responsive";
        private const string RoundAttributeName = "round";
        private const string CircleAttributeName = "circle";

        #endregion

        #region --- Properties ---

        [HtmlAttributeName(ThumbnailAttributeName)]
        public bool Thumbnail { get; set; }

        [HtmlAttributeName(ResponsiveAttributeName)]
        public bool Responsive { get; set; }

        [HtmlAttributeName(RoundAttributeName)]
        public bool Round { get; set; }

        [HtmlAttributeName(CircleAttributeName)]
        public bool Circle { get; set; }

        #endregion

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            // Thumbnail
            if (this.Thumbnail)
            {
                output.AddCssClass("img-thumbnail");
            }

            // Round
            if (this.Round)
            {
                output.AddCssClass("rounded");
            }

            // Circle
            if (this.Circle)
            {
                output.AddCssClass("rounded-circle");
            }

            // Responsive
            if (this.Responsive)
            {
                output.AddCssClass("img-fluid");
            }
        }
    }
}
