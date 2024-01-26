namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.Card
{
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [HtmlTargetElement("card-body", ParentTag = "card")]
    [OutputElementHint("div")]
    public class CardBodyTagHelper : TagHelper
    {
        #region --- Attribute Names ---

        private const string TitleAttributeName = "title";
        private const string SubtitleAttributeName = "subtitle";
        private const string ColorAttributeName = "color";

        #endregion

        #region --- Properties ---

        [HtmlAttributeName(TitleAttributeName)]
        public string Title { get; set; }

        [HtmlAttributeName(SubtitleAttributeName)]
        public string Subtitle { get; set; }

        [HtmlAttributeName(ColorAttributeName)]
        public Color Color { get; set; } = Color.None;

        #endregion

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.AddCssClass("card-body");

            // Title
            if (!IsNullOrEmpty(this.Title))
            {
                output.PreContent.AppendHtml($"<h4 class=\"card-title\">{this.Title}</h4>");
            }

            // Subtitle
            if (!IsNullOrEmpty(this.Subtitle))
            {
                output.PreContent.AppendHtml(
                    $"<h6 class=\"card-subtitle mb-2 text-muted\">{this.Subtitle}</h6>"
                );
            }

            // Color
            if (this.Color != Color.None)
            {
                output.AddCssClass(this.Color.GetColorInfo().TextCssClass);
            }
        }
    }
}
