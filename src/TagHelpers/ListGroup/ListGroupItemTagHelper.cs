namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.ListGroup
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Razor.TagHelpers;

    [OutputElementHint("li")]
    [HtmlTargetElement("list-group-item", ParentTag = "list-group")]
    public class ListGroupItemTagHelper : TagHelper
    {
        #region --- Attribute Names ---

        private const string ColorAttributeName = "color";
        private const string BadgeAttributeName = "badge";
        private const string BadgeColorAttributeName = "badge-color";

        #endregion

        #region --- Properties ---

        [HtmlAttributeName(ColorAttributeName)]
        public Color Color { get; set; }

        [HtmlAttributeName(BadgeAttributeName)]
        public string Badge { get; set; }

        [HtmlAttributeName(BadgeColorAttributeName)]
        public Color BadgeColor { get; set; } = Color.None;

        #endregion

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "li";
            output.AddCssClass("list-group-item");

            // Color
            if (this.Color != Color.None)
            {
                output.AddCssClass($"list-group-item-{this.Color.GetColorInfo().Name}");
            }

            // Badge
            if (!IsNullOrEmpty(this.Badge))
            {
                output.AddCssClass("d-flex justify-content-between align-items-center");
                output.PostContent.AppendHtml(
                    $"<span class=\"{(this.BadgeColor != Color.None ? $"badge badge-{this.BadgeColor.GetColorInfo().Name} badge-pill" : "badge badge-dark badge-pill")}\">{this.Badge}</span>"
                );
            }
        }
    }
}
