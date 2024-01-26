/*
 * PageHeader.cs
 *
 *   Created: 2024-02-16T02:02:36-05:00
 *   Modified: 2024-02-16T02:02:37-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap;

using Dgmjr.AspNetCore.TagHelpers.Enumerations;

[HtmlTargetElement(TagNames.PageHeader)]
public class PageHeader(IHtmlGenerator generator) : TagHelper(), IHaveAWritableId<string>
{
    [HtmlAttributeName(AttributeNames.HeadingType)]
    public HeadingType HeadingType { get; set; } = HeadingType.h1;

    [HtmlAttributeName(AttributeNames.Id)]
    public string Id { get; set; }

    [HtmlAttributeName(AttributeNames.Title)]
    public string Title { get; set; } = string.Empty;

    [ViewContext]
    public ViewContext ViewContext { get; set; }

    protected IHtmlGenerator Generator => generator;

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.AddClass("page-header", HtmlEncoder.Default);
        output.Content.AppendHtml(
            $"<{HeadingType.ToString().ToLower()}>{Title}</{HeadingType.ToString().ToLower()}>"
        );
    }
}
