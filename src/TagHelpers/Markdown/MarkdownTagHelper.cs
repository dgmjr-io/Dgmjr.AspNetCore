namespace Dgmjr.AspNetCore.TagHelpers.Markdown;

[HtmlTargetElement("markdown", TagStructure = TagStructure.NormalOrSelfClosing)]
[HtmlTargetElement(Attributes = "markdown")]
public class MarkdownTagHelper : TagHelper
{
    public ModelExpression Content { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        if (output.TagName == "markdown")
        {
            output.TagName = null;
        }
        output.Attributes.RemoveAll("markdown");

        var content = await GetContent(output);
        var markdown = content;
        var html = CommonMarkConverter.Convert(markdown);
        output.Content.SetHtmlContent(html ?? "");
    }

    private async Task<string?> GetContent(TagHelperOutput output)
    {
        if (Content == null)
        {
            return (await output.GetChildContentAsync()).GetContent();
        }

        return Content.Model?.ToString();
    }
}
