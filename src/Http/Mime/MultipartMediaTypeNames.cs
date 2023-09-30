/*
 * MultipartMediaTypeName.cs
 *
 *   Created: 2023-03-18-06:53:16
 *   Modified: 2023-03-18-06:53:16
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Mime;

public static class MultipartMediaTypeNames
{
    /// <summary>The base media type for multipart media types.</summary>
    /// <value>multipart</value>
    public const string Base = "multipart";

    /// <summary>The media type for any multipart media type.</summary>
    /// <value><inheritdoc cref="Base" path="/value" />/*</value>
    public const string Any = Base + "/" + "*";

    /// <summary>The media type for <inheritdoc cref="Alternative" path="/value" />.</summary>
    /// <value><inheritdoc cref="Base" path="/value" />/alternative</value>
    public const string Alternative = Base + "/" + "alternative";

    /// <summary>The media type for <inheritdoc cref="Appledouble" path="/value" />.</summary>
    /// <value><inheritdoc cref="Base" path="/value" />/appledouble</value>
    public const string Appledouble = Base + "/" + "appledouble";

    /// <summary>The media type for <inheritdoc cref="Digest" path="/value" />.</summary>
    /// <value><inheritdoc cref="Base" path="/value" />/digest</value>
    public const string Digest = Base + "/" + "digest";

    /// <summary>The media type for <inheritdoc cref="Encrypted" path="/value" />.</summary>
    /// <value><inheritdoc cref="Base" path="/value" />/encrypted</value>
    public const string Encrypted = Base + "/" + "encrypted";

    /// <summary>The media type for <inheritdoc cref="FormData" path="/value" />.</summary>
    /// <value><inheritdoc cref="Base" path="/value" />/form-data</value>
    public const string FormData = Base + "/" + "form-data";

    /// <summary>The media type for <inheritdoc cref="HeaderSet" path="/value" />.</summary>
    /// <value><inheritdoc cref="Base" path="/value" />/header-set</value>
    public const string HeaderSet = Base + "/" + "header-set";

    /// <summary>The media type for <inheritdoc cref="Mixed" path="/value" />.</summary>
    /// <value><inheritdoc cref="Base" path="/value" />/mixed</value>
    public const string Mixed = Base + "/" + "mixed";

    /// <summary>The media type for <inheritdoc cref="Parallel" path="/value" />.</summary>
    /// <value><inheritdoc cref="Base" path="/value" />/parallel</value>
    public const string Parallel = Base + "/" + "parallel";

    /// <summary>The media type for <inheritdoc cref="Related" path="/value" />.</summary>
    /// <value><inheritdoc cref="Base" path="/value" />/related</value>
    public const string Related = Base + "/" + "related";

    /// <summary>The media type for <inheritdoc cref="Report" path="/value" />.</summary>
    /// <value><inheritdoc cref="Base" path="/value" />/report</value>
    public const string Report = Base + "/" + "report";

    /// <summary>The media type for <inheritdoc cref="Signed" path="/value" />.</summary>
    /// <value><inheritdoc cref="Base" path="/value" />/signed</value>
    public const string Signed = Base + "/" + "signed";

    /// <summary>The media type for <inheritdoc cref="VoiceMessage" path="/value" />.</summary>
    /// <value><inheritdoc cref="Base" path="/value" />/voice-message</value>
    public const string VoiceMessage = Base + "/" + "voice-message";

    /// <summary>The media type for <inheritdoc cref="XMixedReplace" path="/value" />.</summary>
    /// <value><inheritdoc cref="Base" path="/value" />/x-mixed-replace</value>
    public const string XMixedReplace = Base + "/" + "x-mixed-replace";
}
