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

namespace Dgmjr.Mime;

using Abstractions;

public readonly record struct TempMediaType(string Name) : IMediaType
{
    public string DisplayName { get; } = Name;
    private static readonly MD5 MD5 = MD5.Create();
    public string[] Synonyms
    {
        get => Empty<string>();
        init
        {
            /* do nothing */
        }
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
    public int Order => 0;
    public string Prompt => "";
}
