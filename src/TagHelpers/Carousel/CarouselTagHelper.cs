namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.Carousel
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [OutputElementHint("div")]
    [RestrictChildren("carousel-item")]
    [ContextClass]
    [GenerateId("carousel-")]
    public class CarouselTagHelper : TagHelper
    {
        #region --- Attribute Names ---

        private const string ControlsAttributeName = "controls";
        private const string IndicatorsAttributeName = "indicators";
        private const string FadeAttributeName = "fade";

        #endregion

        #region --- Properties ---

        [HtmlAttributeName(ControlsAttributeName)]
        public bool HasControls { get; set; }

        [HtmlAttributeName(IndicatorsAttributeName)]
        public bool HasIndicators { get; set; }

        [HtmlAttributeName(FadeAttributeName)]
        public bool IsFade { get; set; }

        [HtmlAttributeNotBound]
        public List<CarouselItemTagHelper> Items { get; } = new List<CarouselItemTagHelper>();

        [HtmlAttributeNotBound]
        public string Id { get; set; } = guid.NewGuid().ToString("N")[..8];

        #endregion

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.AddCssClass("carousel slide");
            output.AddDataAttribute("ride", "carousel");

            // Fade
            if (this.IsFade)
            {
                output.AddCssClass("carousel-fade");
            }

            // Items
            output.Content.SetHtmlContent(await output.GetChildContentAsync());

            // Indicators
            if (this.HasIndicators)
            {
                output.PreContent.AppendHtml("<ol class=\"carousel-indicators\">");
                for (int i = 0; i < this.Items.Count; i++)
                {
                    output.PreContent.AppendHtml(
                        this.Items[i].Active
                            ? $"<li data-target=\"#{this.Id}\" data-slide-to=\"{i}\" class=\"active\"></li>"
                            : $"<li data-target=\"#{this.Id}\" data-slide-to=\"{i}\"></li>"
                    );
                }
                output.PreContent.AppendHtml("</ol>");
            }

            // Item wrapper
            output.Content.Wrap(
                new TagBuilder("div") { Attributes = { { "class", "carousel-inner" } } }
            );

            // Controls
            if (this.HasControls)
            {
                output.PostContent.AppendHtml(
                    $"<a class=\"carousel-control-prev\" href=\"#{this.Id}\" role=\"button\" data-slide=\"prev\"><span class=\"carousel-control-prev-icon\" aria-hidden=\"true\"></span><span class=\"sr-only\">Previous</span></a><a class=\"carousel-control-next\" href=\"#{Id}\" role=\"button\" data-slide=\"next\"><span class=\"carousel-control-next-icon\" aria-hidden=\"true\"></span><span class=\"sr-only\">Next</span></a>"
                );
            }
        }
    }
}
