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

public record struct TempMediaType : IMediaType, IHaveAUriString
{
    public TempMediaType(string name)
    {
        DisplayName = name;
    }

    private static readonly MD5 MD5 = System.Security.Cryptography.MD5.Create();
    public string[] Synonyms
    {
        get => Empty<string>();
        init { }
    }
    Uri IHaveAUri.Uri => new(UriString);
    object IIdentifiable.Id => Id;
    public int Id => 0;
    public string UriString => "urn:temp:media-type:" + DisplayName.ToKebabCase();
    public string GuidString => MD5.ComputeHash(UriString.ToUTF8Bytes()).ToHexString();
    public guid Guid => new(GuidString);
    public string Description => Name;
    public string GroupName => Name;
    public string ShortName => Name;
    public string Name => DisplayName;
    public string DisplayName { get; set; } = default!;
    public int Order => 0;
    public string Prompt => "";
}
