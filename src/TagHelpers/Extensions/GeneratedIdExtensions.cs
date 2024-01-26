/*
 * GeneratedIdExtensions.cs
 *
 *   Created: 2024-16-16T00:16:23-05:00
 *   Modified: 2024-16-16T00:16:23-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using Dgmjr.AspNetCore.TagHelpers.Abstractions;

namespace Dgmjr.AspNetCore.TagHelpers.Extensions;

public static class GeneratedIdExtensions
{
    public static void CopyIdentifier<T>(this T tagHelper)
        where T : TagHelper
    {
        var ihagi = tagHelper as IHaveAGeneratedId;
        var iis = tagHelper as IHaveAWritableId<string>;
        if (ihagi is not null && iis is not null)
        {
            var generateIdAttribute = tagHelper
                .GetType()
                .GetTypeInfo()
                .GetCustomAttributes<GenerateIdAttribute>(inherit: true)
                .FirstOrDefault();
            if (IsNullOrEmpty(iis.Id) && generateIdAttribute?.RenderIdAttribute == true)
            {
                ihagi.GeneratedId = iis.Id;
                iis.Id = ihagi.GeneratedId;
            }
        }
    }

    public static void RenderIdentifier<T>(this T tagHelper, TagHelperOutput output)
        where T : IIdentifiable<string>
    {
        if (!IsNullOrEmpty(tagHelper.Id))
        {
            output.MergeAttribute("id", tagHelper.Id);
        }
    }
}
