namespace Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.DependencyInjection;
using Dgmjr.AspNetCore.Formatters;
using MessagePack;
using MessagePack.AspNetCoreMvcFormatter;
using MessagePack.Resolvers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

#if NET5_0_OR_GREATER
using Microsoft.AspNetCore.Builder;
#endif

public static class FormattersExtensions
{
    public static IServiceCollection AddFormatters(this IServiceCollection services)
    {
        services
            .AddControllers(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.ReturnHttpNotAcceptable = true;

                options.OutputFormatters.Add(
                    new Dgmjr.Payloads.Formatters.PlainTextPayloadFormatter()
                );
                options.InputFormatters.Add(new PlainTextInputFormatter());
                options.OutputFormatters.Add(new BsonOutputFormatter());
                options.OutputFormatters.Add(new PlainTextProblemDetailsOutputFormatter());
                options.OutputFormatters.Add(new PlainTextOutputFormatter());

                options.OutputFormatters.Add(new MessagePackOutputFormatter(new MessagePackSerializerOptions(ContractlessStandardResolver.Instance)));
                options.InputFormatters.Add(new MessagePackInputFormatter(new MessagePackSerializerOptions(ContractlessStandardResolver.Instance)));

                options.InputFormatters.Add(new XmlSerializerInputFormatter());
                options.InputFormatters.Add(new XmlDataContractSerializerInputFormatter());
            })
            .AddXmlSerializerFormatters()
            .AddXmlDataContractSerializerFormatters()
            .Configure<MvcOptions>(options =>
            {
                // Since both XmlSerializer and DataContractSerializer based formatters
                // have supported media types of 'application/xml' and 'text/xml',  it
                // would be difficult for a test to choose a particular formatter based on
                // request information (Ex: Accept header).
                // We'll configure the ones on MvcOptions to use a distinct set of content types.

                var xmlSerializerInputFormatter = options.GetXmlSerializerInputFormatter();
                var xmlSerializerOutputFormatter = options.GetXmlSerializerOutputFormatter();
                var dcsInputFormatter = options.GetXmlDataContractSerializerInputFormatter();
                var dcsOutputFormatter = options.GetXmlDataContractSerializerOutputFormatter();

                options.InputFormatters.RemoveRange([xmlSerializerInputFormatter, dcsInputFormatter]);
                options.OutputFormatters.RemoveRange([xmlSerializerOutputFormatter, dcsOutputFormatter]);

                xmlSerializerInputFormatter.SupportedMediaTypes.Clear();
                xmlSerializerInputFormatter.SupportedMediaTypes.Add("application/*+xml");
                xmlSerializerInputFormatter.SupportedMediaTypes.Add("application/problem+xml");
                xmlSerializerInputFormatter.SupportedMediaTypes.Add("application/xml");
                xmlSerializerInputFormatter.SupportedMediaTypes.Add("application/xmlser+xml");
                xmlSerializerInputFormatter.SupportedMediaTypes.Add("text/*+xml");
                xmlSerializerInputFormatter.SupportedMediaTypes.Add("text/xml");
                xmlSerializerInputFormatter.SupportedMediaTypes.Add("text/xmlser+xml");

                xmlSerializerOutputFormatter.SupportedMediaTypes.Clear();
                xmlSerializerOutputFormatter.SupportedMediaTypes.Add("application/*+xml");
                xmlSerializerOutputFormatter.SupportedMediaTypes.Add("application/problem+xml");
                xmlSerializerOutputFormatter.SupportedMediaTypes.Add("application/xml");
                xmlSerializerOutputFormatter.SupportedMediaTypes.Add("application/xmlser+xml");
                xmlSerializerOutputFormatter.SupportedMediaTypes.Add("text/*+xml");
                xmlSerializerOutputFormatter.SupportedMediaTypes.Add("text/problem+plain");
                xmlSerializerOutputFormatter.SupportedMediaTypes.Add("text/xml");
                xmlSerializerOutputFormatter.SupportedMediaTypes.Add("text/xmlser+xml");

                dcsInputFormatter.SupportedMediaTypes.Clear();
                dcsInputFormatter.SupportedMediaTypes.Add("application/dcs+xml");
                dcsInputFormatter.SupportedMediaTypes.Add("application/problem+xml");
                dcsInputFormatter.SupportedMediaTypes.Add("application/xml");
                dcsInputFormatter.SupportedMediaTypes.Add("text/dcs+xml");
                dcsInputFormatter.SupportedMediaTypes.Add("text/xml");

                dcsOutputFormatter.SupportedMediaTypes.Clear();
                dcsOutputFormatter.SupportedMediaTypes.Add("application/dcs+xml");
                dcsOutputFormatter.SupportedMediaTypes.Add("application/problem+xml");
                dcsOutputFormatter.SupportedMediaTypes.Add("application/xml-dcs");
                dcsOutputFormatter.SupportedMediaTypes.Add("text/dcs+xml");
                dcsOutputFormatter.SupportedMediaTypes.Add("text/xml-dcs");

                options.InputFormatters.Add(dcsInputFormatter);
                options.InputFormatters.Add(xmlSerializerInputFormatter);
                options.OutputFormatters.Add(dcsOutputFormatter);
                options.OutputFormatters.Add(xmlSerializerOutputFormatter);
            });
        return services;
    }

    public static XmlSerializerInputFormatter? GetXmlSerializerInputFormatter(this MvcOptions mvcOptions)
    => mvcOptions.InputFormatters.FirstOrDefault(formatter => formatter is XmlSerializerInputFormatter) as XmlSerializerInputFormatter;

    public static XmlSerializerOutputFormatter? GetXmlSerializerOutputFormatter(this MvcOptions mvcOptions)
    => mvcOptions.OutputFormatters.FirstOrDefault(formatter => formatter is XmlSerializerOutputFormatter) as XmlSerializerOutputFormatter;

    public static XmlDataContractSerializerInputFormatter? GetXmlDataContractSerializerInputFormatter(this MvcOptions mvcOptions)
    => mvcOptions.InputFormatters.FirstOrDefault(formatter => formatter is XmlDataContractSerializerInputFormatter) as XmlDataContractSerializerInputFormatter;

    public static XmlDataContractSerializerOutputFormatter? GetXmlDataContractSerializerOutputFormatter(this MvcOptions mvcOptions)
    => mvcOptions.OutputFormatters.FirstOrDefault(formatter => formatter is XmlDataContractSerializerOutputFormatter) as XmlDataContractSerializerOutputFormatter;


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
