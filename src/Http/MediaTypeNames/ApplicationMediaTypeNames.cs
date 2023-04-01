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
namespace System.Net.Mime.MediaTypes;

public static class ApplicationMediaTypeNames
{
    /// <inheritdoc cref="ApplicationMediaTypesEnum.Base" />
    public const string Base = "application";

    ///  <inheritdoc cref="ApplicationMediaTypesEnum.Any" />
    public const string Any = Base + "/" + "*";

    /// <inheritdoc cref="ApplicationMediaTypesEnum.OctetStream" />
    public const string OctetStream = Base + "/" + "octet-stream";

    /// <inheritdoc cref="ApplicationMediaTypesEnum.Pdf" />
    public const string Pdf = Base + "/" + "pdf";

    /// <inheritdoc cref="ApplicationMediaTypesEnum.Rtf" />
    public const string Rtf = Base + "/" + "rtf";

    /// <inheritdoc cref="ApplicationMediaTypesEnum.Soap" />
    public const string Soap = Base + "/" + "soap+xml";

    /// <inheritdoc cref="ApplicationMediaTypesEnum.Xml" />
    public const string Xml = Base + "/" + "xml";

    /// <inheritdoc cref="ApplicationMediaTypesEnum.Zip" />
    public const string Zip = Base + "/" + "zip";

    /// <inheritdoc cref="ApplicationMediaTypesEnum.Json" />
    public const string Json = Base + "/" + "json";

    /// <inheritdoc cref="ApplicationMediaTypesEnum.FormUrlEncoded" />
    public const string FormUrlEncoded = Base + "/" + "x-www-formurlencoded";

    /// <inheritdoc  cref="ApplicationMediaTypesEnum.ProblemJson" />
    public const string ProblemJson = Base + "/" + "json+problem";

    /// <inheritdoc  cref="ApplicationMediaTypesEnum.JsonPatch" />
    public const string JsonPatch = Base + "/" + "json-patch+json";

    /// <inheritdoc cref="ApplicationMediaTypesEnum.Bson" />
    public const string Bson = Base + "/" + "bson";

    /// <inheritdoc cref="ApplicationMediaTypesEnum.MessagePack" />
    public const string MessagePack = Base + "/" + "x-msgpack";

    /// <inheritdoc cref="ApplicationMediaTypesEnum.Example" />
    public const string Example = Base + "/" + "example";
}

public partial record struct ApplicationMediaType : IMediaType { }
