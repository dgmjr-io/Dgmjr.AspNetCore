namespace Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Dgmjr.AspNetCore.Http;
using System.Runtime.Serialization;
using AspNetCorsOptions = Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Logging;
using Dgmjr.AspNetCore.Http.Services;

public static partial class HttpServicesExtensions
{
    public static IApplicationBuilder UseHttpServices(this IApplicationBuilder app, ILogger logger = null)
    {
        var options = app.ApplicationServices.GetRequiredService<IOptions<HttpServicesOptions>>().Value;

        if (options.UseRequestDecompression)
        {
            logger?.AddingHttpServiceToThePipeline(nameof(RequestDecompression));
            app.UseRequestDecompression();
        }

        if (options.UseResponseCompression)
        {
            logger?.AddingHttpServiceToThePipeline(nameof(ResponseCompression));
            app.UseResponseCompression();
        }

        if (options.UseFileServer)
        {
            logger?.AddingHttpServiceToThePipeline(nameof(options.FileServer));
            app.UseFileServer(options.FileServer);

            if (options.FileServer.EnableDefaultFiles)
            {
                app.UseDefaultFiles(options.FileServer.DefaultFilesOptions);
            }

            if (options.FileServer.EnableDirectoryBrowsing)
            {
                app.UseDirectoryBrowser(options.FileServer.DirectoryBrowserOptions);
            }

            if (options.FileServer.StaticFileOptions != null || options.UseStaticFiles)
            {
                app.UseStaticFiles(options.FileServer.StaticFileOptions);
            }
        }

        if (options.UseResponseCaching)
        {
            logger?.AddingHttpServiceToThePipeline(nameof(ResponseCaching));
            app.UseResponseCaching();
        }

        if (options.UseForwardedHeaders)
        {
            logger?.AddingHttpServiceToThePipeline(nameof(options.ForwardedHeaders));
            app.UseForwardedHeaders(options.ForwardedHeaders);
        }

        if (options.UseCors)
        {
            logger?.AddingHttpServiceToThePipeline(nameof(Cors));
            var corsOptions = app.ApplicationServices.GetRequiredService<IOptions<AspNetCorsOptions>>().Value;
            app.UseCors(builder =>
            {
            var defaultPolicy = corsOptions.GetPolicy(options.Cors.DefaultPolicyName);
            builder.WithExposedHeaders([..defaultPolicy.ExposedHeaders])
                    .WithHeaders([..defaultPolicy.Headers])
                    .WithMethods([..defaultPolicy.Methods])
                    .WithOrigins([..defaultPolicy.Origins])

                    .SetPreflightMaxAge(defaultPolicy.PreflightMaxAge ?? duration.Zero);
            if (defaultPolicy.AllowAnyHeader)
            {
                builder.AllowAnyHeader();
            }
            if (defaultPolicy.AllowAnyMethod)
            {
                builder.AllowAnyMethod();
            }
            if (defaultPolicy.AllowAnyOrigin)
            {
                builder.AllowAnyOrigin();
            }
        });
        // _ = app.UseCors(corsOptions => corsOptions
        //     .WithExposedHeaders(options.Cors.GetPolicy(options.Cors.DefaultPolicyName).ExposedHeaders.ToArray())
        //     .WithHeaders(options.Cors.GetPolicy(options.Cors.DefaultPolicyName).Headers.ToArray())
        //     .WithMethods(options.Cors.GetPolicy(options.Cors.DefaultPolicyName).Methods.ToArray())
        //     .WithOrigins(options.Cors.GetPolicy(options.Cors.DefaultPolicyName).Origins.ToArray())
        //     .SetPreflightMaxAge(options.Cors.GetPolicy(options.Cors.DefaultPolicyName).PreflightMaxAge ?? TimeSpan.Zero)
        // );
    }

        if(options.UseCookiePolicy)
        {
            logger?.AddingHttpServiceToThePipeline(Cookies);
    app.UseCookiePolicy(options.CookiePolicy);
        }

        if(options.UseSession)
        {
            logger?.AddingHttpServiceToThePipeline(Session);
app.UseSession(options.Session);
        }

if (options.UseHsts)
{
    logger?.AddingHttpServiceToThePipeline(Hsts);
    app.UseHsts();
}

if (options.UseHttpsRedirection)
{
    logger?.AddingHttpServiceToThePipeline(nameof(options.UseHttpsRedirection));
    app.UseHttpsRedirection();
}

if (options.ExceptionHandling?.UseDeveloperExceptionPage == true)
{
    logger?.AddingHttpServiceToThePipeline($"{nameof(options.ExceptionHandling)}:{nameof(options.ExceptionHandling.UseDeveloperExceptionPage)}");
    app.UseDeveloperExceptionPage();
}

if (options.UseExceptionHandler)
{
    logger?.AddingHttpServiceToThePipeline(nameof(options.ExceptionHandling));
    app.UseExceptionHandler(options.ExceptionHandling);
}

if (options.UseWelcomePage)
{
    logger?.AddingHttpServiceToThePipeline(nameof(options.WelcomePage));
    app.UseWelcomePage(options.WelcomePage);
}

return app;
    }
}
