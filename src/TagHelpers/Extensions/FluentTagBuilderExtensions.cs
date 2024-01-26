namespace Dgmjr.AspNetCore.TagHelpers.Extensions;

public static class FluentTagBuilderExtensions
{
    public static TagBuilder WithCssClass(this TagBuilder @this, string cssClass)
    {
        @this.AddCssClass(cssClass);
        return @this;
    }

    public static TagBuilder WithAttribute(
        this TagBuilder @this,
        string attributeName,
        string attributeValue
    )
    {
        @this.Attributes[attributeName] = attributeValue;
        return @this;
    }

    public static TagBuilder WithAttributes(this TagBuilder @this, params string[] attributes)
    {
        foreach (var attribute in attributes)
        {
            var parts = attribute.Split('=');
            if (parts.Length != 2)
            {
                throw new ArgumentException(
                    $"Attribute '{attribute}' is not in the expected format 'name=value'.",
                    nameof(attributes)
                );
            }

            @this.WithAttribute(parts[0], parts[1]);
        }

        return @this;
    }

    public static TagBuilder AppendInnerHtml(this TagBuilder @this, string innerHtml)
    {
        @this.InnerHtml.Append(innerHtml);
        return @this;
    }

    public static TagBuilder AppendInnerHtml(this TagBuilder @this, TagBuilder innerHtml)
    {
        @this.InnerHtml.AppendHtml(innerHtml);
        return @this;
    }

    public static TagBuilder AppendInnerHtml(this TagBuilder @this, IHtmlContent innerHtml)
    {
        @this.InnerHtml.AppendHtml(innerHtml);
        return @this;
    }

    public static TagBuilder AppendInnerHtml(
        this TagBuilder @this,
        IEnumerable<TagBuilder> innerHtml
    )
    {
        foreach (var inner in innerHtml)
        {
            @this.InnerHtml.AppendHtml(inner);
        }

        return @this;
    }

    public static TagBuilder AppendInnerHtml(this TagBuilder @this, params TagBuilder[] innerHtml)
    {
        foreach (var inner in innerHtml)
        {
            @this.InnerHtml.AppendHtml(inner);
        }

        return @this;
    }

    public static TagBuilder AppendInnerHtml(
        this TagBuilder @this,
        IEnumerable<IHtmlContent> innerHtml
    )
    {
        foreach (var inner in innerHtml)
        {
            @this.InnerHtml.AppendHtml(inner);
        }

        return @this;
    }

    public static TagBuilder AppendInnerHtml(this TagBuilder @this, params IHtmlContent[] innerHtml)
    {
        foreach (var inner in innerHtml)
        {
            @this.InnerHtml.AppendHtml(inner);
        }

        return @this;
    }

    public static TagBuilder WithInnerText(this TagBuilder @this, string innerText)
    {
        @this.InnerHtml.Append(innerText);
        return @this;
    }
}
