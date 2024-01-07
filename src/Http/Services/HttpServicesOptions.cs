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

public class HttpServicesOptions
{
    public bool UseCookiePolicy { get; set; } = true;
    public CookiePolicyOptions CookiePolicy { get; set; } = new();

    public CorsOptions Cors { get; set; } = new();
    public bool UseCors { get; set; } = true;

    public FileServerOptions FileServer { get; set; } = new();
    public bool UseFileServer { get; set; } = false;

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
}
