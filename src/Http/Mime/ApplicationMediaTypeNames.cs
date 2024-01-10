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
    /// <value>application</value>
    public const string Base = "application";

    /// <value><inheritdoc cref="Base" />/*</value>
    public const string Any = Base + "/*";

    /// <value><inheritdoc cref="Base" />/octet-stream</value>
    public const string OctetStream = Base + "/octet-stream";

    /// <value><inheritdoc cref="Base" />/pdf</value>
    public const string Pdf = Base + "/pdf";

    /// <value><inheritdoc cref="Base" />/rtf</value>
    public const string Rtf = Base + "/rtf";

    /// <value><inheritdoc cref="Base" />/soap+xml</value>
    public const string Soap = Base + "/soap+xml";

    /// <value><inheritdoc cref="Base" />/xml</value>
    public const string Xml = Base + "/xml";

    /// <value><inheritdoc cref="Base" />/zip</value>
    public const string Zip = Base + "/zip";

    /// <value><inheritdoc cref="Base" />/json</value>
    public const string Json = Base + "/json";

    /// <value><inheritdoc cref="Base" />/x-www-formurlencoded</value>
    public const string FormUrlEncoded = Base + "/x-www-formurlencoded";

    /// <value><inheritdoc cref="Base" />/problem+json</value>
    public const string ProblemJson = Base + "/problem+json";

    /// <value><inheritdoc cref="Base" />/problem+xml</value>
    public const string ProblemXml = Base + "/problem+xml";

    /// <value><inheritdoc cref="Base" />/json-patch+json</value>
    public const string JsonPatch = Base + "/json-patch+json";

    /// <value><inheritdoc cref="Base" />/bson</value>
    public const string Bson = Base + "/bson";

    /// <value><inheritdoc cref="Base" />/x-msgpack</value>
    public const string MessagePack = Base + "/x-msgpack";

    /// <value><inheritdoc cref="Base" />/example</value>
    public const string Example = Base + "/example";

    /// <value><inheritdoc cref="Base" />/pkcs12</value>
    public const string Pkcs12 = Base + "/pkcs12";

    /// <value><inheritdoc cref="Base" />/javascript</value>
    public const string JavaScript = Base + "/javascript";

    /// <value><inheritdoc cref="MediaType.Application.DisplayName" path="/value" />/openapi<inheritdoc cref="Mime.Suffixes.Json.DisplayName" path="/value" /></value>
    public const string OpenApiJson = $"{MediaType.Application.DisplayName}/openapi{Mime.Suffixes.Json.DisplayName}";

    /// <value><inheritdoc cref="MediaType.Application.DisplayName" path="/value" />/openapi<inheritdoc cref="Mime.Suffixes.Yaml.DisplayName" path="/value" /></value>
    public const string OpenApiYaml = $"{MediaType.Application.DisplayName}/openapi{Mime.Suffixes.Yaml.DisplayName}";

    /// <value><inheritdoc cref="OpenApiJson" path="/value" />; version=2.x</value>
    public const string OpenApiV2Json = $"{OpenApiJson}; version=2.x";

    /// <value><inheritdoc cref="OpenApiYaml" path="/value" />; version=2.x</value>
    public const string OpenApiV2Yaml = $"{OpenApiYaml}; version=2.x";

    /// <value><inheritdoc cref="OpenApiJson" path="/value" />; version=3.x</value>
    public const string OpenApiV3Json = $"{OpenApiJson}; version=3.x";

     /// <value><inheritdoc cref="OpenApiYaml" path="/value" />; version=3.x</value>
    public const string OpenApiV3Yaml = $"{OpenApiYaml}; version=3.x";
}
