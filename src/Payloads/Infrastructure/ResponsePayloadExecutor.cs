/*
 * ResponsePayloadExecutor.cs
 *
 *   Created: 2022-12-17-07:47:54
 *   Modified: 2022-12-19-04:12:56
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System.Globalization;

using Dgmjr.Payloads.Abstractions;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using static Microsoft.AspNetCore.Http.StatusCodes;

namespace Dgmjr.Payloads.Infrastructure;

using WriterFactory = Func<Stream, Encoding, TextWriter>;

public partial class ResponsePayloadExecutor<T> : IActionResultExecutor<IResponsePayload<T>>, ILog
{
    private readonly OutputFormatterSelector _formatterSelector;
    public ILogger Logger { get; }

    private ICollection<IOutputFormatter> _outputFormatters;

    public ResponsePayloadExecutor(
        OutputFormatterSelector formatterSelector,
        // IHttpResponseStreamWriterFactory writerFactory,
        ILogger<ResponsePayloadExecutor<T>> logger,
        IOptions<MvcOptions> mvcOptions
    )
    {
        _formatterSelector =
            formatterSelector ?? throw new ArgumentNullException(nameof(formatterSelector));
        Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _outputFormatters = mvcOptions.Value.OutputFormatters;
    }

    /// <summary>
    /// Gets the writer factory delegate.
    /// </summary>
    protected WriterFactory WriterFactory =>
        (stream, encoding) => new StreamWriter(stream, encoding);

    /// <summary>
    /// Executes the <see cref="ObjectResult"/>.
    /// </summary>
    /// <param name="context">The <see cref="ActionContext"/> for the current request.</param>
    /// <param name="payload">The <see cref="IResponsePayload"/>.</param>
    /// <returns>
    /// A <see cref="Task"/> which will complete once the <see cref="IResponsePayload"/> is written to the response.
    /// </returns>
    public async Task ExecuteAsync(ActionContext context, IResponsePayload<T> payload)
    {
        var payloadType = payload.GetType();
        var payloadValueType = typeof(T);
        Log.PayloadFormatterExecuting(Logger, payload, payloadValueType);

        var formatterContext = new OutputFormatterWriteContext(
            context.HttpContext,
            WriterFactory,
            payloadType,
            payload
        );

        var selectedFormatter = _formatterSelector.SelectFormatter(
            formatterContext,
            (
                payload.OutputFormatters?.Concat(_outputFormatters) ?? Empty<IOutputFormatter>()
            )?.ToList(),
            payload.ContentTypes
        );

        if (selectedFormatter == null)
        {
            // No formatter supports this.
            Log.NoFormatter(Logger, formatterContext, payload.ContentTypes);

            context.HttpContext.Response.StatusCode = Status406NotAcceptable;

            var message = Format(
                CultureInfo.CurrentCulture,
                "No output formatter was found to support the content type '{0}' for use with the formatter '{1}'.",
                Join(", ", payload.ContentTypes),
                payloadType.FullName
            );
            throw new System.Net.Http.HttpRequestException(message);
        }

        payload.OnFormatting(formatterContext);
        await selectedFormatter.WriteAsync(formatterContext);
    }

    // public Task ExecuteAsync(ActionContext context, IPager<T> payload)
    // {
    //     var payloadType = payload.GetType();
    //     var payloadValueType = typeof(T);
    //     Log.PayloadFormatterExecuting(Logger, payload, payloadValueType);

    //     var formatterContext = new OutputFormatterWriteContext(
    //         context.HttpContext,
    //         WriterFactory,
    //         payloadType,
    //         payload);

    //     var selectedFormatter = _formatterSelector.SelectFormatter(
    //         formatterContext,
    //         (IList<IOutputFormatter>)payload.OutputFormatters ?? Empty<IOutputFormatter>(),
    //         payload.ContentTypes);

    //     if (selectedFormatter == null)
    //     {
    //         // No formatter supports this.
    //         Log.NoFormatter(Logger, formatterContext, payload.ContentTypes);

    //         context.HttpContext.Response.StatusCode = Status406NotAcceptable;

    //         var message = Format(
    //             CultureInfo.CurrentCulture,
    //             "No output formatter was found to support the content type '{0}' for use with the formatter '{1}'.",
    //             Join(", ", payload.ContentTypes),
    //             payloadType.FullName);
    //         throw new HttpRequestException(message);
    //     }

    //     payload.OnFormatting(formatterContext);
    //     await selectedFormatter.WriteAsync(formatterContext);
    // }

    // Internal for unit testing
    internal static partial class Log
    {
        // Removed Log.
        // new EventId(1, "BufferingAsyncEnumerable")

        public static void PayloadFormatterExecuting(
            ILogger logger,
            IResponsePayload payload,
            object? value
        )
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                var payloadType = payload.GetType().FullName;
                var payloadValueType = value == null ? "null" : value.GetType().FullName;
                PayloadFormatterExecuting(logger, payloadType, payloadValueType);
            }
        }

        [LoggerMessage(
            1,
            LogLevel.Information,
            "Executing {PayloadType}, writing value of type '{PayloadValueType}'.",
            EventName = "IResponsePayloadExecuting",
            SkipEnabledCheck = true
        )]
        private static partial void PayloadFormatterExecuting(
            ILogger logger,
            string payloadType,
            string? payloadValueType
        );

        public static void NoFormatter(
            ILogger logger,
            OutputFormatterCanWriteContext context,
            MediaTypeCollection contentTypes
        )
        {
            if (logger.IsEnabled(LogLevel.Warning))
            {
                var considered = new List<string?>(contentTypes);

                if (context.ContentType.HasValue)
                {
                    considered.Add(
                        System.Convert.ToString(context.ContentType, CultureInfo.InvariantCulture)
                    );
                }

                NoFormatter(logger, considered);
            }
        }

        [LoggerMessage(
            2,
            LogLevel.Warning,
            "No output formatter was found for content types '{ContentTypes}' to write the response.",
            EventName = "NoFormatter",
            SkipEnabledCheck = true
        )]
        private static partial void NoFormatter(ILogger logger, List<string?> contentTypes);
    }
}
