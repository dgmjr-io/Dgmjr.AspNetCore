/*
 * EnvironmentNames.cs
 *
 *   Created: 2022-12-05-07:24:57
 *   Modified: 2022-12-05-07:25:00
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting;

public static class EnvironmentNames
{
    public const string Local = nameof(Local);
    public const string Testing = nameof(Testing);
    public const string Azure = nameof(Azure);

    public static readonly string[] All = [
        Local,
        Environments.Development,
        Environments.Staging,
        Environments.Production,
        Testing,
        Azure
    ];
}
