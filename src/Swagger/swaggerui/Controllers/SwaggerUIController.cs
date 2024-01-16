namespace Dgmjr.AspNetCore.Swagger.UI;
using System.Net.Http;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

using Swashbuckle.AspNetCore.Annotations;
using Dgmjr.Mime;
using MimeKit;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

[Route("/swagger-ui/{documentName}")]
public partial class SwaggerUIController(ILogger<SwaggerUIController> logger, HttpClient httpClient, IDistributedCache cache, IOptionsMonitor<SwaggerUIOptions> options, IOptionsMonitor<SwaggerOptions> swaggerOptions, IOptionsMonitor<SwaggerGenOptions> swaggerGenOptions) : ControllerBase, ILog
{
    private const string Swagger_UI = "Swagger UI";
    private string SwaggerUIIndex_Html => $"swaggerui.{Options.SwaggerUI}.index.html";
    private string SwaggerUIInit_js => $"swaggerui.{Options.SwaggerUI}.swagger-ui-init.js";
    private string SwaggerUI => $"swaggerui.{Options.SwaggerUI}";
    private string BaseUrl => Options.ReverseProxyEndpoint;
    public ILogger Logger => logger;
    private SwaggerUIOptions Options => options.CurrentValue;
    private SwaggerOptions SwaggerOptions => swaggerOptions.CurrentValue;
    private SwaggerGenOptions SwaggerGenOptions => swaggerGenOptions.CurrentValue;

    private readonly Jso _jso = new ()  { WriteIndented = false, DefaultIgnoreCondition = JIgnore.Never, IgnoreReadOnlyProperties = true, PropertyNamingPolicy = JNaming.CamelCase, DictionaryKeyPolicy = JNaming.CamelCase };
    private ConfigObject ConfigObject => Options.ConfigObject;
    private OAuthConfigObject OAuthConfigObject => Options.OAuthConfigObject;
    private InterceptorFunctions Interceptors => Options.Interceptors;
    private string ConfigObjectJson => Serialize(ConfigObject, _jso).Replace("\n", " ").Replace("\r", " ");
    private string OAuthConfigObjectJson => Serialize(OAuthConfigObject, _jso).Replace("\n", " ").Replace("\r", " ");
    private string InterceptorsJson => Serialize(Interceptors, _jso).Replace("\n", " ").Replace("\r", " ");

    private readonly IDistributedCache _cache = cache;
    private readonly HttpClient _httpClient = httpClient;

    [HttpGet("{**swaggerUiFileName}")]
    [SwaggerOperation(Summary = "Swagger UI Documents", Description = "Retrieves Swagger UI Documents", Tags = [ Swagger_UI ], OperationId = "SwaggerUIDocuments")]
    [Produces(Text.Html.DisplayName, Application.Json.DisplayName, Application.JavaScript.DisplayName, Application.Xml.DisplayName, Application.Zip.DisplayName, Application.Pdf.DisplayName, Application.Rtf.DisplayName)]
    public async Task<IActionResult> GetSwaggerUIFileAsync(string swaggerUiFileName)
    {
        if(Options.UseReverseProxy)
        {
            var cacheKey = $"{SwaggerUI}-{swaggerUiFileName}";
            var document = Options.UseCache ? await _cache.GetAsync(cacheKey) : null;
            var extension = Path.GetExtension(swaggerUiFileName);
            if (document is not null)
            {
                Logger.CacheHit(cacheKey);
                return File(document, MimeTypes.GetMimeType(extension));
            }
            Logger.CacheMiss(cacheKey);
            Logger.Get($"{BaseUrl}{swaggerUiFileName}");
            var content = await _httpClient.GetByteArrayAsync($"{BaseUrl}{swaggerUiFileName}");
            await _cache.SetAsync(cacheKey, content);
            return File(content, MimeTypes.GetMimeType(extension));
        }
        else
        {
            var document = await GetType().Assembly.GetManifestResourceStream(SwaggerUIIndex_Html).ReadAllBytesAsync();
            var extension = Path.GetExtension(swaggerUiFileName);
            return File(document, MimeTypes.GetMimeType(extension), fileDownloadName: swaggerUiFileName);
        }
    }

