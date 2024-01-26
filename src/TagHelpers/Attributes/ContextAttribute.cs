/*
 * ContextAttribute.cs
 *
 *   Created: 2024-41-15T17:41:41-05:00
 *   Modified: 2024-41-15T17:41:42-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.TagHelpers.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class ContextAttribute : Attribute
{
    public bool UseInherited { get; set; } = true;

    public bool RemoveContext { get; set; }

    public string Key { get; set; }

    public ContextAttribute() { }

    public ContextAttribute(string key)
    {
        Key = key;
    }
}
