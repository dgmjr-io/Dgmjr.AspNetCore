/*
 * DownstreamApiOptionsConfigurator.cs
 *
 *   Created: 2023-06-27T00:06:27-05:00
 *   Modified: 2024-15-28T14:15:43-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Web.DownstreamApis;

using Application = Dgmjr.Mime.Application;
using System.Net.Http;

public class DownstreamApiOptionsConfigurator(IOptions<JsonOptions> jsonOptions)
    : IConfigureOptions<DownstreamApiOptions>
{
    private readonly Jso _jso = jsonOptions?.Value?.JsonSerializerOptions;

public void Configure(DownstreamApiOptions options)
{
    options.Serializer = requestObject =>
        new StringContent(Serialize(requestObject, _jso), UTF8, Application.Json.DisplayName);
}
}
