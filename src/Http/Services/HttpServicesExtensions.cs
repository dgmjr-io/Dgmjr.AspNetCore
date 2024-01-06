namespace Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Dgmjr.AspNetCore.Http.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Server.Kestrel.Core;

// using Microsoft.AspNetCore.ResponseCompression;

public static partial class HttpServicesExtensions
{
    private const string Http = nameof(Http);
    private const string RequestDecompression = nameof(RequestDecompression);
    private const string ResponseCompression = nameof(ResponseCompression);
    private const string ResponseCaching = nameof(ResponseCaching);
    private const string Cookies = nameof(Cookies);
    private const string Cors = nameof(Cors);
    private const string Hsts = nameof(Hsts);
    private const string OutputCache = nameof(OutputCache);
    private const string Session = nameof(Session);
    private const string IIS = nameof(IIS);
    private const string Kestrel = nameof(Kestrel);

    public static IHostApplicationBuilder AddHttpServices(
        this IHostApplicationBuilder builder,
        string configurationSectionKey = Http
    )
    {
        var options = builder.Configuration
            .GetSection(configurationSectionKey)
            .Get<HttpServicesOptions>();

        if (options is not null)
        {
            if (options.UseRequestDecompression)
            {
                builder.Services.AddRequestDecompression(
                    options =>
                        builder.Configuration.Bind(
                            $"{configurationSectionKey}:{RequestDecompression}",
                            options
                        )
                );
            }

            if (options.UseResponseCompression)
            {
                builder.Services.AddResponseCompression(options =>
                {
                    options.EnableForHttps = true;
                    options.Providers.Add<GzipCompressionProvider>();
                    options.Providers.Add<BrotliCompressionProvider>();
                    builder.Configuration.Bind(
                        $"{configurationSectionKey}:{ResponseCompression}",
                        options);
                });
            }

            if (options.UseResponseCaching)
            {
                builder.Services.AddResponseCaching(
                    options =>
                        builder.Configuration.Bind(
                            $"{configurationSectionKey}:{ResponseCaching}",
                            options
                        )
                );
            }

            if (options.UseOutputCaching)
            {
                builder.Services.AddOutputCache(
                    options =>
                        builder.Configuration.Bind(
                            $"{configurationSectionKey}:{OutputCache}",
                            options
                        )
                );
            }

            if (options.UseSession)
            {
                builder.Services.AddSession(
                    options =>
                        builder.Configuration.Bind($"{configurationSectionKey}:{Session}", options)
                );
            }

            if (options.UseFileServer && options.FileServer.EnableDirectoryBrowsing)
            {
                builder.Services.AddDirectoryBrowser();
            }

            if (options.UseCookiePolicy)
            {
                builder.Services.AddCookiePolicy(
                    policy =>
                        builder.Configuration.Bind($"{configurationSectionKey}:{Cookies}", policy)
                );
            }

            if (options.UseCors)
            {
                builder.Services.AddCors(
                    options =>
                        builder.Configuration.Bind($"{configurationSectionKey}:{Cors}", options)
                );
            }

            if (options.UseHsts)
            {
                builder.Services.AddHsts(
                    options =>
                        builder.Configuration.Bind($"{configurationSectionKey}:{Hsts}", options)
                );
            }

            if (options.IIS != null)
            {
                builder.Services.Configure<IISServerOptions>(
                    options =>
                        builder.Configuration.Bind($"{configurationSectionKey}:{IIS}", options)
                );
            }

            if (options.Kestrel != null)
            {
                builder.Services.Configure<KestrelServerOptions>(
                    options =>
                        builder.Configuration.Bind($"{configurationSectionKey}:{Kestrel}", options)
                );
            }
        }

        return builder;
    }
}
