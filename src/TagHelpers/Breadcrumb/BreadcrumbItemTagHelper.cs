namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.Breadcrumb
{
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [HtmlTargetElement("breadcrumb-item", ParentTag = "breadcrumb")]
    [OutputElementHint("li")]
    public class BreadcrumbItemTagHelper : TagHelper
    {
        #region --- Attribute Names ---

        private const string HrefAttributeName = "href";
        private const string ActiveAttributeName = "active";

        #endregion

        #region --- Properties ---

        [HtmlAttributeName(HrefAttributeName)]
        public string Href { get; set; }

        [HtmlAttributeName(ActiveAttributeName)]
        public bool Active { get; set; }

        #endregion

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "li";
            output.AddCssClass("breadcrumb-item");

            if (Active)
            {
                output.AddCssClass("active");
            }
            else if (!IsNullOrEmpty(Href))
            {
                output.PreContent.SetHtmlContent($"<a href=\"{Href}\">");
                output.PostContent.SetHtmlContent("</a>");
            }
        }
    }
}
