/*
 * AddAuthorizeSummary.cs
 *
 *   Created: 2022-12-17-09:21:05
 *   Modified: 2022-12-17-09:21:07
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Microsoft.Extensions.DependencyInjection;

public static class AddAuthorizeSummaryToSwagger
{
    public static void AddAuthorizeSummary(this SwaggerGenOptions options)
    {
        options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
    }
}
