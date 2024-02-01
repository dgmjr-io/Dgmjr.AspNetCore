namespace Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

using Dgmjr.AspNetCore.Http;
using Dgmjr.AspNetCore.Http.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

public static partial class HttpServicesExtensions
{
    public const string Http = nameof(Http);
    public const string RequestDecompression = nameof(RequestDecompression);
    public const string ResponseCompression = nameof(ResponseCompression);
    public const string ResponseCaching = nameof(ResponseCaching);
    public const string Cookies = nameof(Cookies);
    public const string Cors = nameof(Cors);
    public const string Hsts = nameof(Hsts);
    public const string OutputCache = nameof(OutputCache);
    public const string Session = nameof(Session);
    public const string IIS = nameof(IIS);
    public const string Kestrel = nameof(Kestrel);
    public const string ExceptionHandling = nameof(ExceptionHandling);

    public static WebApplicationBuilder AddHttpServices(
        this WebApplicationBuilder builder,
        string configurationSectionKey = Http,
        ILogger? logger = null
    )
    {
        var options = builder.Configuration
            .GetSection(configurationSectionKey)
            .Get<HttpServicesOptions>();

        builder.Services.Configure<HttpServicesOptions>(
            options => builder.Configuration.Bind(configurationSectionKey, options)
        );

        if (options is not null)
        {
            if (options.UseRequestDecompression)
            {
                logger?.SettingUpHttpService(RequestDecompression, options.RequestDecompression);
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
                logger?.SettingUpHttpService(ResponseCompression, options.ResponseCompression);
                builder.Services.AddResponseCompression(options =>
                {
                    options.EnableForHttps = true;
                    options.Providers.Add<GzipCompressionProvider>();
                    options.Providers.Add<BrotliCompressionProvider>();
                    builder.Configuration.Bind(
                        $"{configurationSectionKey}:{ResponseCompression}",
                        options
                    );
                });
            }

            if (options.UseResponseCaching)
            {
                logger?.SettingUpHttpService(ResponseCaching, options.ResponseCaching);
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
                logger?.SettingUpHttpService(OutputCache, options.OutputCache);
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
                logger?.SettingUpHttpService(Session, options.Session);
                builder.Services.AddSession(
                    options =>
                        builder.Configuration.Bind($"{configurationSectionKey}:{Session}", options)
                );
            }

            if (options.UseFileServer && options.FileServer.EnableDirectoryBrowsing)
            {
                logger?.SettingUpHttpService(
                    $"{nameof(options.FileServer)}:{nameof(options.FileServer.EnableDirectoryBrowsing)}",
                    options.FileServer
                );
                builder.Services.AddDirectoryBrowser();
            }

            if (options.UseCookiePolicy)
            {
                logger?.SettingUpHttpService(Cookies, options.CookiePolicy);
                builder.Services.AddCookiePolicy(
                    policy =>
                        builder.Configuration.Bind($"{configurationSectionKey}:{Cookies}", policy)
                );
            }

            logger?.SettingUpHttpService(Cors, options.Cors);
            builder.Services.AddCors();

            if (options.UseCors)
            {
                builder.Services.Configure<CorsOptions>(
                    options => new CorsOptionsConfigurator(builder.Configuration).Configure(options)
                );
                builder.Services.AddCors(
                    new CorsOptionsConfigurator(builder.Configuration).Configure
                );
            }

            if (options.UseHsts)
            {
                logger?.SettingUpHttpService(Hsts, options.Hsts);
                builder.Services.AddHsts(
                    options =>
                        builder.Configuration.Bind($"{configurationSectionKey}:{Hsts}", options)
                );
            }

            if (options.IIS != null)
            {
                logger?.SettingUpHttpService(IIS, options.IIS);
                builder.Services.Configure<IISServerOptions>(
                    options =>
                        builder.Configuration.Bind($"{configurationSectionKey}:{IIS}", options)
                );
            }

            if (options.Kestrel != null)
            {
                logger?.SettingUpHttpService(Kestrel, options.Kestrel);
                builder.Services.Configure<KestrelServerOptions>(
                    options =>
                        builder.Configuration.Bind($"{configurationSectionKey}:{Kestrel}", options)
                );
            }

            if (options.ExceptionHandling != null)
            {
                logger?.SettingUpHttpService(ExceptionHandling, options.ExceptionHandling);
                builder.Services.Configure<Dgmjr.AspNetCore.Http.ExceptionHandlerOptions>(
                    options =>
                        builder.Configuration.Bind(
                            $"{configurationSectionKey}:{ExceptionHandling}",
                            options
                        )
                );
            }

            if (options.AddHttpContextAccessor)
            {
                logger?.SettingUpHttpService(nameof(IHttpContextAccessor), options.AddHttpContextAccessor);
                builder.Services.AddHttpContextAccessor();
                builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            }
        }

        return builder;
    }
}
