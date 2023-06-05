namespace Dgmjr.AspNetCore.Formatters;

using System.Net.Http.Headers;
using System.Net.Mime.MediaTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;

public class PlainTextOutputFormatter : OutputFormatter
{
    public PlainTextOutputFormatter()
    {
        SupportedMediaTypes.Add(TextMediaTypeNames.Plain);
        SupportedMediaTypes.Add(TextMediaTypeNames.Css);
        SupportedMediaTypes.Add(TextMediaTypeNames.Csv);
        SupportedMediaTypes.Add(TextMediaTypeNames.Any);
    }

    protected virtual string GetContentType(OutputFormatterWriteContext context) =>
        context.HttpContext.Request.Path.Value.EndsWith(".css")
        || context.HttpContext.Request
            .GetTypedHeaders()
            .Accept.Any(a => a.MediaType.Value.ToLower().Contains(TextMediaTypeNames.Css))
            ? TextMediaTypeNames.Css
            // : context.HttpContext.Request.Path.Value.EndsWith(".js") ?
            : TextMediaTypeNames.Plain;

    public override void WriteResponseHeaders(OutputFormatterWriteContext context)
    {
        base.WriteResponseHeaders(context);
        context.HttpContext.Response.Headers[HttpResponseHeaderNames.ContentType] = GetContentType(
            context
        );
        context.HttpContext.Response.ContentType = TextMediaTypeNames.Plain;
    }

    public override bool CanWriteResult(OutputFormatterCanWriteContext context) =>
        context.Object is string
        && context.HttpContext.Request
            .GetTypedHeaders()
            .Accept.Any(a => a.MediaType.Value.ToLower().StartsWith("text/"));

    public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context) =>
        await context?.HttpContext?.Response?.WriteAsync(context.Object?.ToString() ?? string.Empty);
}
