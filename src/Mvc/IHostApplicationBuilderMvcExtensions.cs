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
using Microsoft.Extensions.Logging;
using static Dgmjr.AspNetCore.Mvc.ServiceNames;
using Microsoft.AspNetCore.Components.Server;

public static class IHostApplicationBuilderMvcExtensions
{
    private const string Mvc = nameof(Mvc);

    public static WebApplicationBuilder AddMvc(
        this WebApplicationBuilder builder,
        string configurationSectionKey = Mvc,
        ILogger? logger = null
    )
    {
        var mvcBuilder = builder.Services.AddMvc(
            options => builder.Configuration.Bind(configurationSectionKey, options)
        );

        var mvcOptionsSection = builder.Configuration.GetSection(configurationSectionKey);
        var mvcOptions = mvcOptionsSection.Get<MvcOptions>();
        builder.Services.Configure<MvcOptions>(mvcOptionsSection);
        builder.Services.Configure<MsMvcOptions>(mvc => mvcOptions.CopyTo(mvc));

        if (mvcOptions is not null)
        {
            if (mvcOptions.EnableEndpointRouting)
            {
                logger?.SettingUpMvcService(EndpointRouting);
                builder.Services.AddRouting();
            }

            if (mvcOptions.AddControllersWithViews)
            {
                logger?.SettingUpMvcService(ControllersWithViews);
                builder.Services.AddControllersWithViews();
            }

            if (mvcOptions.AddRazorPages)
            {
                logger?.SettingUpMvcService(RazorPages);
                builder.Services.AddRazorPages();
            }

            if (mvcOptions.AddControllers)
            {
                logger?.SettingUpMvcService(Controllers);
                builder.Services.AddControllers();
            }

            if (mvcOptions.AddControllersAsServices)
            {
                logger?.SettingUpMvcService(ControllersAsServices);
                mvcBuilder.AddControllersAsServices();
            }

            if (mvcOptions.AddXmlSerializerFormatters)
            {
                logger?.SettingUpMvcService(XmlSerializerFormatters);
                mvcBuilder.AddXmlSerializerFormatters();
            }

            if (mvcOptions.AddXmlDataContractSerializerFormatters)
            {
                logger?.SettingUpMvcService(XmlDataContractSerializerFormatters);
                mvcBuilder.AddXmlDataContractSerializerFormatters();
            }

            if (mvcOptions.AddMicrosoftIdentityUI)
            {
                logger?.SettingUpMvcService(MicrosoftIdentityUI);
                mvcBuilder.AddMicrosoftIdentityUI();
            }

            if (mvcOptions.AddRazorComponents)
            {
                logger?.SettingUpMvcService(RazorComponents);
                // Microsoft.Extensions.DependencyInjection.RazorComponentsServiceCollectionExtensions.AddServerSideBlazor(builder.Services);
                // builder.Services.AddRazorComponents();
            }

            if (mvcOptions.AddJsonOptions)
            {
                logger?.SettingUpMvcService(JsonSerializer);
                builder.Services.Configure<JsonOptions>(
                    options =>
                        builder.Configuration
                            .GetSection(JsonSerializer)
                            .Bind(options.JsonSerializerOptions)
                );
                builder.Services.AddSingleton<IConfigureOptions<JsonOptions>>(
                    new TypeNameAndAssemblyConfigurator<JsonOptions, JConverter>(
                        builder.Configuration,
                        $"{JsonSerializer}:{nameof(Jso.Converters)}",
                        options => options.JsonSerializerOptions.Converters
                    )
                );
            }
        }

        return builder;
    }

    public static IApplicationBuilder UseMvc(
        this IApplicationBuilder app,
        string configurationSectionKey = Mvc,
        ILogger? logger = null
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
                logger?.AddingMvcServiceToThePipeline(EndpointRouting);
                webApp?.UseRouting();
            }

            if (mvcOptions.AddControllersWithViews)
            {
                logger?.AddingMvcServiceToThePipeline(ControllersWithViews);
                webApp?.MapControllers();
            }

            if (mvcOptions.AddRazorPages)
            {
                logger?.AddingMvcServiceToThePipeline(RazorPages);
                webApp?.MapRazorPages();
            }

            if (mvcOptions.AddControllers)
            {
                logger?.AddingMvcServiceToThePipeline(Controllers);
                webApp?.MapControllers();
            }
        }
        return app;
    }
}
