namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap;

[HtmlTargetElement(TagNames.Footer, Attributes = CopyrightHolderAttributeName)]
[HtmlTargetElement(TagNames.Footer, Attributes = CopyrightStartYearAttributeName)]
[HtmlTargetElement(TagNames.Footer, Attributes = CopyrightEndYearAttributeName)]
public class PageFooter : TagHelper
{
    public const string CopyrightStartYearAttributeName = "copyright-start-year";
    public const string CopyrightHolderEmailAttributeName = "copyright-holder-email";

    public const string CopyrightEndYearAttributeName = "copyright-end-year";
    public const string BackgroundAttributeName = "bs-background";
    public const string PositionAttributeName = "position";
    public const string CopyrightHolderAttributeName = "copyright-holder";
    public const string TextColorAttributeName = "bs-text-color";

    /// <summary>The text color of the footer (defaults to <see cref="Color.light" />).</summary>
    /// <value></value>
    [HtmlAttributeName(TextColorAttributeName)]
    public Color TextColor { get; set; } = Color.light;

    /// <summary>The start year of the copyright</summary>
    [HtmlAttributeName(CopyrightStartYearAttributeName)]
    public int? CopyrightStartYear { get; set; } = datetime.Now.Year;

    /// <summary>The end year of the copyright (usually the current year)</summary>
    /// <value></value>
    [HtmlAttributeName(CopyrightEndYearAttributeName)]
    public int? CopyrightEndYear { get; set; } = datetime.Now.Year;

    /// <summary>The name of the person or organization that owns the copyright for the content</summary>
    [HtmlAttributeName(CopyrightHolderAttributeName)]
    public string CopyrightHolder { get; set; }

    /// <summary>The email address of the copyright holder</summary>
    [HtmlAttributeName(CopyrightHolderEmailAttributeName)]
    public string CopyrightHolderEmail { get; set; }

    /// <summary>The background color of the footer (defaults to <see cref="Color.dark" />).</summary>
    [HtmlAttributeName(BackgroundAttributeName)]
    public Color BackgroundColor { get; set; } = Color.primary;

    /// <summary>Where the footer should show up (defaults to <see cref="Position.fixedbottom" />).</summary>
    [HtmlAttributeName(PositionAttributeName)]
    public Position Position { get; set; } = Position.fixedbottom;

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = TagNames.Footer;
        var childContent = await output.GetChildContentAsync();
        output.Content.AppendHtml(childContent);
        output.AddCssClass(
            $"footer border-top bg-{BackgroundColor.GetName()} text-{TextColor.GetName()} {Position.GetName()}"
        );
        output.PreContent.AppendHtml(
            $$$"""
            < div class="{{{CssClasses.Container}}}">
            """
        );
        if (!IsNullOrEmpty(CopyrightHolder))
        {
            output.PreContent.AppendHtml(
                """
                &copy;

                """
            );
            if (CopyrightStartYear.HasValue)
            {
                output.PreContent.AppendHtml(
                    $$$"""

                    {{{datetime.Now.Year
}
}}

                    """
                );
            }
            if (CopyrightEndYear.HasValue && CopyrightEndYear != CopyrightStartYear)
{
    output.PreContent.AppendHtml(
                    $$$"""

        - { { { datetime.Now.Year} } }
    """
                );
}
if (!IsNullOrEmpty(CopyrightHolderEmail))
{
    output.PreContent.AppendHtml(
                    $$$"""

        < a href = "mailto:{{{CopyrightHolderEmail}}}" >
                    { { { CopyrightHolder} } }
                    </ a >
                    |
                    """
                );
}
else
{
    output.PreContent.AppendHtml(
                    $$$"""
                    { { { CopyrightHolder} } }

                    |

                    """
                );
}
        }
    }
}
