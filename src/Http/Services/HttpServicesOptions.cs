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

public class HttpServicesOptions
{
    public bool UseWelcomePage { get; set; } = true;
    public WelcomePageOptions WelcomePage { get; set; } = new () { Path = "/welcome" };

    public bool UseCookiePolicy { get; set; } = true;
    public CookiePolicyOptions CookiePolicy { get; set; } = new();

    public CorsOptions Cors { get; set; } = [];
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
            _defaultFileServerOptions.StaticFileOptions.DefaultContentType = Dgmjr.Mime.Application.OctetStream.DisplayName;
            // _defaultFileServerOptions.FileProvider = new PhysicalFileProvider(Path.Join(Directory.GetCurrentDirectory(), "wwwroot"));
            // _defaultFileServerOptions.DefaultFilesOptions.FileProvider =_defaultFileServerOptions.FileProvider;
            _defaultFileServerOptions.DefaultFilesOptions.DefaultFileNames = new List<string> { "index.html", "index.htm", "swagger.json" };
            _defaultFileServerOptions.StaticFileOptions.ContentTypeProvider = new Dgmjr.AspNetCore.StaticFiles.MimeKitContentTypeProvider();
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

    public ResponseCompressionOptions ResponseCompression { get; set; } = new() { MimeTypes = ResponseCompressionDefaults.MimeTypes };
    public bool UseResponseCompression { get; set; } = true;

    public SessionOptions Session { get; set; } = new() { Cookie = new() { Name = SessionDefaults.CookieName, Path = SessionDefaults.CookiePath } };
    public bool UseSession { get; set; } = true;

    public bool AddHttpContextAccessor { get; set; } = true;

    public bool UseExceptionHandler { get; set; } = true;
    public ExceptionHandlerOptions ExceptionHandling { get; set; } = new() { ExceptionHandlingPath = "/error" };
}
