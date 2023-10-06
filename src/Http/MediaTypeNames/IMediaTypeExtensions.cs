/*
 * MimeMediaType.cs
 *
 *   Created: 2023-01-06-06:35:11
 *   Modified: 2023-01-06-06:35:11
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace System.Net.Mime.MediaTypes;

using System.Linq;

public static class IMediaTypeExtensions
{
    /// <summary>
    /// Determines whether the media type is a wildcard. This is determined by looking for a'*'character at the name of the media type.
    /// </summary>
    /// <param name="IMediaType"></param>
    /// <returns>true if the media type is a wildcard ; otherwise false. For example if the media type is text / plain ; charset = utf - 8</returns>
    public static bool IsWildcard(this IMediaType @this) =>
        @this.DisplayName.StartsWith("*") || @this.DisplayName.EndsWith("*");

    public static bool PrimaryIsWilcard(this IMediaType @this) => @this.DisplayName.StartsWith("*");

    public static string GetPrimaryType(this IMediaType @this) =>
        @this.DisplayName.Split('/').First();

    public static string GetSecondaryType(this IMediaType @this) =>
        @this.DisplayName.Split('/').Last();

    public static bool SecondaryIsWildcard(this IMediaType @this) =>
        @this.DisplayName.Split('/').Last().Contains("*");

    /// <summary>
    /// Determines whether the media type matches. This method is case sensitive. The name of the media type is compared with the name of the media type to determine whether it matches.
    /// </summary>
    /// <param name="IMediaType"></param>
    /// <param name="other">The other media type to compare. Must not be null</param>
    /// <returns>true if the media types match false if they don't or if there is a mismatch ( such as a duplicate media type</returns>
    public static bool Matches(this IMediaType @this, IMediaType other) =>
        @this.IsWildcard()
            && other.DisplayName.StartsWith(@this.GetPrimaryType(), OrdinalIgnoreCase)
        || other.IsWildcard()
            && @this.DisplayName.StartsWith(other.GetPrimaryType(), OrdinalIgnoreCase)
        || @this.PrimaryIsWilcard()
            && @this.GetSecondaryType().EndsWith(other.GetSecondaryType(), OrdinalIgnoreCase)
        || @other.PrimaryIsWilcard()
            && @other.GetSecondaryType().EndsWith(@this.GetSecondaryType(), OrdinalIgnoreCase)
        || @this.PrimaryIsWilcard()
            && @this.GetSecondaryType().EndsWith(other.GetSecondaryType(), OrdinalIgnoreCase)
        || @other.SecondaryIsWildcard()
            && @other.GetSecondaryType().EndsWith(@this.GetSecondaryType(), OrdinalIgnoreCase)
        || @this.SecondaryIsWildcard()
            && @this.GetSecondaryType().EndsWith(other.GetSecondaryType(), OrdinalIgnoreCase)
        || @this.DisplayName.Equals(other.DisplayName);

    public static string? GetPlusType(this IMediaType @this)
    {
        var plusType = @this.DisplayName.Split("+").Last();
        return plusType != @this.DisplayName ? plusType : default;
    }

    /// <summary>
    /// Determines whether the specified media type matches the specified. This method is equivalent to the method of the same name in C#
    /// </summary>
    /// <param name="IMediaType"></param>
    /// <param name="other">The name of the media type to compare.</param>
    /// <returns>true matches ; otherwise false. This method returns false if is null or does not match the string representation</returns>
    public static bool Matches(this IMediaType @this, string other) =>
        @this.Matches(new TempMediaType(other));

    public static IMediaType ToMediaType(this string s) => new TempMediaType { DisplayName = s };

    public static bool IsText(this IMediaType mediaType) =>
        mediaType.Matches("text/*")
        || mediaType.GetPlusType() is "xml" or "json" or "xml" or "text";
}
