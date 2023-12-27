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

namespace Dgmjr.Mime.Enums;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

[GenerateEnumerationRecordStruct("Application", "Dgmjr.Mime")]
public enum ApplicationMediaTypes
{
    /// <summary> Any application media type. </summary>
    /// <remarks> This is the default value. </remarks>
    /// <seealso cref="ApplicationMediaTypeNames.Any"/>
    /// <seealso cref="ApplicationMediaTypeNames.Base"/>
    /// <remarks>See <see href="https://www.iana.org/assignments/media-types/media-types.xhtml#application">IANA Media Types</see> for more information.</remarks>
    /// <value><inheritdoc cref="ApplicationMediaTypeNames.Any"/></value>
    [Display(
        Name = ApplicationMediaTypeNames.Any,
        Description = "Any application media type",
        GroupName = ApplicationMediaTypeNames.Base
    )]
    [EnumMember(Value = ApplicationMediaTypeNames.Any)]
    [Uri(IanaMediaTypeUrlBase + "#application/*")]
    Any = int.MaxValue,

    /// <summary>The base name for all application media types.</summary>
    /// <remarks>See <see href="https://www.iana.org/assignments/media-types/media-types.xhtml#application">IANA Media Types</see> for more information.</remarks>
    /// <value><inheritdoc cref="ApplicationMediaTypeNames.Base"/></value>
    [Display(
        Name = ApplicationMediaTypeNames.Base,
        Description = "The base name for all application media types",
        GroupName = ApplicationMediaTypeNames.Base
    )]
    [EnumMember(Value = ApplicationMediaTypeNames.Base)]
    [Uri(IanaMediaTypeUrlBase + "#application")]
    Base = 0,

    /// <summary>An example media type.</summary>
    /// <value><inheritdoc cref="ApplicationMediaTypeNames.Example"/></value>
    /// <seealso cref="ApplicationMediaTypeNames.Example"/>
    [Display(
        Name = ApplicationMediaTypeNames.Example,
        Description = "An example media type",
        GroupName = ApplicationMediaTypeNames.Base
    )]
    [EnumMember(Value = ApplicationMediaTypeNames.Example)]
    [Uri(IanaMediaTypeUrlBase + ApplicationMediaTypeNames.Example)]
    Example,

    /// <summary>A media type for a stream of bytes.</summary>
    /// <value><inheritdoc cref="ApplicationMediaTypeNames.OctetStream"/></value>
    /// <seealso cref="ApplicationMediaTypeNames.OctetStream"/>
    [Display(
        Name = ApplicationMediaTypeNames.OctetStream,
        Description = nameof(OctetStream),
        GroupName = ApplicationMediaTypeNames.Base
    )]
    [EnumMember(Value = ApplicationMediaTypeNames.OctetStream)]
    [Uri(IanaMediaTypeUrlBase + ApplicationMediaTypeNames.OctetStream)]
    OctetStream,

    /// <summary>A PDF document.</summary>
    /// <value><inheritdoc cref="ApplicationMediaTypeNames.Pdf"/></value>
    /// <seealso cref="ApplicationMediaTypeNames.Pdf"/>
    [Display(
        Name = ApplicationMediaTypeNames.Pdf,
        Description = "A PDF document",
        GroupName = ApplicationMediaTypeNames.Base
    )]
    [EnumMember(Value = ApplicationMediaTypeNames.Pdf)]
    [Uri(IanaMediaTypeUrlBase + ApplicationMediaTypeNames.Pdf)]
    Pdf,

    /// <summary>A ZIP archive.</summary>
    /// <value><inheritdoc cref="ApplicationMediaTypeNames.Zip"/></value>
    /// <seealso cref="ApplicationMediaTypeNames.Zip"/>
    [Display(
        Name = ApplicationMediaTypeNames.Zip,
        Description = "A ZIP archive",
        GroupName = ApplicationMediaTypeNames.Base
    )]
    [EnumMember(Value = ApplicationMediaTypeNames.Zip)]
    [Uri(IanaMediaTypeUrlBase + ApplicationMediaTypeNames.Zip)]
    Zip,

