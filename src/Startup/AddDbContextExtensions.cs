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
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using static System.String;

namespace Microsoft.Extensions.DependencyInjection;

public static class AddDbContextExtensions
{
    public static WebApplicationBuilder AddDbContext<TContext>(
        this WebApplicationBuilder builder,
        string? connectionStringKey = default
    ) where TContext : DbContext
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
                .FirstOrDefault(c => !string.IsNullOrEmpty(c));
            if (!IsNullOrEmpty(connectionString))
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
