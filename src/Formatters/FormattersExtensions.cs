namespace Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.DependencyInjection;
using Dgmjr.AspNetCore.Formatters;
using MessagePack;
using MessagePack.AspNetCoreMvcFormatter;
using MessagePack.Resolvers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Microsoft.Net.Http.Headers;

#if NET5_0_OR_GREATER
using Microsoft.AspNetCore.Builder;
#endif

public static class FormattersExtensions
{
    public static IServiceCollection AddFormatters(this IServiceCollection services)
    {
#if NET5_0_OR_GREATER
        services.AddControllers();
#endif
        services.Configure<MvcOptions>(options =>
        {
            options.RespectBrowserAcceptHeader = true;
            options.ReturnHttpNotAcceptable = true;

            // options.OutputFormatters.Add(
            //     new Dgmjr.Payloads.Formatters.PlainTextPayloadFormatter()
            // );
            options.InputFormatters.Add(new PlainTextInputFormatter());
            options.OutputFormatters.Add(new BsonOutputFormatter());
            options.OutputFormatters.Add(new PlainTextProblemDetailsOutputFormatter());
            options.OutputFormatters.Add(new PlainTextOutputFormatter());

            options.OutputFormatters.Add(
                new MessagePackOutputFormatter(
                    new MessagePackSerializerOptions(ContractlessStandardResolver.Instance)
                )
                {
                    SupportedMediaTypes =
                    {
                        Application.MessagePack.DisplayName,
                        new MediaTypeHeaderValue(Application.MessagePack.DisplayName),
                        new MediaTypeHeaderValue("application/x-msgpack-seq")
                    }
                }
            );
            options.InputFormatters.Add(
                new MessagePackInputFormatter(
                    new MessagePackSerializerOptions(ContractlessStandardResolver.Instance)
                )
            );

            // Since both XmlSerializer and DataContractSerializer based formatters
            // have supported media types of 'application/xml' and 'text/xml',  it
            // would be difficult for a test to choose a particular formatter based on
            // request information (Ex: Accept header).
            // We'll configure the ones on MvcOptions to use a distinct set of content types.
            options.InputFormatters.Add(
                new XmlSerializerInputFormatter(options)
                {
                    SupportedMediaTypes =
                    {
                        "application/xmlser+xml",
                        Application.Any.DisplayName + "+xml",
                        Application.ProblemXml.DisplayName,
                        Text.Any.DisplayName + "+xml",
                        Application.Xml.DisplayName,
                        Text.Xml.DisplayName
                    }
                }
            );
            options.InputFormatters.Add(
                new XmlDataContractSerializerInputFormatter(options)
                {
                    SupportedMediaTypes =
                    {
                        "application/dcs+xml",
                        "application/xml-dcs",
                        Application.Any.DisplayName + "+xml",
                        Application.ProblemXml.DisplayName,
                        Text.Any.DisplayName + "+xml",
                        Application.Xml.DisplayName,
                        Text.Xml.DisplayName
                    }
                }
            );

            options.OutputFormatters.Add(
                new XmlSerializerOutputFormatter
                {
                    SupportedMediaTypes =
                    {
                        "application/xmlser+xml",
                        Application.Any.DisplayName + "+xml",
                        Application.ProblemXml.DisplayName,
                        Text.Any.DisplayName + "+xml",
                        Application.Xml.DisplayName,
                        Text.Xml.DisplayName
                    }
                }
            );
            options.OutputFormatters.Add(
                new XmlDataContractSerializerOutputFormatter
                {
                    SupportedMediaTypes =
                    {
                        "application/dcs+xml",
                        "application/xml-dcs",
                        Application.Any.DisplayName + "+xml",
                        Application.ProblemXml.DisplayName,
                        Text.Any.DisplayName + "+xml",
                        Application.Xml.DisplayName,
                        Text.Xml.DisplayName
                    }
                }
            );
        });
        return services;
    }

    public static XmlSerializerInputFormatter? GetXmlSerializerInputFormatter(
        this MvcOptions mvcOptions
    ) =>
        mvcOptions.InputFormatters.FirstOrDefault(
            formatter => formatter is XmlSerializerInputFormatter
        ) as XmlSerializerInputFormatter;

    public static XmlSerializerOutputFormatter? GetXmlSerializerOutputFormatter(
        this MvcOptions mvcOptions
    ) =>
        mvcOptions.OutputFormatters.FirstOrDefault(
            formatter => formatter is XmlSerializerOutputFormatter
        ) as XmlSerializerOutputFormatter;

    public static XmlDataContractSerializerInputFormatter? GetXmlDataContractSerializerInputFormatter(
        this MvcOptions mvcOptions
    ) =>
        mvcOptions.InputFormatters.FirstOrDefault(
            formatter => formatter is XmlDataContractSerializerInputFormatter
        ) as XmlDataContractSerializerInputFormatter;

    public static XmlDataContractSerializerOutputFormatter? GetXmlDataContractSerializerOutputFormatter(
        this MvcOptions mvcOptions
    ) =>
        mvcOptions.OutputFormatters.FirstOrDefault(
            formatter => formatter is XmlDataContractSerializerOutputFormatter
        ) as XmlDataContractSerializerOutputFormatter;

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
