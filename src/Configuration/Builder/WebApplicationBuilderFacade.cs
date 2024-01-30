namespace Dgmjr.Configuration.Extensions.Builder;

using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.Metrics;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

internal class WebApplicationBuilderFacade(WebApplicationBuilder wrappedBuilder)
    : IHostApplicationBuilder
{
    public IDictionary<object, object> Properties { get; set; }

public IConfigurationManager Configuration => wrappedBuilder.Configuration;

public IHostEnvironment Environment => wrappedBuilder.Environment;

public ILoggingBuilder Logging => wrappedBuilder.Logging;

public IMetricsBuilder Metrics { get; set; }

public IServiceCollection Services => wrappedBuilder.Services;

public void ConfigureContainer<TContainerBuilder>(
    IServiceProviderFactory<TContainerBuilder> factory,
    Action<TContainerBuilder>? configure = null
)
    where TContainerBuilder : notnull
{
    wrappedBuilder.Host.ConfigureContainer<TContainerBuilder>(
        (ctx, builder) => configure(builder)
    );
}

public IApplicationBuilder Build() => wrappedBuilder.Build();
}
