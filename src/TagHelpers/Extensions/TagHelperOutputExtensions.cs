/*
 * TagHelperOutputExtensions.cs
 *
 *   Created: 2024-23-15T17:23:56-05:00
 *   Modified: 2024-23-15T17:23:57-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.TagHelpers.Extensions;

public static class TagHelperOutputExtensions
{
    public static void AddCssClass(this TagHelperOutput output, string cssClass)
    {
        output.AddCssClass([cssClass]);
    }

    public static void AddCssClass(this TagHelperOutput output, IEnumerable<string> cssClasses)
    {
        if (output.Attributes.ContainsName("class") && output.Attributes["class"] != null)
        {
            var classes = output.Attributes["class"].Value.ToString().Split([' ']).ToList();
            classes.AddRange(cssClasses.Where((string cssClass) => !classes.Contains(cssClass)));
            output.Attributes.SetAttribute("class", classes.Aggregate((string s, string s1) => s + " " + s1));
        }
        else if (output.Attributes.ContainsName("class"))
        {
            output.Attributes.SetAttribute("class", cssClasses.Aggregate((string s, string s1) => s + " " + s1));
        }
        else
        {
            output.Attributes.Add("class", cssClasses.Aggregate((string s, string s1) => s + " " + s1));
        }
    }

    public static void RemoveCssClass(this TagHelperOutput output, string cssClass)
    {
        if (!output.Attributes.ContainsName("class"))
        {
            return;
        }
        var list = output.Attributes["class"].Value.ToString().Split([' ']).ToList();
        list.Remove(cssClass);
        if (list.Count == 0)
        {
            output.Attributes.RemoveAll("class");
            return;
        }
        output.Attributes.SetAttribute("class", list.Aggregate((string s, string s1) => s + " " + s1));
    }

    public static void AddCssStyle(this TagHelperOutput output, string name, string value)
    {
        if (output.Attributes.ContainsName("style"))
        {
            if (IsNullOrEmpty(output.Attributes["style"].Value.ToString()))
            {
                output.Attributes.SetAttribute("style", name + ": " + value + ";");
                return;
            }
            output.Attributes.SetAttribute("style", (output.Attributes["style"].Value.ToString().EndsWith(';') ? " " : "; ") + name + ": " + value + ";");
        }
        else
        {
            output.Attributes.Add("style", name + ": " + value + ";");
        }
    }

    public static async Task LoadChildContentAsync(this TagHelperOutput output)
    {
        var content = output.Content;
        content.SetHtmlContent((await output.GetChildContentAsync()) ?? new DefaultTagHelperContent());
    }

    public static TagHelperContent ToTagHelperContent(this TagHelperOutput output)
    {
        var defaultTagHelperContent = new DefaultTagHelperContent();
        defaultTagHelperContent.AppendHtml(output.PreElement);
        var tagBuilder = new TagBuilder(output.TagName);
        foreach (var attribute in output.Attributes)
        {
            tagBuilder.Attributes.Add(attribute.Name, attribute.Value?.ToString());
        }
        if (output.TagMode == TagMode.SelfClosing)
        {
            tagBuilder.TagRenderMode = TagRenderMode.SelfClosing;
            defaultTagHelperContent.AppendHtml(tagBuilder);
        }
        else
        {
            tagBuilder.TagRenderMode = TagRenderMode.StartTag;
            defaultTagHelperContent.AppendHtml(tagBuilder);
            defaultTagHelperContent.AppendHtml(output.PreContent);
            defaultTagHelperContent.AppendHtml(output.Content);
            defaultTagHelperContent.AppendHtml(output.PostContent);
            if (output.TagMode == TagMode.StartTagAndEndTag)
            {
                defaultTagHelperContent.AppendHtml("</" + output.TagName + ">");
            }
        }
        defaultTagHelperContent.AppendHtml(output.PostElement);
        return defaultTagHelperContent;
    }

    public static void AddAriaAttribute(this TagHelperOutput output, string name, object value)
    {
        output.MergeAttribute("aria-" + name, value);
    }

    public static void AddDataAttribute(this TagHelperOutput output, string name, object value)
    {
        output.MergeAttribute("data-" + name, value);
    }

    public static void MergeAttribute(this TagHelperOutput output, string key, object value)
    {
        output.Attributes.SetAttribute(key, value);
    }

    public static void WrapContentOutside(this TagHelperOutput output, TagBuilder builder)
    {
        builder.TagRenderMode = TagRenderMode.StartTag;
        output.WrapContentOutside(builder, new TagBuilder(builder.TagName)
        {
            TagRenderMode = TagRenderMode.EndTag
        });
    }

    public static void WrapContentOutside(this TagHelperOutput output, IHtmlContent startTag, IHtmlContent endTag)
    {
        output.PreContent.Prepend(startTag);
        output.PostContent.AppendHtml(endTag);
    }

    public static void WrapContentOutside(this TagHelperOutput output, string startTag, string endTag)
    {
        output.PreContent.Prepend(startTag);
        output.PostContent.Append(endTag);
    }

    public static void WrapHtmlContentOutside(this TagHelperOutput output, string startTag, string endTag)
    {
        output.PreContent.PrependHtml(startTag);
        output.PostContent.AppendHtml(endTag);
    }

    public static void WrapContentInside(this TagHelperOutput output, TagBuilder builder)
    {
        builder.TagRenderMode = TagRenderMode.StartTag;
        output.WrapContentInside(builder, new TagBuilder(builder.TagName)
        {
            TagRenderMode = TagRenderMode.EndTag
        });
    }

    public static void WrapContentInside(this TagHelperOutput output, IHtmlContent startTag, IHtmlContent endTag)
    {
        output.PreContent.AppendHtml(startTag);
        output.PostContent.Prepend(endTag);
    }

    public static void WrapContentInside(this TagHelperOutput output, string startTag, string endTag)
    {
        output.PreContent.Append(startTag);
        output.PostContent.Prepend(endTag);
    }

    public static void WrapHtmlContentInside(this TagHelperOutput output, string startTag, string endTag)
    {
        output.PreContent.AppendHtml(startTag);
        output.PostContent.PrependHtml(endTag);
    }

    public static void WrapOutside(this TagHelperOutput output, TagBuilder builder)
    {
        builder.TagRenderMode = TagRenderMode.StartTag;
        output.WrapOutside(builder, new TagBuilder(builder.TagName)
        {
            TagRenderMode = TagRenderMode.EndTag
        });
    }

    public static void WrapOutside(this TagHelperOutput output, IHtmlContent startTag, IHtmlContent endTag)
    {
        output.PreElement.Prepend(startTag);
        output.PostElement.AppendHtml(endTag);
    }

    public static void WrapOutside(this TagHelperOutput output, string startTag, string endTag)
    {
        output.PreElement.Prepend(startTag);
        output.PostElement.Append(endTag);
    }

    public static void WrapHtmlOutside(this TagHelperOutput output, string startTag, string endTag)
    {
        output.PreElement.PrependHtml(startTag);
        output.PostElement.AppendHtml(endTag);
    }

    public static void WrapInside(this TagHelperOutput output, TagBuilder builder)
    {
        builder.TagRenderMode = TagRenderMode.StartTag;
        output.WrapInside(builder, new TagBuilder(builder.TagName)
        {
            TagRenderMode = TagRenderMode.EndTag
        });
    }

    public static void WrapInside(this TagHelperOutput output, IHtmlContent startTag, IHtmlContent endTag)
    {
        output.PreElement.AppendHtml(startTag);
        output.PostElement.Prepend(endTag);
    }

    public static void WrapInside(this TagHelperOutput output, string startTag, string endTag)
    {
        output.PreElement.Append(startTag);
        output.PostElement.Prepend(endTag);
    }

    public static void WrapHtmlInside(this TagHelperOutput output, string startTag, string endTag)
    {
        output.PreElement.AppendHtml(startTag);
        output.PostElement.PrependHtml(endTag);
    }
}
