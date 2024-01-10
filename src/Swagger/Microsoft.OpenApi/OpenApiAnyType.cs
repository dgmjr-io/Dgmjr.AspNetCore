using System.Collections;

using Microsoft.OpenApi;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Writers;

namespace Microsoft.OpenApi.Any;

public class OpenApiAnyType(object value) : IOpenApiAny
{
    public AnyType AnyType { get; } = value switch
    {
        null => AnyType.Null,
        bool
        or byte
        or sbyte
        or short
        or ushort
        or int
        or uint
        or long
        or ulong
        or float
        or double
        or decimal
        or char
        or string
        or datetime
        or DateTimeOffset
        or date
        or time
        or Uri
        or duration
        or guid
        or Version
            => AnyType.Primitive,
        IEnumerable => AnyType.Array,
        _ => AnyType.Object
    };

private readonly IOpenApiAny? _value = value switch
{
    null => new OpenApiNull(),
    bool => new OpenApiBoolean((bool)value),
    byte
    or sbyte => new OpenApiByte((byte)value),
    byte[] => new OpenApiBinary((byte[])value),
    short
    or ushort
    or int
    or uint
    or long
    or ulong => new OpenApiInteger((short)value),
    float => new OpenApiFloat((float)value),
    double
    or decimal => new OpenApiDouble((double)value),
    char
    or string => new OpenApiString((string)value),
    datetime => new OpenApiDateTime((DateTime)value),
    date => new OpenApiDate(((date)value).ToDateTime(new time(0, 0, 0, 0))),
    time => new OpenApiString(((time)value).ToTimeSpan().ToString()),
    DateTimeOffset => new OpenApiDateTime(DateTime.FromFileTimeUtc(((DateTimeOffset)value).ToUniversalTime().ToFileTime())),
    Uri => new OpenApiString(((Uri)value).ToString()),
    duration => new OpenApiString(((TimeSpan)value).ToString()),
    guid => new OpenApiString(((Guid)value).ToString()),
    Version => new OpenApiString(((Version)value).ToString()),
    IEnumerable => (value as IEnumerable).ToOpenApiArray(),
    _ => value.ToOpenApiObject()
};

public void Write(IOpenApiWriter writer, OpenApiSpecVersion specVersion)
{
    _value.Write(writer, specVersion);
}
}

public static class ToOpenApiObjectExtensions
{
    public static OpenApiObject ToOpenApiObject(this object value)
    {
        var obj = new OpenApiObject();
        foreach (var property in value.GetType().GetProperties())
        {
            obj.Add(property.Name, new OpenApiAnyType(property.GetValue(value)));
        }
        return obj;
    }
}

public static class ToOpenApiArrayExtensions
{
    public static OpenApiArray ToOpenApiArray(this IEnumerable enumerable)
    {
        var array = new OpenApiArray();
        foreach (var item in enumerable)
        {
            array.Add(new OpenApiAnyType(item));
        }
        return array;
    }
}
