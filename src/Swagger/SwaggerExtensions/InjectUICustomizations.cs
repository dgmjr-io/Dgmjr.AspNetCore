using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace Microsoft.Extensions.DependencyInjection;

internal static partial class InternalSwaggerExtensions
{
    private const string SwaggerUI = nameof(SwaggerUI);
    private const string SwaggerUI_Theme = $"{SwaggerUI}:Theme";
    private const string Classic = "classic";

    public static IApplicationBuilder InjectUICustomizations(this IApplicationBuilder app)
    {
        var theme = app.ApplicationServices.GetRequiredService<IConfiguration>()[SwaggerUI_Theme];
        // if (IsNullOrWhiteSpace(theme))
        // {
        //     theme = Classic;
        // }
        // app.UseRouting();
        // app.UseEndpoints(endpoints =>
        // {
        //     endpoints.MapGet("/swagger/swagger-ui.css", async context =>
        //     {
        //         var fileProvider = new ManifestEmbeddedFileProvider(typeof(InternalSwaggerExtensions).Assembly, "swagger-ui");
        //         var file = fileProvider.GetFileInfo("swagger-ui.css");
        //         await context.Response.SendFileAsync(file);
        //     });
        //     endpoints.MapGet($"/swagger/{theme}.css", async context =>
        //     {
        //         var fileProvider = new ManifestEmbeddedFileProvider(typeof(InternalSwaggerExtensions).Assembly, "swagger-ui");
        //         var file = fileProvider.GetFileInfo($"{theme}.css");
        //         await context.Response.SendFileAsync(file);
        //     });
        // });
        // app.UseSwaggerUI(c =>
        // {
        //     c.InjectStylesheet("/swagger/swagger-ui.css");
        //     c.InjectStylesheet($"/swagger/{theme}.css");
        // });
        return app;
    }
}
