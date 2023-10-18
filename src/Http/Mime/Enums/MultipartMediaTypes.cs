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

[GenerateEnumerationRecordStruct("Multipart", "Dgmjr.Mime")]
public enum MultipartMediaTypes : int
{
    /// <inheritdoc cref="MultipartMediaTypeNames.Any"/>
    [Display(Name = MultipartMediaTypeNames.Any, Description = nameof(MultipartMediaTypeNames.Any))]
    [EnumMember(Value = MultipartMediaTypeNames.Any)]
    [Uri(IanaMediaTypeUrlBase + "#multipart-*")]
    Any = int.MaxValue,

    /// <inheritdoc cref="MultipartMediaTypeNames.Base"/>
    [Display(
        Name = MultipartMediaTypeNames.Base,
        Description = nameof(MultipartMediaTypeNames.Base)
    )]
    [Uri(IanaMediaTypeUrlBase + "#multipart")]
    Base = 0,

    /// <inheritdoc cref="MultipartMediaTypeNames.Alternative"/>
    [Display(
        Name = MultipartMediaTypeNames.Alternative,
        Description = nameof(MultipartMediaTypeNames.Alternative)
    )]
    [Uri(RfcUrlBase + "#section-5.1.4")]
    [EnumMember(Value = MultipartMediaTypeNames.Alternative)]
    Alternative,

    /// <inheritdoc cref="MultipartMediaTypeNames.Appledouble"/>
    [Display(
        Name = MultipartMediaTypeNames.Appledouble,
        Description = nameof(MultipartMediaTypeNames.Appledouble)
    )]
    [Uri(IanaMediaTypeUrlBase + MultipartMediaTypeNames.Appledouble)]
    [EnumMember(Value = MultipartMediaTypeNames.Appledouble)]
    Appledouble,

    /// <inheritdoc cref="MultipartMediaTypeNames.Digest"/>
    [Display(
        Name = MultipartMediaTypeNames.Digest,
        Description = nameof(MultipartMediaTypeNames.Digest)
    )]
    [Uri(RfcUrlBase + "#section-5.1.5")]
    [EnumMember(Value = MultipartMediaTypeNames.Digest)]
    Digest,

    /// <inheritdoc cref="MultipartMediaTypeNames.Encrypted"/>
    [Display(
        Name = MultipartMediaTypeNames.Encrypted,
        Description = nameof(MultipartMediaTypeNames.Encrypted)
    )]
    [Uri(IanaMediaTypeUrlBase + MultipartMediaTypeNames.Encrypted)]
    [EnumMember(Value = MultipartMediaTypeNames.Encrypted)]
    Encrypted,

    /// <inheritdoc cref="MultipartMediaTypeNames.FormData"/>
    [Display(
        Name = MultipartMediaTypeNames.FormData,
        Description = nameof(MultipartMediaTypeNames.FormData)
    )]
    [Uri(IanaMediaTypeUrlBase + MultipartMediaTypeNames.FormData)]
    [EnumMember(Value = MultipartMediaTypeNames.FormData)]
    FormData,

    /// <inheritdoc cref="MultipartMediaTypeNames.HeaderSet"/>
    [Display(
        Name = MultipartMediaTypeNames.HeaderSet,
        Description = nameof(MultipartMediaTypeNames.HeaderSet)
    )]
    [Uri(IanaMediaTypeUrlBase + MultipartMediaTypeNames.HeaderSet)]
    [EnumMember(Value = MultipartMediaTypeNames.HeaderSet)]
    HeaderSet,

    /// <inheritdoc cref="MultipartMediaTypeNames.Mixed"/>
    [Display(
        Name = MultipartMediaTypeNames.Mixed,
        Description = nameof(MultipartMediaTypeNames.Mixed)
    )]
    [Uri(RfcUrlBase + "#section-5.1.3")]
    [EnumMember(Value = MultipartMediaTypeNames.Mixed)]
    Mixed,

    /// <inheritdoc cref="MultipartMediaTypeNames.Parallel"/>
    [Display(
        Name = MultipartMediaTypeNames.Parallel,
        Description = nameof(MultipartMediaTypeNames.Parallel)
    )]
    [Uri(RfcUrlBase + "#section-5.1.6")]
    [EnumMember(Value = MultipartMediaTypeNames.Parallel)]
    Parallel,

    /// <inheritdoc cref="MultipartMediaTypeNames.Related"/>
    [Display(
        Name = MultipartMediaTypeNames.Related,
        Description = nameof(MultipartMediaTypeNames.Related)
    )]
    [Uri(IanaMediaTypeUrlBase + MultipartMediaTypeNames.Related)]
    [EnumMember(Value = MultipartMediaTypeNames.Related)]
    Related,

    /// <inheritdoc cref="MultipartMediaTypeNames.Report"/>
    [Display(
        Name = MultipartMediaTypeNames.Report,
        Description = nameof(MultipartMediaTypeNames.Report)
    )]
    [Uri(IanaMediaTypeUrlBase + MultipartMediaTypeNames.Report)]
    [EnumMember(Value = MultipartMediaTypeNames.Report)]
    Report,

    /// <inheritdoc cref="MultipartMediaTypeNames.Signed"/>
    [Display(
        Name = MultipartMediaTypeNames.Signed,
        Description = nameof(MultipartMediaTypeNames.Signed)
    )]
    [Uri(IanaMediaTypeUrlBase + MultipartMediaTypeNames.Signed)]
    [EnumMember(Value = MultipartMediaTypeNames.Signed)]
    Signed,

    /// <inheritdoc cref="MultipartMediaTypeNames.VoiceMessage"/>
    [Display(
        Name = MultipartMediaTypeNames.VoiceMessage,
        Description = nameof(MultipartMediaTypeNames.VoiceMessage)
    )]
    [Uri(IanaMediaTypeUrlBase + MultipartMediaTypeNames.VoiceMessage)]
    [EnumMember(Value = MultipartMediaTypeNames.VoiceMessage)]
    VoiceMessage,

    /// <inheritdoc cref="MultipartMediaTypeNames.XMixedReplace"/>
    [Display(
        Name = MultipartMediaTypeNames.XMixedReplace,
        Description = nameof(MultipartMediaTypeNames.XMixedReplace)
    )]
    [Uri(IanaMediaTypeUrlBase + MultipartMediaTypeNames.XMixedReplace)]
    [EnumMember(Value = MultipartMediaTypeNames.XMixedReplace)]
    XMixedReplace
}
