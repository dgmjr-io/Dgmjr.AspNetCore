/*
 * CopyToOutputAttribute.cs
 *
 *   Created: 2024-40-15T16:40:24-05:00
 *   Modified: 2024-58-15T16:58:59-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.TagHelpers;

[AttributeUsage(AttributeTargets.Property)]
public class CopyToOutputAttribute : Attribute
{
    public string Prefix { get; set; }

    public string Suffix { get; set; }

    public string OutputAttributeName { get; set; }

    public bool CopyIfValueIsNull { get; set; }

    public CopyToOutputAttribute()
    {
    }

    public CopyToOutputAttribute(bool copyIfValueIsNull)
    {
        CopyIfValueIsNull = copyIfValueIsNull;
    }

    public CopyToOutputAttribute(string outputAttributeName)
    {
        OutputAttributeName = outputAttributeName;
    }

    public CopyToOutputAttribute(bool copyIfValueIsNull, string outputAttributeName)
    {
        OutputAttributeName = outputAttributeName;
        CopyIfValueIsNull = copyIfValueIsNull;
    }

    public CopyToOutputAttribute(string prefix, string suffix)
    {
        Prefix = prefix;
        Suffix = suffix;
    }

    public CopyToOutputAttribute(bool copyIfValueIsNull, string prefix, string suffix)
    {
        Prefix = prefix;
        Suffix = suffix;
        CopyIfValueIsNull = copyIfValueIsNull;
    }

    public CopyToOutputAttribute(bool copyIfValueIsNull, string outputAttributeName, string prefix, string suffix)
    {
        Prefix = prefix;
        Suffix = suffix;
        OutputAttributeName = outputAttributeName;
        CopyIfValueIsNull = copyIfValueIsNull;
    }

    public CopyToOutputAttribute(string outputAttributeName, string prefix, string suffix)
    {
        Prefix = prefix;
        Suffix = suffix;
        OutputAttributeName = outputAttributeName;
    }
}
