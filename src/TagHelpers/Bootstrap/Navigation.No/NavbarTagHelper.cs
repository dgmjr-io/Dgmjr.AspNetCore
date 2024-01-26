namespace No.Dgmjr.AspNetCore.TagHelpers.Bootstrap;

using Dgmjr.AspNetCore.TagHelpers.Enumerations;
using Dgmjr.AspNetCore.TagHelpers.Extensions;

[OutputElementHint(TagNames.Nav)]
// [RestrictChildren(TagNames.NavbarNav, TagNames.NavForm, TagNames.NavText, TagNames.NavItem)]
// // [GenerateId("navbar-", false)]
// [HtmlTargetElement(TagNames.Navbar, Attributes = BrandTextAttributeName)]
// [HtmlTargetElement(TagNames.Navbar, Attributes = BrandImageAttributeName)]
// [HtmlTargetElement(TagNames.Navbar, Attributes = BrandHrefAttributeName)]
// [HtmlTargetElement(TagNames.Navbar, Attributes = ThemeAttributeName)]
// [HtmlTargetElement(TagNames.Navbar, Attributes = BackgroundAttributeName)]
// [HtmlTargetElement(TagNames.Navbar, Attributes = AttributesNames)]
public class NavbarTagHelper(IActionContextAccessor actionContextAccessor)
    : TagHelper,
        IHaveAnActionContextAccessor,
        IIdentifiable<string>
{
    #region --- Attribute Names ---
    private const string AttributesNames =
        BrandTextAttributeName
        + ","
        + BrandImageAttributeName
        + ","
        + BrandHrefAttributeName
        + ","
        + ThemeAttributeName
        + ","
        + BackgroundAttributeName;
    private const string BrandTextAttributeName = "brand-text";
    private const string BrandImageAttributeName = "brand-image";
    private const string BrandHrefAttributeName = "brand-href";
    private const string BrandAreaAttributeName = "brand-area";
    private const string BrandControllerAttributeName = "brand-controller";
    private const string BrandActionAttributeName = "brand-action";
    private const string ThemeAttributeName = "theme";
    private const string BackgroundAttributeName = "background";
    #endregion

    #region --- Properties ---

    public IActionContextAccessor ActionContextAccessor => actionContextAccessor;

    [HtmlAttributeName(BrandHrefAttributeName)]
    public string BrandHref { get; set; } = "#";

    [HtmlAttributeName(BrandAreaAttributeName)]
    public string BrandArea { get; set; } = string.Empty;

    [HtmlAttributeName(BrandControllerAttributeName)]
    public string BrandController { get; set; } = string.Empty;

    [HtmlAttributeName(BrandActionAttributeName)]
    public string BrandAction { get; set; } = string.Empty;

    [HtmlAttributeName(BrandTextAttributeName)]
    public string BrandText { get; set; }

    [HtmlAttributeName(BrandImageAttributeName)]
    [ConvertVirtualUrl]
    public string BrandImage { get; set; }

    [HtmlAttributeName(ThemeAttributeName)]
    public Theme Theme { get; set; } = Theme.Light;

    [HtmlAttributeName(BackgroundAttributeName)]
    public Color Background { get; set; } = Color.Light;

    [ViewContext]
    [HtmlAttributeNotBound]
    public ViewContext ViewContext { get; set; }

    [CopyToOutput]
    public string Id { get; set; } = guid.NewGuid().ToString()[..8];

    #endregion

    // public override void Init(TagHelperContext context)
    // {
    //     this.Init(context, ActionContextAccessor);
    //     base.Init(context);
    // }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        await output.GetChildContentAsync();

        output.TagName = TagNames.Nav;
        output.AddCssClass(
            $"{CssClasses.Navbar} {CssClasses.NavbarExpandLg} {CssClasses.BgPrimary}"
        );

        // Theme
        if (Theme != Theme.Default)
        {
            output.AddCssClass(
                $"navbar-{Theme.GetEnumInfo().Name} data-bs-theme-{Theme.GetEnumInfo().Name}"
            );

            // Set background to valid color
            Background = Theme == Theme.Dark && Background == Color.Light ? Color.Dark : Background;
        }
        else
        {
            output.AddCssClass(CssClasses.NavBarLight);
        }

        // Background
        output.AddCssClass(Background.GetColorInfo().BackgroundCssClass);

        // Brand
        if (!IsNullOrEmpty(BrandText) || !IsNullOrEmpty(BrandImage))
        {
            output.PreContent.AppendHtml(GenerateBrand());
        }

        // Toggler
        output.PreContent.AppendHtml(
            $"<button class=\"navbar-toggler\" type=\"button\" data-toggle=\"collapse\" data-target=\"#{Id}\" aria-controls=\"{Id}\" aria-expanded=\"false\" aria-label=\"Toggle Navigation\"><span class=\"navbar-toggler-icon\"></span></button>"
        );

        // Wrapper
        output.WrapHtmlContentInside(
            $"<div class=\"collapse navbar-collapse\" id=\"{Id}\">",
            "</div>"
        );
    }

    private string GetBrandHref()
    {
        // Href
        if (!IsNullOrEmpty(BrandHref))
        {
            return BrandHref;
        }
        else
        {
            var urlHelper = new UrlHelper(ViewContext);
            return urlHelper.Action(BrandAction, BrandController, new { area = BrandArea });
        }
    }

    private IHtmlContent GenerateBrand()
    {
        // Anchor
        var brand = new TagBuilder(TagNames.Anchor);
        brand.AddCssClass(CssClasses.NavBarBrand);
        brand.Attributes.Add("href", GetBrandHref());

        // Image
        if (!IsNullOrEmpty(BrandImage))
        {
            var img = new TagBuilder(TagNames.Img) { TagRenderMode = TagRenderMode.SelfClosing };
            img.Attributes.Add(AttributeNames.Src, BrandImage);
            img.Attributes.Add("height", "30");
            img.Attributes.Add("alt", BrandText);

            if (!IsNullOrEmpty(BrandText))
            {
                img.AddCssClass($"{CssClasses.DInlineBlock} {CssClasses.AlignTop}");
            }

            brand.InnerHtml.AppendHtml(img);
        }

        // Text
        brand.InnerHtml.Append($" {BrandText}");

        return brand;
    }
}
