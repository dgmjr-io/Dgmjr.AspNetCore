namespace Dgmjr.AspNetCore.Http;

using System.Security;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.AspNetCore.RequestDecompression;
using Microsoft.AspNetCore.ResponseCaching;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;

using CorsOptions = Dgmjr.AspNetCore.Http.Services.CorsOptions;

public interface IHttpServicesOptions
{
    /// <summary><see langword="true">TRUE</see> if you want to enable the welcome page, <see langword="false">FALSE</see> otherwise</summary>
    bool UseWelcomePage { get; set; }

    /// <inheritdoc cref="WelcomePageOptions" />
    WelcomePageOptions WelcomePage { get; set; }

    /// <summary><see langword="true">TRUE</see> if you want to enable the cookie policy, <see langword="false">FALSE</see> otherwise</summary>
    bool UseCookiePolicy { get; set; }

    /// <inheritdoc cref="CookiePolicyOptions" />
    CookiePolicyOptions CookiePolicy { get; set; }

    /// <inheritdoc cref="CorsOptions" />
    CorsOptions Cors { get; set; }

    /// <summary><see langword="true">TRUE</see> if you want to enable <see href="https://developer.mozilla.org/en-US/docs/Glossary/CORS">CORS</see>, <see langword="false">FALSE</see> otherwise</summary>
    bool UseCors { get; set; }

    /// <inheritdoc cref="FileServerOptions" />
    FileServerOptions FileServer { get; set; }

    /// <summary><see langword="true">TRUE</see> if you want to enable the files middlewares, <see langword="false">FALSE</see> otherwise</summary>
    bool UseFileServer { get; set; }

    /// <summary><see langword="true">TRUE</see> if you want to enable the static files middleware, <see langword="false">FALSE</see> otherwise</summary>
    bool UseStaticFiles { get; set; }

    /// <summary><see langword="true">TRUE</see> if you want to enable the forwarded headers middleware, <see langword="false">FALSE</see> otherwise</summary>
    bool UseForwardedHeaders { get; set; }

    /// <inheritdoc cref="HstsOptions" />
    ForwardedHeadersOptions ForwardedHeaders { get; set; }

    /// <inheritdoc cref="HstsOptions" />
    HstsOptions Hsts { get; set; }

    /// <summary><see langword="true">TRUE</see> if you want to enable the HSTS middleware, <see langword="false">FALSE</see> otherwise</summary>
    bool UseHsts { get; set; }

    /// <inheritdoc cref="HttpsRedirectionOptions" />
    HttpsRedirectionOptions HttpsRedirection { get; set; }

    /// <summary><see langword="true">TRUE</see> if you want to enable HTTPS redirection, <see langword="false">FALSE</see> otherwise</summary>
    bool UseHttpsRedirection { get; set; }

    /// <inheritdoc cref="IISServerOptions" />
    IISServerOptions IIS { get; set; }

    /// <inheritdoc cref="KestrelServerOptions" />
    KestrelServerOptions Kestrel { get; set; }

    /// <inheritdoc cref="OutputCacheOptions" />
    OutputCacheOptions OutputCache { get; set; }

    /// <summary><see langword="true">TRUE</see> if you want to enable the output caching middleware, <see langword="false">FALSE</see> otherwise</summary>
    bool UseOutputCaching { get; set; }

    /// <inheritdoc cref="RequestDecompressionOptions" />
    RequestDecompressionOptions RequestDecompression { get; set; }

    /// <summary><see langword="true">TRUE</see> if you want to enable the request decompression middleware, <see langword="false">FALSE</see> otherwise</summary>
    bool UseRequestDecompression { get; set; }

    /// <inheritdoc cref="ResponseCachingOptions" />
    ResponseCachingOptions ResponseCaching { get; set; }

    /// <summary><see langword="true">TRUE</see> if you want to enable the response caching middleware, <see langword="false">FALSE</see> otherwise</summary>
    bool UseResponseCaching { get; set; }

    /// <inheritdoc cref="ResponseCompressionOptions" />
    ResponseCompressionOptions ResponseCompression { get; set; }

    /// <summary><see langword="true">TRUE</see> if you want to enable the response compression middleware, <see langword="false">FALSE</see> otherwise</summary>
    bool UseResponseCompression { get; set; }

    /// <inheritdoc cref="SessionOptions" />
    SessionOptions Session { get; set; }

    /// <summary><see langword="true">TRUE</see> if you want to enable the session middleware, <see langword="false">FALSE</see> otherwise</summary>
    bool UseSession { get; set; }