    /// <summary>Rich Text Format (RTF).</summary>
    /// <value><inheritdoc cref="ApplicationMediaTypeNames.Rtf"/></value>
    /// <seealso cref="ApplicationMediaTypeNames.Rtf"/>
    [Display(
        Name = ApplicationMediaTypeNames.Rtf,
        Description = "Rich Text Format (RTF)",
        GroupName = ApplicationMediaTypeNames.Base
    )]
    [EnumMember(Value = ApplicationMediaTypeNames.Rtf)]
    [Uri(IanaMediaTypeUrlBase + ApplicationMediaTypeNames.Rtf)]
    Rtf,

    /// <summary>A SOAP envelope.</summary>
    /// <value><inheritdoc cref="ApplicationMediaTypeNames.Soap"/></value>
    /// <seealso cref="ApplicationMediaTypeNames.Soap"/>
    [Display(
        Name = ApplicationMediaTypeNames.Soap,
        Description = "A SOAP envelope",
        GroupName = ApplicationMediaTypeNames.Base
    )]
    [EnumMember(Value = ApplicationMediaTypeNames.Soap)]
    [Uri(IanaMediaTypeUrlBase + ApplicationMediaTypeNames.Soap)]
    Soap,

    /// <summary>An XML document.</summary>
    /// <value><inheritdoc cref="ApplicationMediaTypeNames.Xml"/></value>
    /// <seealso cref="ApplicationMediaTypeNames.Xml"/>
    [Display(
        Name = ApplicationMediaTypeNames.Xml,
        Description = "An XML document",
        GroupName = ApplicationMediaTypeNames.Base
    )]
    [EnumMember(Value = ApplicationMediaTypeNames.Xml)]
    [Uri(IanaMediaTypeUrlBase + ApplicationMediaTypeNames.Xml)]
    // [Synonyms(
    //     ApplicationMediaTypeNames.Xml,
    //     TextMediaTypeNames.Xml,
    //     ApplicationMediaTypeNames.Base + "/*+xml"
    // )]
    Xml,

    /// <summary>A JSON document.</summary>
    /// <value><inheritdoc cref="ApplicationMediaTypeNames.Json"/></value>
    /// <seealso cref="ApplicationMediaTypeNames.Json"/>
    [Display(
        Name = ApplicationMediaTypeNames.Json,
        Description = "A JSON document",
        GroupName = ApplicationMediaTypeNames.Base
    )]
    [EnumMember(Value = ApplicationMediaTypeNames.Json)]
    [Uri(IanaMediaTypeUrlBase + ApplicationMediaTypeNames.Json)]
    // [Synonyms(
    //     ApplicationMediaTypeNames.Json,
    //     TextMediaTypeNames.Json,
    //     ApplicationMediaTypeNames.Base + "/*+json"
    // )]
    Json,

    /// <summary>A form URL-encoded document.</summary>
    /// <value>application/x-www-formurlencoded</value>
    /// <seealso cref="ApplicationMediaTypeNames.FormUrlEncoded"/>
    [Display(
        Name = ApplicationMediaTypeNames.FormUrlEncoded,
        Description = "A form URL-encoded document",
        GroupName = ApplicationMediaTypeNames.Base
    )]
    [EnumMember(Value = ApplicationMediaTypeNames.FormUrlEncoded)]
    [Uri(IanaMediaTypeUrlBase + ApplicationMediaTypeNames.FormUrlEncoded)]
    FormUrlEncoded,

    /// <summary>A binary-encoded Javascript Object Notation (BSON) document.</summary>
    /// <value><inheritdoc cref="ApplicationMediaTypeNames.Bson"/></value>
    /// <seealso cref="ApplicationMediaTypeNames.Bson"/>
    [Display(
        Name = ApplicationMediaTypeNames.Bson,
        Description = "A binary-encoded Javascript Object Notation (BSON) document",
        GroupName = ApplicationMediaTypeNames.Base
    )]
    [EnumMember(Value = ApplicationMediaTypeNames.Bson)]
    [Uri(IanaMediaTypeUrlBase + ApplicationMediaTypeNames.Bson)]
    // [Synonyms(ApplicationMediaTypeNames.Bson, ApplicationMediaTypeNames.Base + "/*+bson")]
    Bson,

