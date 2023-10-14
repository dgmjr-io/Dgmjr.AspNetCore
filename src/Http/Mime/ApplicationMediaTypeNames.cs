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

public static class ApplicationMediaTypeNames
{
    /// <inheritdoc cref="Enums.ApplicationMediaType.Base" />
    public const string Base = "application";

    ///  <inheritdoc cref="Enums.ApplicationMediaType.Any" />
    public const string Any = Base + "/" + "*";

    /// <inheritdoc cref="Enums.ApplicationMediaType.OctetStream" />
    public const string OctetStream = Base + "/" + "octet-stream";

    /// <inheritdoc cref="Enums.ApplicationMediaType.Pdf" />
    public const string Pdf = Base + "/" + "pdf";

    /// <inheritdoc cref="Enums.ApplicationMediaType.Rtf" />
    public const string Rtf = Base + "/" + "rtf";

    /// <inheritdoc cref="Enums.ApplicationMediaType.Soap" />
    public const string Soap = Base + "/" + "soap+xml";

    /// <inheritdoc cref="Enums.ApplicationMediaType.Xml" />
    public const string Xml = Base + "/" + "xml";

    /// <inheritdoc cref="Enums.ApplicationMediaType.Zip" />
    public const string Zip = Base + "/" + "zip";

    /// <inheritdoc cref="Enums.ApplicationMediaType.Json" />
    public const string Json = Base + "/" + "json";

    /// <inheritdoc cref="Enums.ApplicationMediaType.FormUrlEncoded" />
    public const string FormUrlEncoded = Base + "/" + "x-www-formurlencoded";

    /// <inheritdoc  cref="Enums.ApplicationMediaType.ProblemJson" />
    public const string ProblemJson = Base + "/" + "json+problem";

    /// <inheritdoc  cref="Enums.ApplicationMediaType.JsonPatch" />
    public const string JsonPatch = Base + "/" + "json-patch+json";

    /// <inheritdoc cref="Enums.ApplicationMediaType.Bson" />
    public const string Bson = Base + "/" + "bson";

    /// <inheritdoc cref="Enums.ApplicationMediaType.MessagePack" />
    public const string MessagePack = Base + "/" + "x-msgpack";

    /// <inheritdoc cref="Enums.ApplicationMediaType.Example" />
    public const string Example = Base + "/" + "example";
}
