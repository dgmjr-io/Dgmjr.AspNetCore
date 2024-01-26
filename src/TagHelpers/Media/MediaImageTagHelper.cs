namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.Media
{
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [OutputElementHint("img")]
    [HtmlTargetElement("media-image", ParentTag = "media")]
    public class MediaImageTagHelper(IActionContextAccessor actionContextAccessor)
        : TagHelper,
            IHaveAnActionContextAccessor
    {
        #region --- Attribute Names ---

        private const string VerticalAlignmentAttributeName = "vertical-alignment";

    #endregion

    #region --- Properties ---

    [CopyToOutput]
    [ConvertVirtualUrl]
    public string Src { get; set; }

    [HtmlAttributeName(VerticalAlignmentAttributeName)]
    public VerticalAlignment VerticalAlignment { get; set; } = VerticalAlignment.Default;

    [ActionContext]
    public IActionContextAccessor ActionContextAccessor => actionContextAccessor;

    #endregion

    public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "img";
        output.TagMode = TagMode.SelfClosing;

        output.AddCssClass("d-flex");

        // Vertical Alignment
        switch (this.VerticalAlignment)
        {
            case VerticalAlignment.Top:
                output.AddCssClass("align-self-start");
                break;
            case VerticalAlignment.Middle:
                output.AddCssClass("align-self-center");
                break;
            case VerticalAlignment.Bottom:
                output.AddCssClass("align-self-end");
                break;
        }
    }
}
}
