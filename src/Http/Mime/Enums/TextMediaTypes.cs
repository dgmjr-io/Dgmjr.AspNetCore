/*
 * TextMediaType.cs
 *
 *   Created: 2023-03-18-06:57:42
 *   Modified: 2023-03-18-06:57:42
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Mime.Enums;

using System.Runtime.Serialization;

[GenerateEnumerationRecordStruct("Text", "Dgmjr.Mime")]
public enum TextMediaTypes : int
{
    [Display(Name = TextMediaTypeNames.Any, Description = "Any text media type")]
    [EnumMember(Value = TextMediaTypeNames.Any)]
    [Uri(IanaMediaTypeUrlBase + "#text/*")]
    Any = int.MaxValue,

    [Display(Name = TextMediaTypeNames.Base, Description = "The base text media type")]
    [EnumMember(Value = TextMediaTypeNames.Base)]
    [Uri(IanaMediaTypeUrlBase + "#text")]
    Base = 0,

    [Display(Name = TextMediaTypeNames.Html, Description = nameof(Html))]
    [EnumMember(Value = TextMediaTypeNames.Html)]
    [Uri(IanaMediaTypeUrlBase + TextMediaTypeNames.Html)]
    Html,

    [Display(Name = TextMediaTypeNames.Plain, Description = nameof(Plain))]
    [EnumMember(Value = TextMediaTypeNames.Plain)]
    Plain,

    [Display(Name = TextMediaTypeNames.PlainWithProblem, Description = nameof(PlainWithProblem))]
    [EnumMember(Value = TextMediaTypeNames.PlainWithProblem)]
    PlainWithProblem,

    [Display(Name = TextMediaTypeNames.RichText, Description = nameof(RichText))]
    [EnumMember(Value = TextMediaTypeNames.RichText)]
    RichText,

    [Display(Name = TextMediaTypeNames.Xml, Description = nameof(Xml))]
    [EnumMember(Value = TextMediaTypeNames.Xml)]
    Xml,

    [Display(Name = TextMediaTypeNames.Csv, Description = nameof(Csv))]
    [EnumMember(Value = TextMediaTypeNames.Csv)]
    Csv,

    [Display(Name = TextMediaTypeNames.Css, Description = nameof(Css))]
    [EnumMember(Value = TextMediaTypeNames.Css)]
    Css,

    [Display(Name = TextMediaTypeNames.Javascript, Description = nameof(Javascript))]
    [EnumMember(Value = TextMediaTypeNames.Javascript)]
    Javascript,

    [Display(Name = TextMediaTypeNames.Json, Description = nameof(Json))]
    [EnumMember(Value = TextMediaTypeNames.Json)]
    Json,

    [Display(Name = TextMediaTypeNames.Markdown, Description = nameof(Json))]
    [EnumMember(Value = TextMediaTypeNames.Markdown)]
    Markdown
}
