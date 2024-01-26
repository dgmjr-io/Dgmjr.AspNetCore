/*
 * AccordionItem.cs
 *
 *   Created: 2024-10-20T01:10:25-05:00
 *   Modified: 2024-10-20T01:10:25-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System.Security.AccessControl;

namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.Accordion;

[HtmlTargetElement(TagNames.AccordionItem, ParentTag = TagNames.Accordion)]
public class AccordionItem : TagHelper, IIdentifiable<string>
{
    [HtmlAttributeName(AttributeNames.Header)]
    public string Header { get; set; } = string.Empty;

    [HtmlAttributeName(AttributeNames.HeadingType)]
    public HeadingType HeaderHeadingType { get; set; } = HeadingType.H2;

    private string HeaderHeadingTagName => HeaderHeadingType.ToString().ToLower();

    [HtmlAttributeName(AttributeNames.Id)]
    public string Id { get; set; } = $"_{guid.NewGuid().ToString()[0..8]}";

    [HtmlAttributeName(AttributeNames.IsExpanded)]
    public bool IsExpanded { get; set; } = false;

    [HtmlAttributeName(AttributeNames.HeaderColor)]
    public Color HeaderColor { get; set; } = Color.None;

    [HtmlAttributeName(AttributeNames.HeaderBorderColor)]
    public Color HeaderBorderColor { get; set; } = Color.None;

    [HtmlAttributeName(AttributeNames.Color)]
    public Color Color { get; set; } = Color.None;

    [HtmlAttributeName(AttributeNames.BorderColor)]
    public Color BorderColor { get; set; } = Color.None;

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "";
        output.AddCssClass(CssClasses.AccordionItem);

        var accordionItem = new TagBuilder(TagNames.Div);
        accordionItem.AddCssClass(CssClasses.AccordionItem);

        var accordionItemHeader = new TagBuilder(HeaderHeadingTagName);
        accordionItemHeader.AddCssClass(CssClasses.AccordionHeader);
        if (HeaderColor != Color.None)
        {
            accordionItemHeader.AddCssClass(
                $"{CssClasses.TextBackground_}{HeaderColor.ToString().ToLower()}"
            );
        }
        if (HeaderBorderColor != Color.None)
        {
            accordionItemHeader.AddCssClass(
                $"{CssClasses.Border_}{HeaderBorderColor.ToString().ToLower()}"
            );
        }

        var accordionItemButton = new TagBuilder(TagNames.Button);
        accordionItemButton.AddCssClass(CssClasses.AccordionButton);
        if (!IsExpanded)
        {
            accordionItemButton.AddCssClass(CssClasses.Collapsed);
        }
        accordionItemButton.Attributes.Add("type", TagNames.Button);
        accordionItemButton.Attributes.Add("data-bs-toggle", CssClasses.Collapse);
        accordionItemButton.Attributes.Add("data-bs-target", $"#{Id}");
        accordionItemButton.Attributes.Add("aria-expanded", IsExpanded.ToString().ToLower());
        accordionItemButton.Attributes.Add("aria-controls", Id);
        accordionItemButton.InnerHtml.Append(Header);

        accordionItemHeader.InnerHtml.AppendHtml(accordionItemButton);

        var accordionItemCollapse = new TagBuilder(TagNames.Div);
        accordionItemCollapse.AddCssClass(CssClasses.AccordionCollapse);
        accordionItemCollapse.AddCssClass(CssClasses.Collapse);
        if (IsExpanded)
        {
            accordionItemCollapse.AddCssClass(CssClasses.Show);
        }
        if (Color != Color.None)
        {
            accordionItemCollapse.AddCssClass(
                $"{CssClasses.TextBackground_}{HeaderColor.ToString().ToLower()}"
            );
        }
        if (BorderColor != Color.None)
        {
            accordionItemCollapse.AddCssClass(
                $"{CssClasses.Border_}{HeaderBorderColor.ToString().ToLower()}"
            );
        }
        accordionItemCollapse.Attributes.Add("id", Id);
        accordionItemCollapse.Attributes.Add("aria-labelledby", Id);
        accordionItemCollapse.Attributes.Add("data-bs-parent", $"#{Id}");

        var accordionItemBody = new TagBuilder(TagNames.Div);
        accordionItemBody.AddCssClass(CssClasses.AccordionBody);
        var content = await output.GetChildContentAsync();
        accordionItemBody.InnerHtml.AppendHtml(content);

        accordionItemCollapse.InnerHtml.AppendHtml(accordionItemBody);

        accordionItem.InnerHtml.AppendHtml(accordionItemHeader);

        accordionItem.InnerHtml.AppendHtml(accordionItemCollapse);

        output.Content.SetHtmlContent(accordionItem);

        // return Task.CompletedTask;

        // output.PreContent.AppendHtml(
        //     $"""
        //     <{HeaderHeadingType} class="{CssClasses.AccordionHeader}">
        //         <button class="{CssClasses.AccordionButton} {(!IsExpanded ? CssClasses.Collapsed : "")}" type="{TagNames.Button}" data-bs-toggle="{CssClasses.Collapse}" data-bs-target="#{Id}" aria-expanded="{IsExpanded.ToString().ToLower()}" aria-controls="{Id}">
        //             {Header}
        //         </button>
        //     </{HeaderHeadingType}>
        //     <div id="{Id}" class="{CssClasses.AccordionCollapse} {(!IsExpanded ? CssClasses.Collapsed : "")}" aria-labelledby="{Id}" data-bs-parent="#{Id}">
        //         <div class="{CssClasses.AccordionBody}">
        //     """
        // );
        // output.PostContent.AppendHtml("</div>");

        // return Task.CompletedTask;
    }
}
