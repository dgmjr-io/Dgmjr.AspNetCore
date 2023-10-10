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

namespace System.Net.Mime.MediaTypes.Enums;

[GenerateEnumerationRecordStruct("AnyMediaType", "System.Net.Mime.MediaTypes")]
public enum AnyMediaType
{
    [Display(Name = "*/*")]
    Any
}
