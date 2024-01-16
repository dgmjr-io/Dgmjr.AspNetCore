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
    /// <summary>The environment used for local development</summary>
    /// <returns>Local</returns>
    /// <value><inheritdoc cref="Local" path="/returns" /></value>
    public const string Local = nameof(Local);
    /// <summary>The environment used for testing</summary>
    /// <returns>Testing</returns>
    /// <value><inheritdoc cref="Testing" path="/returns" /></value>
    public const string Testing = nameof(Testing);
    /// <summary>The environment which is hosted in Microsoft Azure</summary>
    /// <returns>Azure</returns>
    /// <value><inheritdoc cref="Azure" path="/returns" /></value>
    public const string Azure = nameof(Azure);
    /// <summary>The production environment</summary>
    /// <returns>Production</returns>
    /// <value><inheritdoc cref="Production" path="/returns" /></value>
    public const string Production = nameof(Production);
    /// <summary>The development environment</summary>
    /// <returns>Development</returns>
    /// <value><inheritdoc cref="Development" path="/returns" /></value>
    public const string Development = nameof(Development);
    /// <summary>The staging environment</summary>
    /// <returns>Staging</returns>
    /// <value><inheritdoc cref="Staging" path="/returns" /></value>
    public const string Staging = nameof(Staging);

    public static readonly string[] All = [
        Local,
        Environments.Development,
        Environments.Staging,
        Environments.Production,
        Testing,
        Azure
    ];
}
