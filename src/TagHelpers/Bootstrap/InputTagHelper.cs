namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap;

using System.Threading.Tasks;

using Microsoft.AspNetCore.Razor.TagHelpers;

using InputType = Dgmjr.AspNetCore.TagHelpers.Enumerations.InputType;
using LabelPosition = Dgmjr.AspNetCore.TagHelpers.Enumerations.LabelPosition;

[HtmlTargetElement(TagNames.Input)]
public abstract class InputTagHelper(IHtmlGenerator generator)
    : Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper(generator)
{
    [HtmlAttributeName(AttributeNames.Type)]
public virtual InputType InputType
{
    get => Enum.TryParse<InputType>(InputTypeName, out var value) ? value : InputType.Text;
    set => InputTypeName = value.ToString().ToLower();
}

[HtmlAttributeName(AttributeNames.Placeholder)]
public string? Placeholder { get; set; }

[HtmlAttributeName(AttributeNames.MarginBottom)]
public int? MarginBottom { get; set; } = 3;

protected string MarginBottomCssClass =>
    MarginBottom.HasValue ? $"mb-{MarginBottom}" : string.Empty;

[HtmlAttributeName(AttributeNames.Label)]
public string? Label { get; set; }

[HtmlAttributeName(AttributeNames.TextBefore)]
public string? TextBefore { get; set; }

[HtmlAttributeName(AttributeNames.TextAfter)]
public string? TextAfter { get; set; }

[HtmlAttributeName(AttributeNames.BsLabelPosition)]
public LabelPosition LabelPosition { get; set; } =
    Dgmjr.AspNetCore.TagHelpers.Enumerations.LabelPosition.Default;

[HtmlAttributeName(AttributeNames.Id)]
public string Id
{
    get => _id ??= guid.NewGuid().ToString();
    set => _id = value;
}
private string? _id;

public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
{
    output.AddCssClass("form-control");

    var divTagBuilder = new TagBuilder(TagNames.Div);

    divTagBuilder.AddCssClass("form-group");
    divTagBuilder.AddCssClass(MarginBottomCssClass);

    if (Placeholder is not null)
    {
        output.Attributes.SetAttribute(AttributeNames.Placeholder, Placeholder);
    }

    if (Label is not null)
    {
        output.PreElement.AppendHtmlLine($"<div class=\"form-group\">");
        switch (LabelPosition)
        {
            case LabelPosition.Default:
                output.PreElement.AppendHtmlLine($"<span for=\"{For}\">{Label}</label>");
                break;
            case LabelPosition.Left:
                output.PreElement.AppendHtmlLine(
                    $"<span for=\"{For}\" class=\"input-group-text\">{Label}</label>"
                );
                break;
            case LabelPosition.Right:
                output.PostElement.AppendHtmlLine(
                    $"<span for=\"{For}\" class=\"input-group-text\">{Label}</label>"
                );
                break;
            case LabelPosition.Floating:
                output.PostElement.AppendHtmlLine(
                    $"<label for=\"{For}\" class=\"{LabelPosition.GetEnumInfo().Name}\">{Label}</label>"
                );
                break;
        }
        output.PreElement.AppendHtml(
            $"<label for=\"{For}\" class=\"{LabelPosition.GetEnumInfo().Name}\">{Label}</label>"
        );
    }

    output.PreElement.SetHtmlContent($"<div class=\"{MarginBottomCssClass}\">");
    output.PostElement.SetHtmlContent("</div>");

    return base.ProcessAsync(context, output);
}
}
