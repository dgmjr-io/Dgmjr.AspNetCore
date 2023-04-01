namespace Microsoft.Extensions.DependencyInjection;

using Dgmjr.Payloads.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

public static class RegisterPayloadFormattersExtensions
{
    public static WebApplicationBuilder AddPayloadServices(this WebApplicationBuilder builder)
    {
        return builder.AddPayloadFormatters().DescribeRangeRequest();
    }

    public static WebApplicationBuilder AddPayloadFormatters(this WebApplicationBuilder builder)
    {
        builder.Services.AddPayloadFormatters();
        return builder;
    }

    public static IServiceCollection AddPayloadFormatters(this IServiceCollection services)
    {
        // services.AddScoped<IActionResultExecutor<IResponsePayload>, ResponsePayloadExecutor>();
        // services.AddScoped<IActionResultExecutor<IPager>, ResponsePayloadExecutor>();
        services.Add(
            new ServiceDescriptor(
                typeof(IResponsePayload<>),
                typeof(ResponsePayloadExecutor<>),
                ServiceLifetime.Scoped
            )
        );
        services.Add(
            new ServiceDescriptor(
                typeof(IPager<>),
                typeof(ResponsePayloadExecutor<>),
                ServiceLifetime.Scoped
            )
        );
        services.AddSingleton<OutputFormatterSelector, ResponsePayloadOutputFormatterSelector>();
        return services;
    }

    public static WebApplicationBuilder DescribeRangeRequest(this WebApplicationBuilder builder)
    {
        builder.Services.ConfigureSwaggerGen(c =>
        {
            c.MapType<Dgmjr.Payloads.Range>(
                () =>
                    new OpenApiSchema
                    {
                        Type = "string",
                        Pattern = Dgmjr.Payloads.Range.RegexString,
                        Format = nameof(Dgmjr.Payloads.Range),
                        Description =
                            "Indicates the part of a resultset that the server should return.  It's a zero-based index from the start to the end if the desired resultset.  The format is \"items {start}-{end}\".  If the end is omitted, the server will return all items from the start to the end of the resultset.  If the start is omitted, the server will return all items from the beginning to the end of the resultset.  If both are omitted, the server will return all items in the resultset.  The server will return a 416 (Range Not Satisfiable) if the requested range is not satisfiable.",
                        Example = new OpenApiString("items 0-20"),
                        Default = new OpenApiString($"items 0-{int.MaxValue}")
                    }
            );
        });
        return builder;
    }
}
