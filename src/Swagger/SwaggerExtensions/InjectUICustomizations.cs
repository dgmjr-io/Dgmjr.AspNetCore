using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace Microsoft.Extensions.DependencyInjection;

public static partial class SwaggerExtensions
{
    private const string SwaggerUITheme = $"{SwaggerUI}:Theme";
    private const string Classic = "classic";

    internal static IApplicationBuilder InjectUICustomizations(this IApplicationBuilder app)
    {
        var theme = app.ApplicationServices.GetRequiredService<IConfiguration>()[SwaggerUITheme];
        if (IsNullOrWhiteSpace(theme))
        {
            theme = Classic;
        }
        app.UseStaticFiles();
        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new EmbeddedFileProvider(typeof(SwaggerExtensions).Assembly, "Dgmjr.AspNetCore.Swagger"),
            RequestPath = "/swagger"
        });
        app.UseSwaggerUI(c =>
        {
            c.InjectStylesheet("/swagger/swagger-ui.css");
            c.InjectStylesheet($"/swagger/{theme}.css");
        });
        return app;
    }
}
