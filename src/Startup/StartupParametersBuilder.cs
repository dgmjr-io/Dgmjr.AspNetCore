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
using BuilderGenerator;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

/// <summary>This class is a builder for StartParameters object.</summary>
[BuilderFor(typeof(StartupParameters))]
public partial class StartupParametersBuilder { }
