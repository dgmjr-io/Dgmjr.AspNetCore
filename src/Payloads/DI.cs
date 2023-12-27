namespace Microsoft.Extensions.DependencyInjection;

using Dgmjr.Payloads.Abstractions;
using Dgmjr.Payloads.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

public static partial class RegisterPayloadFormattersExtensions
{
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
}
