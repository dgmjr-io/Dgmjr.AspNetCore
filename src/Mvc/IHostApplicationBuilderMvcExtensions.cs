namespace Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
#if NET5_0_OR_GREATER
using Microsoft.AspNetCore.Mvc.RazorPages;
#endif

public static class IHostApplicationBuilderMvcExtensions
{
    private const string Mvc = nameof(Mvc);
    private const string JsonSerializer = nameof(JsonSerializer);

    public static IHostApplicationBuilder AddMvc(this IHostApplicationBuilder builder, string configurationSectionKey = Mvc)
    {
        var mvcBuilder = builder.Services.AddMvcCore(options => builder.Configuration.Bind(configurationSectionKey, options));

        var mvcOptions = builder.Configuration.GetSection(configurationSectionKey).Get<MvcOptions>();

        if(mvcOptions is not null)
        {
#if NET5_0_OR_GREATER
            if(mvcOptions.EnableEndpointRouting)
            {
                builder.Services.AddRouting();
            }

            if(mvcOptions.AddControllersWithViews)
            {
                builder.Services.AddControllersWithViews();
            }

            if(mvcOptions.AddRazorPages)
            {
                mvcBuilder.AddRazorPages();
            }
#endif
            if(mvcOptions.AddControllersAsServices)
            {
                mvcBuilder.AddControllersAsServices();
            }

            if(mvcOptions.AddXmlSerializerFormatters)
            {
                mvcBuilder.AddXmlSerializerFormatters();
            }

            if(mvcOptions.AddXmlDataContractSerializerFormatters)
            {
                mvcBuilder.AddXmlDataContractSerializerFormatters();
            }

            if(mvcOptions.AddJsonOptions)
            {
                mvcBuilder.AddJsonOptions(options => builder.Configuration.Bind(JsonSerializer, options));
            }

            if(mvcOptions.AddMvcConventions)
            {
                // mvcBuilder.AddMvcOptions(options => builder.Configuration.Bind(configurationSectionKey, options));
            }
        }
        return builder;
    }
}