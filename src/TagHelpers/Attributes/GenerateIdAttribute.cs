/*
 * GenerateIdAttribute.cs
 *
 *   Created: 2024-49-15T16:49:03-05:00
 *   Modified: 2024-59-15T16:59:25-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.TagHelpers.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class GenerateIdAttribute(string prefix, bool renderIdAttribute = true) : Attribute
{
    private string _id;

public string Prefix { get; set; } = prefix;

public bool RenderIdAttribute { get; set; } = renderIdAttribute;

public string Id => _id ??= Prefix + guid.NewGuid().ToString("N");
}
