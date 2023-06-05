/*
 * UnRefJson.cs
 *
 *   Created: 2023-05-01-12:16:25
 *   Modified: 2023-05-01-12:16:57
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.UnRef;

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Nodes;
using global::Json.Path;
using global::Json.Schema;
using global::Json.More;

public static class Json
{
    public static JNode? ToJsonNode(this JDoc doc) => JNode.Parse(doc.ToString());

    public static JDoc ToJsonDocument(this JNode node) => JDoc.Parse(node.ToString());

    public static JDoc UnRef(this JDoc schemaDoc)
    {
        Dictionary<string, JElem> refMap = new();

        // First pass to find all "$ref" properties and add them to a dictionary
        schemaDoc.RootElement.FindRefs(refMap, schemaDoc);

        // Second pass to replace all "$ref" properties with their actual definitions
        schemaDoc.RootElement.ResolveRefs(refMap, schemaDoc);

        return schemaDoc;
    }

    private static void FindRefs(this JElem node, Dictionary<string, JElem> refMap, JDoc doc)
    {
        if (node.ValueKind == JsonValueKind.Object)
        {
            foreach (JProp property in node.EnumerateObject())
            {
                if (property.Name == "$ref")
                {
                    string? refName = property.Value.GetString();
                    if (!refMap.ContainsKey(refName))
                    {
                        refMap[refName] = ResolveRef(refName, doc);
                    }
                }
                else
                {
                    property.Value.FindRefs(refMap, doc);
                }
            }
        }
        else if (node.ValueKind == JsonValueKind.Array)
        {
            foreach (JElem item in node.EnumerateArray())
            {
                item.FindRefs(refMap, doc);
            }
        }
    }

    private static void ResolveRefs(this JElem node, Dictionary<string, JElem> refMap, JDoc doc)
    {
        if (node.ValueKind == JsonValueKind.Object)
        {
            var newElement = new JElem();
            foreach (JProp property in node.EnumerateObject().ToList())
            {
                if (property.Name == "$ref")
                {
                    string? refName = property.Value.GetString();
                    if (refMap.ContainsKey(refName))
                    {
                        JElem refNode = refMap[refName].Clone();
                        refNode.ResolveRefs(refMap, doc);

                        newElement.AsNode().AsObject().Add(property.Name, refNode.AsNode());
                    }
                }
                else
                {
                    property.Value.ResolveRefs(refMap, doc);
                }
            }
        }
        else if (node.ValueKind == JsonValueKind.Array)
        {
            foreach (JElem item in node.EnumerateArray())
            {
                item.ResolveRefs(refMap, doc);
            }
        }
    }

    private static JElem ResolveRef(string refName, JDoc doc)
    {
        var schema = JsonSchema.FromText(doc.ToString());
        var definitions = schema.GetDefinitions();
        definitions = definitions
            .Concat(schema.GetDefs())
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        var definition = definitions[refName];
        return definition.ToJsonDocument().RootElement;
    }
}
