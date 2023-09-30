/*
 * JaonSerializerOptionsBuilder.cs
 *
 *   Created: 2023-04-02-05:25:08
 *   Modified: 2023-04-02-05:25:08
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Microsoft.Extensions.DependencyInjection;

using BuilderGenerator;

using Microsoft.EntityFrameworkCore.Storage.Json;

[BuilderFor(typeof(Jso))]
public partial class JsonSerializerOptionsBuilder
{
    private Lazy<ICollection<JConverter>> _converters = new(() => new List<JConverter>());

    public virtual JsonSerializerOptionsBuilder WithConverters(params JConverter[] converters)
    {
        _converters = new(() => _converters.Value.AddRange(converters));
        return this;
    }
}
