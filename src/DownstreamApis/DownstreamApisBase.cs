/*
 * DownstreamApisBase.cs
 *
 *   Created: 2023-06-27T00:06:27-05:00
 *   Modified: 2024-16-28T14:16:10-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Web.DownstreamApis;

public abstract record class DownstreamApisBase
{
    public const string AppSettingsKey = nameof(DownstreamApis);
}
