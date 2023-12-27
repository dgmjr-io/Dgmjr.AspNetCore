/*
 * StartupParametersBuilder.cs
 *
 *   Created: 2023-14-31T11:14:04-04:00
 *   Modified: 2023-14-31T11:14:06-04:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Microsoft.Extensions.DependencyInjection;

using System.Buffers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Collections;
using BuilderGenerator;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

/// <summary>This class is a builder for StartParameters object.</summary>
[BuilderFor(typeof(StartupParameters))]
public partial class StartupParametersBuilder : IStartupParametersBuilder
{
    internal StartupParametersBuilder()
    {
        WithAppInsights(true);
        WithConsoleLogger(true);
        WithAutoMapper(true);
        WithMediatR(true);
        WithJsonPatch(true);
        WithHashids(true);
        WithHealthChecks(true);
        WithoutDefaultIdentityUI();
        WithoutIdentity();
    }

    IStartupParameters IStartupParametersBuilder.Build() => Build();

    /// <summary>Configures health checks using provided IHealthChecksBuilder configurator.</summary>
    /// <returns>The updated <see cref="Action{IHealthChecksBuilder}" /> delegate.</returns>
    Action<IHealthChecksBuilder> IStartupParametersBuilder.HealthChecksConfigurator { get; set; } =
        _ => { };

    /// <summary>
    /// Adds Health Check middleware to application.
    /// </summary>
    /// <param name="configure">Action to configure IHealthChecksBuilder.</param>
    public IStartupParametersBuilder WithHealthChecks(Action<IHealthChecksBuilder>? configure)
    {
        WithHealthChecks(true);
        ((IStartupParametersBuilder)this).HealthChecksConfigurator = (IHealthChecksBuilder hcb) =>
        {
            ((IStartupParametersBuilder)this).HealthChecksConfigurator(hcb);
            configure(hcb);
        };
        return this;
    }

    IServiceCollection IStartupParametersBuilder.Services { get; } = new ServiceCollection();

    #region IServiceCollection implementation
    void IList<ServiceDescriptor>.Insert(int index, ServiceDescriptor sd) =>
        ((IStartupParametersBuilder)this).Services.Insert(index, sd);

    int IList<ServiceDescriptor>.IndexOf(ServiceDescriptor sd) =>
        ((IStartupParametersBuilder)this).Services.IndexOf(sd);

    void IList<ServiceDescriptor>.RemoveAt(int index) =>
        ((IStartupParametersBuilder)this).Services.RemoveAt(index);

    void ICollection<ServiceDescriptor>.Add(ServiceDescriptor sd) =>
        ((IStartupParametersBuilder)this).Services.Add(sd);

    bool ICollection<ServiceDescriptor>.Contains(ServiceDescriptor sd) =>
        ((IStartupParametersBuilder)this).Services.Contains(sd);

    void ICollection<ServiceDescriptor>.Clear() =>
        ((IStartupParametersBuilder)this).Services.Clear();

    void ICollection<ServiceDescriptor>.CopyTo(ServiceDescriptor[] array, int arrayIndex) =>
        ((IStartupParametersBuilder)this).Services.CopyTo(array, arrayIndex);

    IEnumerator<ServiceDescriptor> IEnumerable<ServiceDescriptor>.GetEnumerator() =>
        ((IStartupParametersBuilder)this).Services.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() =>
        ((IStartupParametersBuilder)this).Services.GetEnumerator();

    bool ICollection<ServiceDescriptor>.Remove(ServiceDescriptor sd) =>
        ((IStartupParametersBuilder)this).Services.Remove(sd);

    ServiceDescriptor IList<ServiceDescriptor>.this[int i]
    {
        get => ((IStartupParametersBuilder)this).Services[i];
        set => ((IStartupParametersBuilder)this).Services[i] = value;
    }

    int ICollection<ServiceDescriptor>.Count => ((IStartupParametersBuilder)this).Services.Count;

    bool ICollection<ServiceDescriptor>.IsReadOnly =>
        ((IStartupParametersBuilder)this).Services.IsReadOnly;
    #endregion
}
