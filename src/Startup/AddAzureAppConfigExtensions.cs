using System;
using System.Collections.ObjectModel;
using Azure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

namespace Microsoft.Extensions.DependencyInjection;

public static class AddAzureAppConfigExtensions
{
    public const string DefaultConnectionStringKey = "ConnectionStrings:AzureAppConfig";

    public static readonly Func<IConfiguration, global::Azure.Core.TokenCredential> DefaultKeyVaultCredentialsFactory = configuration =>
    {
        var clientId = configuration["AzureKeyVault:ClientId"];
        var tenantId = configuration["AzureKeyVault:TenantId"];
        var clientSecret = configuration["AzureKeyVault:ClientSecret"];

        if (!string.IsNullOrEmpty(clientId) && !string.IsNullOrEmpty(tenantId) && !string.IsNullOrEmpty(clientSecret))
        {
            return new ClientSecretCredential(tenantId, clientId, clientSecret);
        }

        return new DefaultAzureCredential();
    };

    // public static readonly Action<IServiceCollection, Action<AzureAppConfigurationOptions>, Action<AzureAppConfigurationKeyVaultOptions>> DefaultAzureAppConfigurationOptions = (services, configureAppConfig, configureKeyVault) =>
    // {
    //     services.AddAzureAppConfiguration(
    //         appConfigOptions =>
    //             configureAppConfig(appConfigOptions)
    //             .ConfigureKeyVault(
    //                 keyVaultOptions =>
    //                     configureKeyVault(keyVaultOptions)
    //             ));
    // };

    // /// <summary>Adds Azure App Configuration to the application.</summary>
    // /// <param name="builder">The <see cref="WebApplicationBuilder"/>.</param>
    // /// <param name="connectionStringKey">The key in the configuration to use for the connection string (default: <see cref="DefaultConnectionStringKey" />).</param>
    // public static WebApplicationBuilder AddAzureAppConfig(
    //     this WebApplicationBuilder builder,
    //     Action<AzureAppConfigurationOptions>? azureAppConfigConfigurator = default,
    //     Action<AzureAppConfigurationKeyVaultOptions>? azureKeyVaultConfigurator = default
    // )
    // {
    //     builder.Configuration.ConfigureAppConfiguration(azureAppConfigConfigurator, azureKeyVaultConfigurator);
    //     return builder;
    // }

    // var configuration = builder.Configuration;
    // var connectionString = configuration[connectionStringKey];
    // if (string.IsNullOrEmpty(connectionString))
    // {
    //     throw new ArgumentException($"The connection string was not found in the configuration using the key '{connectionStringKey}'.");
    // }

    // builder.Services.AddAzureAppConfiguration(options =>
    // {
    //     configureOptions?.Invoke(options);
    // });

    // builder.Services.AddAzureKeyVault(options =>
    // {
    //     options.SetCredential(DefaultKeyVaultCredentialsFactory(configuration));
    //     configureKeyVaultOptions(options);
    // });

    // return builder;


    // var connectionString = builder.Configuration[connectionStringKey];
    // if (IsNullOrEmpty(connectionString))
    // {
    //     throw new ArgumentException(
    //         $"The connection string for Azure App Configuration was not found. "
    //             + $"Please ensure that the key '{connectionStringKey}' is present in the configuration."
    //     );
    // }

    // keyVaultCredentialsFactory ??= DefaultKeyVaultCredentialsFactory;

    // // Load configuration from Azure App Configuration
    // builder.Configuration.AddAzureAppConfiguration(
    //     options =>
    //         options
    //             .Connect(connectionString)
    //             .ConfigureKeyVault(kv => kv.SetCredential(DefaultKeyVaultCredentialsFactory(builder.Configuration)))
    // );
    // return builder;
}
