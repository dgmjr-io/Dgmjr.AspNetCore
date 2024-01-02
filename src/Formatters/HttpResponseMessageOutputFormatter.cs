namespace Dgmjr.AspNetCore.Formatters;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Dgmjr.Mime;

public class HttpResponseMessageOutputFormatter : OutputFormatter
{
    public HttpResponseMessageOutputFormatter()
    {
        SupportedMediaTypes.Add(Application.Any.DisplayName);
        SupportedMediaTypes.Add(Text.Any.DisplayName);
        SupportedMediaTypes.Add(Image.Any.DisplayName);
        SupportedMediaTypes.Add(Video.Any.DisplayName);
    }

    public override bool CanWriteResult(OutputFormatterCanWriteContext context)
    {
        return context.Object is HttpResponseMessage;
    }

    public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
    {
        var response = context.Object is HttpResponseMessage resp ? resp : null;
        if (response != null)
        {
            context.HttpContext.Response.StatusCode = (int)response.StatusCode;
            foreach (var header in response.Headers)
            {
                context.HttpContext.Response.Headers[header.Key] = header.Value.ToArray();
            }
            foreach (var header in response.Content.Headers)
            {
                context.HttpContext.Response.Headers[header.Key] = header.Value.ToArray();
            }
            await response.Content.CopyToAsync(context.HttpContext.Response.Body);
        }
        else
        {
            throw new ArgumentException("The object must be an HttpResponseMessage.", $"{nameof(context)}.{nameof(context.Object)}");
        }
    }
}