    [HttpGet("index.html")]
    [SwaggerOperation(Summary = "Swagger UI index.html", Description = "Retrieves Swagger UI index.html", Tags = [ Swagger_UI ], OperationId = "SwaggerUIIndexHtml")]
    [Produces(Text.Html.DisplayName)]
    public async Task<IActionResult> GetSwaggerUIIndexAsync()
    {
        if(Options.UseReverseProxy && Options.SwaggerUI is not UI.SwaggerUI.Bootstrap)
        {
            return await GetSwaggerUIFileAsync("index.html");
        }

        var cacheKey = SwaggerUIIndex_Html;
        var document = Options.UseCache ? await _cache.GetAsync(cacheKey) : null;
        if (document is not null)
        {
            Logger.CacheHit(cacheKey);
            return File(document, Text.Html.DisplayName);
        }
        Logger.CacheMiss(cacheKey);
        var content = await GetType().Assembly.GetManifestResourceStream(SwaggerUIIndex_Html).ReadAllBytesAsync();
        await _cache.SetAsync(cacheKey, content);
        return File(content, Text.Html.DisplayName);
    }

    [HttpGet("assets/swagger-ui.js")]
    [SwaggerOperation(Summary = "Swagger UI swagger-ui.js", Description = "Retrieves Swagger UI swagger-ui.js", Tags = [ Swagger_UI ], OperationId = "SwaggerUISwaggerUIJs")]
    [Produces(Application.JavaScript.DisplayName)]
    public async Task<IActionResult> GetSwaggerUIJsAsync()
    {
        if(Options.UseReverseProxy && Options.SwaggerUI is not UI.SwaggerUI.Bootstrap)
        {
            return await GetSwaggerUIFileAsync("swagger-ui.js");
        }

        var cacheKey = $"{SwaggerUI}-swagger-ui.js";
        var contentBytes = Options.UseCache ? await _cache.GetAsync(cacheKey) : null;
        if (contentBytes is not null)
        {
            Logger.CacheHit(cacheKey);
        }
        else
        {
            Logger.CacheMiss(cacheKey);
            contentBytes = await _httpClient.GetByteArrayAsync($"{BaseUrl}/assets/swagger-ui.js");
        }
        var stringContent = contentBytes.ToUTF8String();

        stringContent = stringContent.Replace("definitions", "schemas");
        contentBytes = stringContent.ToUTF8Bytes();

        await _cache.SetAsync(cacheKey, contentBytes);
        return File(contentBytes, Text.Html.DisplayName);
    }

    [HttpGet("swagger-ui-init.js")]
    [SwaggerOperation(Summary = "Swagger UI Init", Description = "Swagger UI Init", Tags = [ Swagger_UI ], OperationId = "SwaggerUIInit")]
    [Produces(Application.JavaScript.DisplayName)]
    public async Task<IActionResult> GetSwaggerUIIInitJsAsync()
    {
        var cacheKey = $"{SwaggerUI}-swagger-ui-init.js";
        var document = Options.UseCache ? await _cache.GetAsync(cacheKey) : null;
        if (document is not null)
        {
            Logger.CacheHit(cacheKey);
            return File(document, Text.Html.DisplayName);
        }
        Logger.CacheMiss(cacheKey);
        var content = await GetType().Assembly.ReadAssemblyResourceAllTextAsync(SwaggerUIInit_js);
        content = content.Replace("${ConfigObject}", ConfigObjectJson);
        content = content.Replace("${OAuthConfigObject}", OAuthConfigObjectJson);
        content = content.Replace("${Interceptors}", InterceptorsJson);
        var contentBytes = content.ToUTF8Bytes();
        await _cache.SetAsync(cacheKey, contentBytes);
        return File(contentBytes, Text.Html.DisplayName);
    }

    [HttpGet("swagger.json")]
    public async Task<IActionResult> GetSwaggerJsonAsync([FromRoute] string documentName)
    {
        var cacheKey = $"{SwaggerUI}-{documentName}";
        var documentBytes = Options.UseCache ? await _cache.GetAsync(cacheKey) : null;
        if (documentBytes is not null)
        {
            Logger.CacheHit(cacheKey);
        }
        else
        {
            Logger.CacheMiss(cacheKey);
            var baseServerUri = GetBaseServerUri();
            var requestUri = $"{baseServerUri}/{SwaggerOptions.RouteTemplate.Replace("{documentName}", documentName)}";
            Logger.LogTrace($"Swagger document request URI: {requestUri}");
            documentBytes = await _httpClient.GetByteArrayAsync(requestUri);
            await _cache.SetAsync(cacheKey, documentBytes);
        }
        return File(documentBytes, ApplicationMediaTypeNames.OpenApiJson);
    }

    private string GetBaseServerUri()
    {
        var request = HttpContext.Request;
        var scheme = request.Scheme;
        var host = request.Host;
        // var pathBase = request.PathBase;
        var port = request.Host.Port;
        var baseUri = $"{scheme}://{host}";
        Logger.LogTrace($"scheme: {scheme}");
        Logger.LogTrace($"host: {host}");
        Logger.LogTrace($"port: {port}");
        Logger.LogTrace($"baseUri: {baseUri}");
        return baseUri;
    }
}
