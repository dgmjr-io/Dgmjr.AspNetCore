using System.Net.NetworkInformation;
/*
 * DbContextExtensions.cs
 *
 *   Created: 2022-12-11-07:35:28
 *   Modified: 2022-12-11-07:35:28
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
#pragma warning disable
using System.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Abstractions;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using static System.String;

namespace Microsoft.Extensions.DependencyInjection;

internal static class AddDbContextExtensions
{
    /// <summary>
    /// Gets all registered DbContext implementations from the WebApplicationBuilder services.
    /// </summary>
    /// <param name="builder">The WebApplicationBuilder object.</param>
    /// <returns>An IEnumerable of IDbContext objects.</returns>
    public static IEnumerable<IDbContext> GetAllRegisteredDbContexts(
        this IServiceCollection services
    )
    {
        var dbContexts = services
            .Where(s => typeof(IDbContext).IsAssignableFrom(s.ServiceType))
            .Select(s => s.ImplementationInstance)
            .Cast<IDbContext>();
        return dbContexts;
    }

    /// <summary>
    /// Adds a DbContext of type TContext to the WebApplicationBuilder services.
    /// </summary>
    /// <typeparam name="TContext">The type of DbContext to add.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection" /> object.</param>
    /// <param name="connectionStringKey">The key for the connection string in configuration.</param>
    /// <returns>The updated <see cref="IServiceCollection" /> object.</returns>
    public static IServiceCollection AddDbContext<TContext>(
        this IServiceCollection services,
        IConfiguration configuration,
        string? connectionStringKey = default
    )
        where TContext : DbContext
    {
        var dbContextName = typeof(TContext).Name;
        var connectionStringKeyNames = new[]
        {
            dbContextName,
            dbContextName.Replace(nameof(DbContext), string.Empty),
            dbContextName.Replace(nameof(DbContext), string.Empty) + "Db"
        };
        connectionStringKeyNames = connectionStringKeyNames
            .Concat(
                connectionStringKeyNames.Select(
                    k => k + $"AZURE_SQL_{k.ToUpper()}_CONNECTIONSTRING"
                )
            )
            .ToArray();
        if (connectionStringKeyNames is not null)
        {
            var connectionString = connectionStringKeyNames
                .Select(configuration.GetConnectionString)
                .FirstOrDefault(c => !c.IsNullOrEmpty());
            if (!connectionString.IsNullOrEmpty())
            {
                services.AddDbContext<TContext>(
                    builder =>
                        builder.UseSqlServer(configuration.GetConnectionString(dbContextName))
                );
            }
            else
            {
                throw new ConfigurationErrorsException(
                    $"No connection string found for {dbContextName} in appsettings.json, environment variables, other configuration sources."
                );
            }
        }

        return services;
    }

    /// <summary>
    /// Gets all registered DbContext implementations from the WebApplicationBuilder services.
    /// </summary>
    /// <param name="builder">The WebApplicationBuilder object.</param>
    /// <returns>An IEnumerable of IDbContext objects.</returns>
    public static IEnumerable<IDbContext> GetAllRegisteredDbContexts(
        this WebApplicationBuilder builder
    ) => builder.Services.GetAllRegisteredDbContexts();

    /// <summary>
    /// Adds a DbContext of type TContext to the WebApplicationBuilder services.
    /// </summary>
    /// <typeparam name="TContext">The type of DbContext to add.</typeparam>
    /// <param name="builder">The WebApplicationBuilder object.</param>
    /// <param name="connectionStringKey">The key for the connection string in configuration.</param>
    /// <returns>The updated WebApplicationBuilder object.</returns>
    public static WebApplicationBuilder AddDbContext<TContext>(
        this WebApplicationBuilder builder,
        string? connectionStringKey = default
    )
        where TContext : DbContext
    {
        var dbContextName = typeof(TContext).Name;
        var connectionStringKeyNames = new[]
        {
            dbContextName,
            dbContextName.Replace(nameof(DbContext), string.Empty),
            dbContextName.Replace(nameof(DbContext), string.Empty) + "Db"
        };
        connectionStringKeyNames = connectionStringKeyNames
            .Concat(
                connectionStringKeyNames.Select(
                    k => k + $"AZURE_SQL_{k.ToUpper()}_CONNECTIONSTRING"
                )
            )
            .ToArray();
        if (connectionStringKeyNames is not null)
        {
            var config = builder.Configuration;
            var connectionString = connectionStringKeyNames
                .Select(config.GetConnectionString)
                .FirstOrDefault(c => !c.IsNullOrEmpty());
            if (!connectionString.IsNullOrEmpty())
            {
                builder.Services.AddDbContext<TContext>(
                    builder => builder.UseSqlServer(config.GetConnectionString(dbContextName))
                );
            }
            else
            {
                throw new ConfigurationErrorsException(
                    $"No connection string found for {dbContextName} in appsettings.json, environment variables, other configuration sources."
                );
            }
        }

        return builder;
    }
}
