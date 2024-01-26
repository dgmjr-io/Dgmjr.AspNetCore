namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.Components
{
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    [OutputElementHint("div")]
    public class AlertTagHelper : TagHelper
    {
        #region --- Attribute Names ---

        private const string ColorAttributeName = "color";
        private const string DismissibleAttributeName = "dismissible";
        private const string DisableLinkStylingAttributeName = "disable-link-styling";
        private const string TitleAttributeName = "title";

        #endregion

        #region --- Properties ---

        [HtmlAttributeName(ColorAttributeName)]
        public Color Color { get; set; } = Color.Primary;

        [HtmlAttributeName(DismissibleAttributeName)]
        public bool Dismissible { get; set; }

        [HtmlAttributeName(DisableLinkStylingAttributeName)]
        public bool DisableLinkStyling { get; set; }

        [HtmlAttributeName(TitleAttributeName)]
        public string Title { get; set; }

        #endregion

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.AddCssClass("alert");
            output.MergeAttribute("role", "alert");

            // Color
            if (this.Color != Color.None)
            {
                output.AddCssClass($"alert-{this.Color.GetColorInfo().Name}");
            }

            // Title
            if (!IsNullOrEmpty(this.Title))
            {
                output.PreContent.AppendHtml($"<h4 class=\"alert-heading\">{this.Title}</h4> ");
            }

            // Dismissible
            if (this.Dismissible)
            {
                output.AddCssClass("alert-dismissible");
                output.PreContent.SetHtmlContent(
                    $"<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\"><span aria-hidden=\"true\">&times;</span></button>"
                );
            }

            // Disable Link Styling
            if (!DisableLinkStyling)
            {
                var content = await output.GetChildContentAsync(true);
                output.Content.SetHtmlContent(
                    Regex.Replace(content.GetContent(), "<a( [^>]+)?>", this.AddLinkStyle)
                );
            }
        }

        private string AddLinkStyle(Match match)
        {
            if (match.ToString().Contains("class=\""))
            {
                return match.ToString().Replace("class=\"", "class=\"alert-link ");
            }

            return "<a class=\"alert-link\"" + match.ToString().Substring(2);
        }
    }
}
