/* 
 * ExampleMediaType.cs
 * 
 *   Created: 2023-03-18-06:54:56
 *   Modified: 2023-03-18-06:54:57
 * 
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *   
 *   Copyright © 2022-2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace System.Net.Mime.MediaTypes.Enums;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

[GenerateEnumerationRecordStruct("ExampleMediaType", "System.Net.Mime.MediaTypes")]
public enum ExampleMediaType
{
    /// <inheritdoc cref="ExampleMediaTypeNames.Any"/>
    [Display(Name = ExampleMediaTypeNames.Any, Description = nameof(Any))]
    [EnumMember(Value = ExampleMediaTypeNames.Any)]
    Any,

    /// <inheritdoc cref="ExampleMediaTypeNames.Base"/>
    Base,

    /// <inheritdoc cref="ExampleMediaTypeNames.Example"/>
    Example
}
