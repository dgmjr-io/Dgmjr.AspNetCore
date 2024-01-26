namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.Card
{
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [HtmlTargetElement("card-image", ParentTag = "card")]
    [OutputElementHint("img")]
    public class CardImageTagHelper(IActionContextAccessor actionContextAccessor)
        : TagHelper,
            IHaveAnActionContextAccessor
    {
        public IActionContextAccessor ActionContextAccessor => actionContextAccessor;

    #region --- Attribute Names ---

    private const string PositionAttributeName = "position";

    #endregion

    #region --- Properties ---

    // [HtmlAttributeName(PositionAttributeName)]
    public CardImagePosition Position { get; set; } = CardImagePosition.Top;

    [CopyToOutput]
    [ConvertVirtualUrl]
    public string Src { get; set; }

    #endregion

    public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "img";
        output.TagMode = TagMode.SelfClosing;

        // Position
        output.AddCssClass($"card-img-{this.Position.GetEnumInfo().Name}");
    }
}
}
