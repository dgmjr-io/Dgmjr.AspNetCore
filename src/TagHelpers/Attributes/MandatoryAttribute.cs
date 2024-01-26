/*
 * MandatoryAttribute.cs
 *
 *   Created: 2024-40-15T16:40:24-05:00
 *   Modified: 2024-59-15T16:59:33-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.TagHelpers.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class MandatoryAttribute : Attribute
{

}
