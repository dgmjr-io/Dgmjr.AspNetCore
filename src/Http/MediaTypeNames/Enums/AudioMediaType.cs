/*
 * AudioMediaTypeNames.cs
 *
 *   Created: 2022-12-31-01:11:28
 *   Modified: 2022-12-31-01:11:28
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace System.Net.Mime.MediaTypes.Enums;

using System.Runtime.Serialization;

[GenerateEnumerationRecordStruct("AudioMediaType", "System.Net.Mime.MediaTypes")]
public enum AudioMediaType
{
    [Display(Name = AudioMediaTypeNames.Any, Description = nameof(Any))]
    [EnumMember(Value = AudioMediaTypeNames.Any)]
    Any,

    [Display(Name = AudioMediaTypeNames.Base, Description = nameof(Base))]
    [EnumMember(Value = AudioMediaTypeNames.Base)]
    Base,

    [Display(Name = AudioMediaTypeNames.Vorbis, Description = nameof(Vorbis))]
    [EnumMember(Value = AudioMediaTypeNames.Vorbis)]
    Vorbis,

    [Display(Name = AudioMediaTypeNames.Ogg, Description = nameof(Ogg))]
    [EnumMember(Value = AudioMediaTypeNames.Ogg)]
    Ogg,

    [Display(Name = AudioMediaTypeNames.Mp3, Description = nameof(Mp3))]
    [EnumMember(Value = AudioMediaTypeNames.Mp3)]
    Mp3,

    [Display(Name = AudioMediaTypeNames.Mp4, Description = nameof(Mp4))]
    [EnumMember(Value = AudioMediaTypeNames.Mp4)]
    Mp4,

    [Display(Name = AudioMediaTypeNames.Mpeg, Description = nameof(Mpeg))]
    [EnumMember(Value = AudioMediaTypeNames.Mpeg)]
    Mpeg,

    [Display(Name = AudioMediaTypeNames.Mpeg4, Description = nameof(Mpeg4))]
    [EnumMember(Value = AudioMediaTypeNames.Mpeg4)]
    Mpeg4,

    [Display(Name = AudioMediaTypeNames.Mpeg4Generic, Description = nameof(Mpeg4Generic))]
    [EnumMember(Value = AudioMediaTypeNames.Mpeg4Generic)]
    Mpeg4Generic
}
