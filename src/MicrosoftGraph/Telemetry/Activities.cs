/*
 * Activities.cs
 *
 *   Created: 2024-03-26T11:03:20-05:00
 *   Modified: 2024-03-26T11:03:22-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2023 - 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Graph.Telemetry;

public static class Activities
{
    private static readonly Version AssemblyVersion = typeof(Activities).Assembly.GetName().Version;

    public static readonly ActivitySource ActivitySource = new(TraceNames.Basic, ServiceVersion);

    /// <summary>
    /// Base ActivitySource
    /// </summary>
    public static readonly ActivitySource BasicActivitySource =
        new(TraceNames.Basic, ServiceVersion);

    /// <summary>
    /// Store ActivitySource
    /// </summary>
    public static readonly ActivitySource StoreActivitySource =
        new(TraceNames.Store, ServiceVersion);

    /// <summary>
    /// Cache ActivitySource
    /// </summary>
    public static readonly ActivitySource CacheActivitySource =
        new(TraceNames.Cache, ServiceVersion);

    /// <summary>
    /// Cache ActivitySource
    /// </summary>
    public static readonly ActivitySource ServiceActivitySource =
        new(TraceNames.Services, ServiceVersion);

    /// <summary>
    /// Detailed validation ActivitySource
    /// </summary>
    public static readonly ActivitySource ValidationActivitySource =
        new(TraceNames.Validation, ServiceVersion);

    /// <summary>
    /// Detailed validation ActivitySource
    /// </summary>
    public static readonly ActivitySource TokenAcquisitionActivitySource =
        new(TraceNames.TokenAcquisition, ServiceVersion);

    /// <summary>
    /// Service version
    /// </summary>
    public static readonly string ServiceVersion =
        $"{AssemblyVersion.Major}.{AssemblyVersion.Minor}.{AssemblyVersion.Build}";
}

public static class TraceNames
{
    /// <summary>
    /// Service name for base traces
    /// </summary>
    public const string Basic = "Dgmjr.Graph";

    /// <summary>
    /// Service name for store traces
    /// </summary>
    public const string Store = Basic + "." + nameof(Store) + "s";

    /// <summary>
    /// Service name for caching traces
    /// </summary>
    public const string Cache = Basic + "." + nameof(Cache);

    /// <summary>
    /// Service name for caching traces
    /// </summary>
    public const string Services = Basic + "." + nameof(Services);

    /// <summary>
    /// Service name for detailed validation traces
    /// </summary>
    public const string Validation = Basic + nameof(Validation);

    /// <summary>
    /// Service name for detailed token acquisition traces
    /// </summary>
    public const string TokenAcquisition = Basic + "." + nameof(TokenAcquisition);

    public static readonly string ServiceVersion = Activities.ServiceVersion;
}
