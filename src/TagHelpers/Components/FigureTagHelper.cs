namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.Components
{
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [OutputElementHint("figure")]
    [HtmlTargetElement("figure", TagStructure = TagStructure.WithoutEndTag)]
    public class FigureTagHelper(IActionContextAccessor actionContextAccessor)
        : TagHelper,
            IHaveAnActionContextAccessor
    {
        public IActionContextAccessor ActionContextAccessor => actionContextAccessor;

        #region --- Attribute Names ---

        private const string ImageAttributeName = "image";
        private const string WidthAttributeName = "width";
        private const string HeightAttributeName = "height";
        private const string CaptionAttributeName = "caption";
        private const string HorizontalAligmentAttributeName = "alignment";

        #endregion

        #region --- Properties ---

        [HtmlAttributeName(ImageAttributeName)]
        [ConvertVirtualUrl]
        public string Image { get; set; }

        [HtmlAttributeName(CaptionAttributeName)]
        public string Caption { get; set; }

        [HtmlAttributeName(HorizontalAligmentAttributeName)]
        public HorizontalAlignment HorizontalAlignment { get; set; }

        [HtmlAttributeName(WidthAttributeName)]
        public int Width { get; set; }

        [HtmlAttributeName(HeightAttributeName)]
        public int Height { get; set; }

        #endregion

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "figure";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.AddCssClass("figure");

            // Image
            TagBuilder img = new TagBuilder("img") { TagRenderMode = TagRenderMode.SelfClosing };
            img.AddCssClass("figure-img img-fluid rounded");
            img.Attributes.Add("src", this.Image);
            if (this.Width > 0)
                img.Attributes.Add("width", this.Width.ToString());
            if (this.Height > 0)
                img.Attributes.Add("height", this.Height.ToString());
            output.PreContent.AppendHtml(img);

            // Caption
            TagBuilder figcaption = new TagBuilder("figcaption");
            figcaption.AddCssClass("figure-caption");
            figcaption.InnerHtml.Append(this.Caption);

            // Alignment
            if (this.HorizontalAlignment != HorizontalAlignment.Default)
            {
                figcaption.AddCssClass($"text-{this.HorizontalAlignment.GetEnumInfo().Name}");
            }

            output.PostContent.AppendHtml(figcaption);
        }
    }
}
