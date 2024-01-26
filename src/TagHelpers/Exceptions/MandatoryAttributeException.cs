/*
 * MandatoryAttributeException.cs
 *
 *   Created: 2024-35-15T17:35:45-05:00
 *   Modified: 2024-35-15T17:35:45-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.TagHelpers.Exceptions;

public class MandatoryAttributeException : Exception
{
    public string Attribute { get; set; }

    public Type TagHelper { get; set; }

    public MandatoryAttributeException(string attribute)
        : base("The '" + attribute + "' attribute is mandatory and must be set.")
    {
        Attribute = attribute;
    }

    public MandatoryAttributeException(string attribute, type tagHelper)
        : base("The '" + attribute + "' attribute of the '" + tagHelper.Name + "' is mandatory and must be set.")
    {
        Attribute = attribute;
        TagHelper = tagHelper;
    }
}
