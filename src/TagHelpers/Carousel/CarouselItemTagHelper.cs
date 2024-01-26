namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.Carousel
{
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using System.Threading.Tasks;

    [HtmlTargetElement("carousel-item", ParentTag = "carousel")]
    [OutputElementHint("div")]
    public class CarouselItemTagHelper(IActionContextAccessor actionContextAccessor)
        : TagHelper,
            IHaveAnActionContextAccessor
    {
        public IActionContextAccessor ActionContextAccessor => actionContextAccessor;

    #region --- Attribute Names ---

    private const string ActiveAttributeName = "active";
    private const string SrcAttributeName = "src";
    private const string AltAttributeName = "alt";

    #endregion

    #region --- Properties ---

    [HtmlAttributeName(SrcAttributeName)]
    [ConvertVirtualUrl]
    public string Src { get; set; }

    [HtmlAttributeName(AltAttributeName)]
    public string Alt { get; set; }

    [HtmlAttributeName(ActiveAttributeName)]
    public bool Active { get; set; }

    [Context]
    protected CarouselTagHelper CarouselContext { get; set; }

    #endregion

    public override void Init(TagHelperContext context)
    {
        base.Init(context);
        CarouselContext.Items.Add(this);
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.AddCssClass("carousel-item");

        // Active
        if (this.Active)
        {
            output.AddCssClass("active");
        }

        output.PreContent.PrependHtml(
            $"<img class=\"d-block w-100\" src=\"{this.Src}\" alt=\"{this.Alt}\" />"
        );
        output.Content.SetHtmlContent(await output.GetChildContentAsync());

        // Caption
        if (!output.Content.IsEmptyOrWhiteSpace)
        {
            output.PreContent.AppendHtml("<div class=\"carousel-caption d-none d-md-block\">");
            output.PostContent.PrependHtml("</div>");
        }
    }
}
}
