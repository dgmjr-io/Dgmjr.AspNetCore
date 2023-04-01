/*
 * AddAzureAppConfigExtensions.cs
 *
 *   Created: 2023-01-03-12:03:40
 *   Modified: 2023-01-03-12:03:40
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using Azure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class AddAzureAppConfigExtensions
{
    public const string DefaultConnectionStringKey = "AZURE_APPCONFIGURATION_CONNECTIONSTRING";

    /// <summary>Adds Azure App Configuration to the application.</summary>
    /// <param name="builder">The <see cref="WebApplicationBuilder"/>.</param>
    /// <param name="connectionStringKey">The key in the configuration to use for the connection string (default: <see cref="DefaultConnectionStringKey" />).</param>
    public static WebApplicationBuilder AddAzureAppConfig(
        this WebApplicationBuilder builder,
        string connectionStringKey = DefaultConnectionStringKey
    )
    {
        /*** Add Azure AppConfig ***/
        // Retrieve the connection string
        var connectionString = builder.Configuration[connectionStringKey];
        if (connectionString.IsNullOrEmpty())
        {
            throw new ArgumentException(
                $"The connection string for Azure App Configuration was not found. "
                    + $"Please ensure that the key '{connectionStringKey}' is present in the configuration."
            );
        }

        // Load configuration from Azure App Configuration
        builder.Configuration.AddAzureAppConfiguration(
            options =>
                options
                    .Connect(connectionString)
                    .ConfigureKeyVault(kv => kv.SetCredential(new DefaultAzureCredential()))
        );

        return builder;
    }
}
