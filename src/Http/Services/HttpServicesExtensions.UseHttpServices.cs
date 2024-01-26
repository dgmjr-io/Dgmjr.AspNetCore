namespace Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Dgmjr.AspNetCore.Http;
using System.Runtime.Serialization;
using AspNetCorsOptions = Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions;
using Microsoft.AspNetCore.Cors.Infrastructure;

public static partial class HttpServicesExtensions
{
    public static IApplicationBuilder UseHttpServices(this IApplicationBuilder app)
    {
        var options = app.ApplicationServices.GetRequiredService<IOptions<HttpServicesOptions>>().Value;

        if (options.UseRequestDecompression)
        {
            app.UseRequestDecompression();
        }

        if (options.UseResponseCompression)
        {
            app.UseResponseCompression();
        }

        if (options.UseFileServer)
        {
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
            app.UseResponseCaching();
        }

        if (options.UseForwardedHeaders)
        {
            app.UseForwardedHeaders(options.ForwardedHeaders);
        }

        if (options.UseCors)
        {
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
            app.UseCookiePolicy(options.CookiePolicy);
        }

        if(options.UseSession)
        {
            app.UseSession(options.Session);
        }

if (options.UseHsts)
{
    app.UseHsts();
}

if (options.UseHttpsRedirection)
{
    app.UseHttpsRedirection();
}

if (options.ExceptionHandling?.UseDeveloperExceptionPage == true)
{
    app.UseDeveloperExceptionPage();
}

if (options.UseExceptionHandler)
{
    app.UseExceptionHandler(options.ExceptionHandling);
}

if (options.UseWelcomePage)
{
    app.UseWelcomePage(options.WelcomePage);
}

return app;
    }
}