    /// <summary>A MessagePack document.</summary>
    /// <value><inheritdoc cref="ApplicationMediaTypeNames.MessagePack"/></value>
    /// <seealso cref="ApplicationMediaTypeNames.MessagePack"/>
    [Display(
        Name = ApplicationMediaTypeNames.MessagePack,
        Description = nameof(MessagePack),
        GroupName = ApplicationMediaTypeNames.Base
    )]
    [EnumMember(Value = ApplicationMediaTypeNames.MessagePack)]
    // [Synonyms(
    //     ApplicationMediaTypeNames.MessagePack,
    //     ApplicationMediaTypeNames.Base + "/msgpack",
    //     ApplicationMediaTypeNames.Base + "/*+msgpack"
    // )]
    MessagePack,

    /// <summary>A Problem JSON document.</summary>
    /// <value><inheritdoc cref="ApplicationMediaTypeNames.ProblemJson"/></value>
    /// <seealso cref="ApplicationMediaTypeNames.ProblemJson"/>
    [Display(
        Name = ApplicationMediaTypeNames.ProblemJson,
        Description = "A Problem JSON document",
        GroupName = ApplicationMediaTypeNames.Base
    )]
    [EnumMember(Value = ApplicationMediaTypeNames.ProblemJson)]
    [Uri(IanaMediaTypeUrlBase + ApplicationMediaTypeNames.ProblemJson)]
    // [Synonyms(
    //     ApplicationMediaTypeNames.ProblemJson,
    //     ApplicationMediaTypeNames.Base + "/json+problem"
    // )]
    ProblemJson,

    /// <summary>A Problem XML document.</summary>
    /// <value><inheritdoc cref="ApplicationMediaTypeNames.ProblemXml"/></value>
    /// <seealso cref="ApplicationMediaTypeNames.ProblemXml"/>
    [Display(
        Name = ApplicationMediaTypeNames.ProblemXml,
        Description = "A Problem XML document",
        GroupName = ApplicationMediaTypeNames.Base
    )]
    [EnumMember(Value = ApplicationMediaTypeNames.ProblemXml)]
    [Uri(IanaMediaTypeUrlBase + ApplicationMediaTypeNames.ProblemXml)]
    // [Synonyms(
    //     ApplicationMediaTypeNames.ProblemXml,
    //     ApplicationMediaTypeNames.Base + "/xml+problem"
    // )]
    ProblemXml,

    /// <summary>A JSON Patch document.</summary>
    /// <value><inheritdoc cref="ApplicationMediaTypeNames.JsonPatch"/></value>
    /// <seealso cref="ApplicationMediaTypeNames.JsonPatch"/>
    [Display(
        Name = ApplicationMediaTypeNames.JsonPatch,
        Description = "A JSON Patch document",
        GroupName = ApplicationMediaTypeNames.Base
    )]
    [EnumMember(Value = ApplicationMediaTypeNames.JsonPatch)]
    [Uri(IanaMediaTypeUrlBase + ApplicationMediaTypeNames.JsonPatch)]
    // [Synonyms(ApplicationMediaTypeNames.JsonPatch, ApplicationMediaTypeNames.Base + "/patch+json")]
    JsonPatch,

    /// <summary>A Personal Information Exchange file.</summary>
    /// <value><inheritdoc cref="ApplicationMediaTypeNames.Pkcs12"/></value>
    /// <seealso cref="ApplicationMediaTypeNames.Pkcs12"/>
    [Display(
        Name = ApplicationMediaTypeNames.Pkcs12,
        Description = "A Personal Information Exchange file",
        GroupName = ApplicationMediaTypeNames.Base
    )]
    [EnumMember(Value = ApplicationMediaTypeNames.Pkcs12)]
    [Uri(IanaMediaTypeUrlBase + ApplicationMediaTypeNames.Pkcs12)]
    Pkcs12,

    /// <summary>A JavaScript file.</summary>
    /// <value><inheritdoc cref="ApplicationMediaTypeNames.JavaScript"/></value>
    /// <seealso cref="ApplicationMediaTypeNames.JavaScript"/>
    [Display(
        Name = ApplicationMediaTypeNames.JavaScript,
        Description = "A JavaScript file",
        GroupName = ApplicationMediaTypeNames.Base
    )]
    [EnumMember(Value = ApplicationMediaTypeNames.JavaScript)]
    [Uri(IanaMediaTypeUrlBase + ApplicationMediaTypeNames.JavaScript)]
    // [Synonyms(ApplicationMediaTypeNames.JsonPatch, TextMediaTypeNames.JavaScript)]
    JavaScript
}
