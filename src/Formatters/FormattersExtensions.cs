namespace Microsoft.Extensions.DependencyInjection;

using Dgmjr.AspNetCore.Formatters;
using MessagePack;
using MessagePack.AspNetCoreMvcFormatter;
using MessagePack.Resolvers;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc;

#if NET5_0_OR_GREATER
using Microsoft.AspNetCore.Builder;
#endif

public static class FormattersExtensions
{
    public static IServiceCollection AddFormatters(this IServiceCollection services)
    {
#if NET8_0_OR_GREATER
        services
            .AddControllers(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.ReturnHttpNotAcceptable = true;

                options.OutputFormatters.Insert(
                    0,
                    new Dgmjr.Payloads.Formatters.PlainTextPayloadFormatter()
                );
                options.InputFormatters.Insert(0, new PlainTextInputFormatter());

                options.OutputFormatters.Insert(0, new XmlSerializerOutputFormatter());
                options.OutputFormatters.Insert(0, new XmlDataContractSerializerOutputFormatter());
                options.OutputFormatters.Insert(0, new BsonOutputFormatter());
                options.OutputFormatters.Insert(0, new PlainTextProblemDetailsOutputFormatter());
                options.OutputFormatters.Insert(0, new PlainTextOutputFormatter());

                options.OutputFormatters.Insert(
                    0,
                    new MessagePackOutputFormatter(
                        new MessagePackSerializerOptions(ContractlessStandardResolver.Instance)
                    )
                );
                options.InputFormatters.Insert(
                    0,
                    new MessagePackInputFormatter(
                        new MessagePackSerializerOptions(ContractlessStandardResolver.Instance)
                    )
                );

                // options.InutFormatters.Add(new XmlSerializerInputFormatter());
            })
            .AddXmlSerializerFormatters()
            .AddXmlDataContractSerializerFormatters();
#endif
        return services;
    }

#if NET8_0_OR_GREATER
    public static WebApplicationBuilder AddFormatters(this WebApplicationBuilder builder)
    {
        _ = builder.Services.AddFormatters();
        _ = builder.AddPayloadFormatters();
        _ = builder.AddInputFormatters();
        return builder;
    }

    public static WebApplicationBuilder AddInputFormatters(this WebApplicationBuilder builder)
    {
        _ = builder.Services.AddControllers(options => { });
        return builder;
    }
#endif
}
