/*
 * TypeName.cs
 *
 *   Created: 2024-22-27T05:22:04-05:00
 *   Modified: 2024-22-27T05:22:04-05:00
 *
 *   Author: David G. Moore, Jr. <david@jsonschema.xyz>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System.Threading.Tasks;

namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.Code;

[HtmlTargetElement("code", Attributes = "class-name")]
[HtmlTargetElement("class-name", ParentTag = "code")]
[HtmlTargetElement("class", ParentTag = "code")]
public class ClassName : TagHelper
{
    public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.AddCssClass("type");
        return base.ProcessAsync(context, output);
    }
}

[HtmlTargetElement("code", Attributes = "const")]
[HtmlTargetElement("const", ParentTag = "code")]
public class Constant : TagHelper
{
    public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.AddCssClass("constant");
        return base.ProcessAsync(context, output);
    }
}

[HtmlTargetElement("code", Attributes = "keyword")]
[HtmlTargetElement("keyword", ParentTag = "code")]
public class Keyword : TagHelper
{
    public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.AddCssClass("keyword");
        return base.ProcessAsync(context, output);
    }
}

[HtmlTargetElement("code", Attributes = "var")]
[HtmlTargetElement("var", ParentTag = "code")]
public class Variable : TagHelper
{
    public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.AddCssClass("variable");
        return base.ProcessAsync(context, output);
    }
}

[HtmlTargetElement("code", Attributes = "number")]
[HtmlTargetElement("number", ParentTag = "code")]
[HtmlTargetElement("numeric", ParentTag = "code")]
[HtmlTargetElement("numeric-literal", ParentTag = "code")]
public class NumberLiteral : TagHelper
{
    public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.AddCssClass("number");
        return base.ProcessAsync(context, output);
    }
}

[HtmlTargetElement("code", Attributes = "primitive")]
[HtmlTargetElement("primitive", ParentTag = "code")]
public class Primitive : TagHelper
{
    public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.AddCssClass("primitive");
        return base.ProcessAsync(context, output);
        /* this is a comment */
    }
}

[HtmlTargetElement("code", Attributes = "string")]
[HtmlTargetElement("string", ParentTag = "code")]
[HtmlTargetElement("string-literal", ParentTag = "code")]
public class StringLiteral : TagHelper
{
    public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.AddCssClass("string");
        return base.ProcessAsync(context, output);
    }
}

[HtmlTargetElement("code", Attributes = "method")]
[HtmlTargetElement("code", Attributes = "function")]
[HtmlTargetElement("code", Attributes = "property")]
[HtmlTargetElement("code", Attributes = "prop")]
[HtmlTargetElement("method", ParentTag = "code")]
[HtmlTargetElement("function", ParentTag = "code")]
[HtmlTargetElement("property", ParentTag = "code")]
[HtmlTargetElement("prop", ParentTag = "code")]
public class MethodOrProperty : TagHelper
{
    public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.AddCssClass("method");
        return base.ProcessAsync(context, output);
    }
}

[HtmlTargetElement("code", Attributes = "namespace")]
[HtmlTargetElement("namespace", ParentTag = "code")]
public class Namespace : TagHelper
{
    public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.AddCssClass("namespace");
        return base.ProcessAsync(context, output);
    }
}
