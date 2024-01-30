/*
 * DownstreamApis.cs
 *
 *   Created: 2023-06-27T00:06:27-05:00
 *   Modified: 2024-15-28T14:15:49-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Web.DownstreamApis;

using System.Collections;

public class DownstreamApis : Dictionary<string, DownstreamApiOptions>, IDownstreamApis
{
    public const string MicrosoftGraphOptions = "MicrosoftGraph";

    MicrosoftGraphOptions IDownstreamApis.MicrosoftGraph { get; set; }
}