    /// <summary><see langword="true">TRUE</see> if you want to add an <see cref="Microsoft.AspNetCore.Http.IHttpContextAccessor" /> to the DI container, <see langword="false">FALSE</see> otherwise</summary>
    bool AddHttpContextAccessor { get; set; }

    /// <summary><see langword="true">TRUE</see> if you want to enable the exception handling middleware, <see langword="false">FALSE</see> otherwise</summary>
    bool UseExceptionHandler { get; set; }

    /// <inheritdoc cref="ExceptionHandlerOptions" />
    ExceptionHandlerOptions ExceptionHandling { get; set; }
}

public class HttpServicesOptions : IHttpServicesOptions
{
    public bool UseWelcomePage { get; set; } = true;
    public WelcomePageOptions WelcomePage { get; set; } = new() { Path = "/welcome" };

    public bool UseCookiePolicy { get; set; } = true;
    public CookiePolicyOptions CookiePolicy { get; set; } = new();

    public CorsOptions Cors { get; set; } = new();
    public bool UseCors { get; set; } = true;

    public FileServerOptions FileServer { get; set; } = DefaultFilFileServerOptions;
    public bool UseFileServer { get; set; } = false;

    private static FileServerOptions _defaultFileServerOptions;
    private static FileServerOptions DefaultFilFileServerOptions
    {
        get
        {
            if (_defaultFileServerOptions is not null)
            {
                return _defaultFileServerOptions;
            }

            _defaultFileServerOptions = new FileServerOptions
            {
                EnableDefaultFiles = true,
                EnableDirectoryBrowsing = true
            };
            _defaultFileServerOptions.StaticFileOptions.ServeUnknownFileTypes = true;
            _defaultFileServerOptions.StaticFileOptions.DefaultContentType = Dgmjr
                .Mime
                .Application
                .OctetStream
                .DisplayName;
            // _defaultFileServerOptions.FileProvider = new PhysicalFileProvider(Path.Join(Directory.GetCurrentDirectory(), "wwwroot"));
            // _defaultFileServerOptions.DefaultFilesOptions.FileProvider =_defaultFileServerOptions.FileProvider;
            _defaultFileServerOptions.DefaultFilesOptions.DefaultFileNames = new List<string>
            {
                "index.html",
                "index.htm",
                "swagger.json"
            };
            _defaultFileServerOptions.StaticFileOptions.ContentTypeProvider =
                new Dgmjr.AspNetCore.StaticFiles.MimeKitContentTypeProvider();
            // _defaultFileServerOptions.DirectoryBrowserOptions.FileProvider = _defaultFileServerOptions.FileProvider;
            _defaultFileServerOptions.DirectoryBrowserOptions.RequestPath = "/wwwroot";
            return _defaultFileServerOptions;
        }
    }

    public bool UseStaticFiles { get; set; } = true;

    public bool UseForwardedHeaders { get; set; } = false;
    public ForwardedHeadersOptions ForwardedHeaders { get; set; } = new();

    public HstsOptions Hsts { get; set; } = new();
    public bool UseHsts { get; set; } = true;

    public HttpsRedirectionOptions HttpsRedirection { get; set; } = new();
    public bool UseHttpsRedirection { get; set; } = true;

    public IISServerOptions IIS { get; set; } = new();

    public KestrelServerOptions Kestrel { get; set; } = new();

    public OutputCacheOptions OutputCache { get; set; } = new();
    public bool UseOutputCaching { get; set; } = true;

    public RequestDecompressionOptions RequestDecompression { get; set; } = new();
    public bool UseRequestDecompression { get; set; } = true;

    public ResponseCachingOptions ResponseCaching { get; set; } = new();
    public bool UseResponseCaching { get; set; } = true;

    public ResponseCompressionOptions ResponseCompression { get; set; } =
        new() { MimeTypes = ResponseCompressionDefaults.MimeTypes };
    public bool UseResponseCompression { get; set; } = true;

    public SessionOptions Session { get; set; } =
        new()
        {
            Cookie = new() { Name = SessionDefaults.CookieName, Path = SessionDefaults.CookiePath }
        };
    public bool UseSession { get; set; } = true;

    public bool AddHttpContextAccessor { get; set; } = true;

    public bool UseExceptionHandler { get; set; } = true;
    public ExceptionHandlerOptions ExceptionHandling { get; set; } =
        new() { ExceptionHandlingPath = "/error" };
}
