/*
 * ContextClassAttribute.cs
 *
 *   Created: 2024-43-15T16:43:50-05:00
 *   Modified: 2024-59-15T16:59:05-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.TagHelpers.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class ContextClassAttribute : Attribute
{
    public string Key { get; set; }

    public Type Type { get; set; }

    public ContextClassAttribute(type type)
    {
        Type = type;
    }

    public ContextClassAttribute()
    {
    }

    public ContextClassAttribute(string key)
    {
        Key = key;
    }
}
