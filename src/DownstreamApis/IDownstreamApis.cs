/*
 * IDownstreamApis.cs
 *
 *   Created: 2023-06-27T00:06:27-05:00
 *   Modified: 2024-16-28T14:16:22-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Web.DownstreamApis;

/// <summary>
/// Represents the interface for downstream APIs.
/// </summary>
public interface IDownstreamApis
{
    MicrosoftGraphOptions MicrosoftGraph { get; set; }
}
