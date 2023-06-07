/*
 * UnRefYaml.cs
 *
 *   Created: 2023-05-01-12:03:38
 *   Modified: 2023-05-01-12:03:38
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.UnRef;
using System.ComponentModel;
using global::Json.More;
using Yaml2JsonNode;

using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

public static class Yaml
{
    public static readonly IDeserializer Deserializer = new DeserializerBuilder()
        .WithNamingConvention(CamelCaseNamingConvention.Instance)
        .Build();
    public static readonly ISerializer Serializer = new SerializerBuilder()
        .JsonCompatible()
        .Build();

    public static JDoc ToJson(this TextReader yml)
    {
        var yamlStream = new YamlStream();
        yamlStream.Load(yml);
        return yamlStream.ToJsonDocument();
    }

    public static YamlDocument DeserializeYaml(this TextReader yml) =>
        yml.ReadToEnd().DeserializeYaml();

    public static YamlDocument DeserializeYaml(this string yml)
    {
        var yamlStream = new YamlStream();
        yamlStream.Load(new StringReader(yml));
        var rootNode = (YamlMappingNode)yamlStream.Documents[0].RootNode;
        return new YamlDocument(rootNode);
    }

    public static YamlDocument ToYaml(this JDoc doc) => doc.ToString().DeserializeYaml();

    public static JDoc ToJson(this YamlDocument yml) => Serializer.Serialize(yml).ToJson();

    public static JDoc ToJson(this string yml) => ToJson(new StringReader(yml));

    public static YamlDocument UnRef(this TextReader yaml) => yaml.ToJson().UnRef().ToYaml();

    public static YamlDocument UnRef(this string yaml) => yaml.UnRef();

    public static YamlDocument UnRef(this YamlDocument yaml) =>
        yaml.ToJsonDocument().UnRef().ToYaml();
}
