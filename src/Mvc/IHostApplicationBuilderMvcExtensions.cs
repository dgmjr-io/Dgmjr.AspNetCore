namespace Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
#if NET5_0_OR_GREATER
using Microsoft.AspNetCore.Mvc.RazorPages;
#endif
using MvcOptions = Dgmjr.AspNetCore.Mvc.MvcOptions;
using Microsoft.Identity.Web.UI;

public static class IHostApplicationBuilderMvcExtensions
{
    private const string Mvc = nameof(Mvc);
    private const string JsonSerializer = nameof(JsonSerializer);

    public static WebApplicationBuilder AddMvc(
        this WebApplicationBuilder builder,
        string configurationSectionKey = Mvc
    )
    {
        var mvcBuilder = builder.Services.AddMvc(
            options => builder.Configuration.Bind(configurationSectionKey, options)
        );

        var mvcOptionsSection = builder.Configuration.GetSection(configurationSectionKey);
        builder.Services.Configure<MvcOptions>(mvcOptionsSection);
        var mvcOptions = mvcOptionsSection.Get<MvcOptions>();

        if (mvcOptions is not null)
        {
            if (mvcOptions.EnableEndpointRouting)
            {
                builder.Services.AddRouting();
            }

            if (mvcOptions.AddControllersWithViews)
            {
                builder.Services.AddControllersWithViews();
            }

            if (mvcOptions.AddRazorPages)
            {
                builder.Services.AddRazorPages();
            }

            if (mvcOptions.AddControllers)
            {
                builder.Services.AddControllers();
            }

            if (mvcOptions.AddControllersAsServices)
            {
                mvcBuilder.AddControllersAsServices();
            }

            if (mvcOptions.AddXmlSerializerFormatters)
            {
                mvcBuilder.AddXmlSerializerFormatters();
            }

            if (mvcOptions.AddXmlDataContractSerializerFormatters)
            {
                mvcBuilder.AddXmlDataContractSerializerFormatters();
            }

            if (mvcOptions.AddMicrosoftIdentityUI)
            {
                mvcBuilder.AddMicrosoftIdentityUI();
            }

            if (mvcOptions.AddMvcConventions)
            {
                // mvcBuilder.AddMvcOptions(options => builder.Configuration.Bind(configurationSectionKey, options));
            }

            if (mvcOptions.AddJsonOptions)
            {
                builder.Services.Configure<JsonOptions>(
                    options =>
                        builder.Configuration
                            .GetSection(JsonSerializer)
                            .Bind(options.JsonSerializerOptions)
                );
            }
        }

        return builder;
    }

    public static IApplicationBuilder UseMvc(
        this IApplicationBuilder app,
        string configurationSectionKey = Mvc
    )
    {
        var webApp = app as WebApplication;
        var mvcOptionsSection = app.ApplicationServices
            .GetRequiredService<IConfiguration>()
            .GetSection(configurationSectionKey);
        var mvcOptions = mvcOptionsSection.Get<MvcOptions>();

        if (mvcOptions is not null)
        {
            if (mvcOptions.EnableEndpointRouting)
            {
                webApp?.UseRouting();
            }

            if (mvcOptions.AddControllersWithViews)
            {
                webApp?.MapControllers();
            }

            if (mvcOptions.AddRazorPages)
            {
                webApp?.MapRazorPages();
            }

            if (mvcOptions.AddControllers)
            {
                webApp?.MapControllers();
            }
        }
        return app;
    }
}
