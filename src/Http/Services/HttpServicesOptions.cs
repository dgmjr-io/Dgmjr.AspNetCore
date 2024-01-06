namespace Dgmjr.AspNetCore.Http.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.RequestDecompression;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.OutputCaching;
using System.Security;
using Microsoft.AspNetCore.ResponseCaching;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Cors.Infrastructure;

public class HttpServicesOptions
{
    /// <summary><see langword="true"/> to add <see cref="RequestDecompressionMiddleware"/> to the request pipeline, <see langword="false" /> to leave it out.</summary>
    public bool UseRequestDecompression { get; set; } = true;

    public RequestDecompressionOptions RequestDecompression { get; set; } = new();

    /// <summary><see langword="true"/> to add <see cref="ResponseCompressionMiddleware"/> to the request pipeline, <see langword="false" /> otherwise.</summary>
    public bool UseResponseCompression { get; set; } = true;

    /// <summary><see langword="true"/> to add <see cref="StaticFileMiddleware"/> to the request pipeline, <see langword="false" /> otherwise.</summary>
    public bool UseFileServer { get; set; } = false;

    public FileServerOptions FileServer { get; set; } = new();

    /// <summary>If set to <see langword="true" />, enables the settings in <see cref-"ForwardedHeadersOptions" />. otherwise it doesn't add or enable the ForwardedHeaders middleware.</summary>
    public bool UseForwardedHeaders { get; set; } = false;

    /// <summary></summary>
    /// <returns></returns>
    public ForwardedHeadersOptions ForwardedHeaders { get; set; } = new();

    public bool UseOutputCaching { get; set; } = true;

    public OutputCacheOptions OutputCache { get; set; } = new();

    public bool UseResponseCaching { get; set; } = true;

    public ResponseCachingOptions ResponseCaching { get; set; } = new();

    public bool UseHsts { get; set; } = true;

    public HstsOptions Hsts { get; set; } = new();

    public KestrelServerOptions Kestrel { get; set; } = new();

    public IISServerOptions IIS { get; set; } = new();

    public bool UseHttpsRedirection { get; set; } = true;

    public HttpsRedirectionOptions HttpsRedirection { get; set; } = new();

    public bool UseCookiePolicy { get; set; } = true;

    public CookiePolicyOptions CookiePolicy { get; set; } = new();

    public bool UseCors { get; set; } = true;

    public CorsOptions Cors { get; set; } = new();

    public bool UseSession { get; set; } = true;

    public SessionOptions Session { get; set; } = new();
}
