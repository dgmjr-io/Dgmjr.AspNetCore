/*
 * AnyMediaType.cs
 *
 *   Created: 2023-10-05-10:43:03
 *   Modified: 2023-10-05-10:43:03
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Mime.Enums;

[GenerateEnumerationRecordStruct("AnyMediaType", "Dgmjr.Mime")]
public enum AnyMediaTypes : byte
{
    [Display(Name = "*/*")]
    Any = byte.MaxValue
}
