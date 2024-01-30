/*
 * DownstreamApisAutoConfigurator.cs
 *
 *   Created: 2024-10-20T10:10:10-05:00
 *   Modified: 2024-15-28T14:15:56-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace Dgmjr.Web.DownstreamApis;

public class DownstreamApisAutoConfigurator
    : IConfigureIHostApplicationBuilder,
        IConfigureIApplicationBuilder
{
    public ConfigurationOrder Order => ConfigurationOrder.AnyTime;

    public void Configure(WebApplicationBuilder builder) { }

    public void Configure(IApplicationBuilder app) { }
}
