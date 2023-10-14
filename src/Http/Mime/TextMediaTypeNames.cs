/*
 * MediaTypeNames.cs
 *
 *   Created: 2022-11-29-01:56:37
 *   Modified: 2022-11-29-04:39:51
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Mime;

public static class TextMediaTypeNames
{
    /// <inheritdoc cref="Enums.TextMediaType.Base" />
    public const string Base = "text";
    public const string Any = Base + "/*";
    public const string Html = Base + "/" + "html";
    public const string Plain = Base + "/" + "plain";
    public const string RichText = Base + "/" + "richtext";
    public const string Xml = Base + "/" + "xml";
    public const string Csv = Base + "/" + "csv";
    public const string Css = Base + "/" + "css";
    public const string Javascript = Base + "/" + "javascript";
    public const string Json = Base + "/" + "json";
    public const string PlainWithProblem = Base + "/" + "plain+problem";
    public const string Markdown = Base + "/" + "markdown";
}
