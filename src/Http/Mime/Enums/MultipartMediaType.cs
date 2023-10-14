/*
 * MultipartMediaTypeNames.cs
 *
 *   Created: 2022-12-31-01:37:38
 *   Modified: 2022-12-31-01:37:38
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Mime.Enums;

using System.Runtime.Serialization;

[GenerateEnumerationRecordStruct("MultipartMediaType", "Dgmjr.Mime")]
public enum MultipartMediaType
{
    /// <inheritdoc cref="MultipartMediaTypeNames.Base"/>
    [Display(
        Name = MultipartMediaTypeNames.Base,
        Description = nameof(MultipartMediaTypeNames.Base)
    )]
    [Uri(IanaMediaTypeUrlBase + MediaTypes_xhtml + "#multipart")]
    Base = 0,

    /// <inheritdoc cref="MultipartMediaTypeNames.Any"/>
    [Display(Name = MultipartMediaTypeNames.Any, Description = nameof(MultipartMediaTypeNames.Any))]
    [EnumMember(Value = MultipartMediaTypeNames.Any)]
    [Uri(IanaMediaTypeUrlBase + MediaTypes_xhtml + "#multipart-*")]
    Any = int.MaxValue,

    /// <inheritdoc cref="MultipartMediaTypeNames.Alternative"/>
    [Display(
        Name = MultipartMediaTypeNames.Alternative,
        Description = nameof(MultipartMediaTypeNames.Alternative)
    )]
    [EnumMember(Value = MultipartMediaTypeNames.Alternative)]
    Alternative,

    /// <inheritdoc cref="MultipartMediaTypeNames.Appledouble"/>
    [Display(
        Name = MultipartMediaTypeNames.Appledouble,
        Description = nameof(MultipartMediaTypeNames.Appledouble)
    )]
    [EnumMember(Value = MultipartMediaTypeNames.Appledouble)]
    Appledouble,

    /// <inheritdoc cref="MultipartMediaTypeNames.Digest"/>
    [Display(
        Name = MultipartMediaTypeNames.Digest,
        Description = nameof(MultipartMediaTypeNames.Digest)
    )]
    [EnumMember(Value = MultipartMediaTypeNames.Digest)]
    Digest,

    /// <inheritdoc cref="MultipartMediaTypeNames.Encrypted"/>
    [Display(
        Name = MultipartMediaTypeNames.Encrypted,
        Description = nameof(MultipartMediaTypeNames.Encrypted)
    )]
    [EnumMember(Value = MultipartMediaTypeNames.Encrypted)]
    Encrypted,

    /// <inheritdoc cref="MultipartMediaTypeNames.FormData"/>
    [Display(
        Name = MultipartMediaTypeNames.FormData,
        Description = nameof(MultipartMediaTypeNames.FormData)
    )]
    [EnumMember(Value = MultipartMediaTypeNames.FormData)]
    FormData,

    /// <inheritdoc cref="MultipartMediaTypeNames.HeaderSet"/>
    [Display(
        Name = MultipartMediaTypeNames.HeaderSet,
        Description = nameof(MultipartMediaTypeNames.HeaderSet)
    )]
    [EnumMember(Value = MultipartMediaTypeNames.HeaderSet)]
    HeaderSet,

    /// <inheritdoc cref="MultipartMediaTypeNames.Mixed"/>
    [Display(
        Name = MultipartMediaTypeNames.Mixed,
        Description = nameof(MultipartMediaTypeNames.Mixed)
    )]
    [EnumMember(Value = MultipartMediaTypeNames.Mixed)]
    Mixed,

    /// <inheritdoc cref="MultipartMediaTypeNames.Parallel"/>
    [Display(
        Name = MultipartMediaTypeNames.Parallel,
        Description = nameof(MultipartMediaTypeNames.Parallel)
    )]
    [EnumMember(Value = MultipartMediaTypeNames.Parallel)]
    Parallel,

    /// <inheritdoc cref="MultipartMediaTypeNames.Related"/>
    [Display(
        Name = MultipartMediaTypeNames.Related,
        Description = nameof(MultipartMediaTypeNames.Related)
    )]
    [EnumMember(Value = MultipartMediaTypeNames.Related)]
    Related,

    /// <inheritdoc cref="MultipartMediaTypeNames.Report"/>
    [Display(
        Name = MultipartMediaTypeNames.Report,
        Description = nameof(MultipartMediaTypeNames.Report)
    )]
    [EnumMember(Value = MultipartMediaTypeNames.Report)]
    Report,

    /// <inheritdoc cref="MultipartMediaTypeNames.Signed"/>
    [Display(
        Name = MultipartMediaTypeNames.Signed,
        Description = nameof(MultipartMediaTypeNames.Signed)
    )]
    [EnumMember(Value = MultipartMediaTypeNames.Signed)]
    Signed,

    /// <inheritdoc cref="MultipartMediaTypeNames.VoiceMessage"/>
    [Display(
        Name = MultipartMediaTypeNames.VoiceMessage,
        Description = nameof(MultipartMediaTypeNames.VoiceMessage)
    )]
    [EnumMember(Value = MultipartMediaTypeNames.VoiceMessage)]
    VoiceMessage,

    /// <inheritdoc cref="MultipartMediaTypeNames.XMixedReplace"/>
    [Display(
        Name = MultipartMediaTypeNames.XMixedReplace,
        Description = nameof(MultipartMediaTypeNames.XMixedReplace)
    )]
    [EnumMember(Value = MultipartMediaTypeNames.XMixedReplace)]
    XMixedReplace
}
