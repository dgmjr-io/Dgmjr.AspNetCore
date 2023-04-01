using System.Collections.Immutable;
using System.Reflection.Metadata.Ecma335;
namespace Microsoft.Extensions.DependencyInjection;

using System.Net.Http.Headers;
using System.Net.Mime.MediaTypes;
using Dgmjr.AspNetCore.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public static class AddTheWorksExtensions
{
    public static WebApplicationBuilder AddTheWorks(
        this WebApplicationBuilder builder,
        IStartupParameters @params = default,
        Action<WebApplicationBuilder>? configure = default
    )
    {
        if (@params.AddLogging)
            _ = builder.Logging
                    .AddConfiguration(builder.Configuration.GetSection("Logging"));

        if (@params.AddConsoleLogger)
            builder.Logging.AddConsole();

        if (@params.AddDebugLogger)
            builder.Logging.AddDebug();

        if (@params.AddIdentity)
            _ = builder.AddIdentity(@params.AddDefaultIdentityUI);

        @params.TypesForAutoMapperAndMediatR ??= Empty<type>();

        if (@params.SearchEntireAppDomainForAutoMapperAndMediatRTypes)
            @params.TypesForAutoMapperAndMediatR = @params.TypesForAutoMapperAndMediatR.Concat(AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => { try { return a.GetTypes(); } catch { return Array.Empty<type>(); } }));

        if (@params.AddAutoMapper)
            _ = builder.Services.AddAutoMapper(@params.TypesForAutoMapperAndMediatR.ToArray());

        if (@params.AddSwagger)
            _ = builder.AddSwaggerGen()
                .AddSwaggerMetadata(@params.ThisAssemblyProject ?? typeof(ThisAssembly.Project))
            .DescribeDataTypesToSwagger()
            .DescribeBasicApiAuthentication()
            .AddXmlCommentsToSwagger()
            .DescribeCrudController()
            .AddSwaggerExamples()
            .AddSwaggerHeaderOperationFilter()
            .DescribeFileUploads()
            .AddDescribeTypesForAllOutputFormatters();

        if (@params.AddXmlSerialization)
            _ = builder.Services.AddControllers().AddXmlSerializerFormatters();

        if (@params.AddRazorPages)
            _ = builder.Services.AddRazorPages();

        if (@params.AddJsonPatch)
            _ = builder.AddJsonPatch();


        _ = builder.Configuration.AddUserSecrets(@params.ThisAssemblyProject.Assembly);

        if (@params.AddAzureAppConfig)
            _ = @params.ConfigureAzureAppConfiguration(builder);

        if (@params.AddApiAuthentication)
            _ = builder.AddApiAuthentication();

        if (@params.AddHttpLogging)
            _ = builder.AddHttpLogging();

        // builder.AddApiAuthentication(_ => { });

        _ = builder.AddFormatters();

        @params.ConfigureHealthChecks(builder);

        _ = builder.AddPayloadServices();

        // builder.DescribeIdentityDataTypes();

        _ = builder.DescribeSchemasViaAttributes();

        if (@params.AddHashids)
            _ = builder.AddHashids();

        if (@params.AddMediatR)
            _ = builder.Services.AddMediatR(@params.TypesForAutoMapperAndMediatR.ToArray());

        _ = builder.AddJsonSerializer();

        _ = builder.Services.AddResponseCompression();
        _ = builder.Services.AddRequestDecompression();

        // builder.();

        // builder.AddProblemDetailsHandler();

        builder.Services.AddSingleton<IStartupParameters>(@params);

        configure?.Invoke(builder);
        return builder;
    }

    public static WebApplication UseTheWorks(this WebApplication app, type tThisAssemblyProject = null)
    {
        tThisAssemblyProject ??= Assembly.GetEntryAssembly().GetTypes().FirstOrDefault(t => t.FullName == "ThisAssembly.Project");
        var @params = app.Services.GetRequiredService<IStartupParameters>();

        if (@params.AddJsonPatch)
            _ = app.Use(
                (context, next) =>
                {
                    context.Response.Headers.AcceptRanges = "items";
                    context.Response.Headers[HttpResponseHeaderNames.AcceptPatch] =
                        ApplicationMediaTypeNames.JsonPatch;
                    return next();
                }
            );

        if (@params.AddHttpLogging)
            _ = app.UseHttpLogging();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment() || app.Environment.IsLocal())
        {
            _ = app.UseDeveloperExceptionPage();
        }
        else
        {
            _ = app.UseStatusCodePages();
        }

        _ = app.UseHttpsRedirection();

        _ = app.UseStaticFiles();

        if (@params.AddSwagger)
        {
            _ = app.UseSwagger();
            // app.UseSwaggerUI();
            _ = app.UseCustomizedSwaggerUI(@params.ThisAssemblyProject ?? typeof(ThisAssembly.Project));
        }

        _ = app.UseRequestDecompression()
            .UseResponseCompression()
            .UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

        if (@params.AddApiAuthentication)
            _ = app.UseApiBasicAuthentication();

        _ = app.UseWelcomePage(new WelcomePageOptions { Path = "/welcum.htm" });

        _ = app.MapPing();

        if (@params.AddRazorPages)
            _ = app.MapRazorPages();

        _ = app.MapControllers();

        return app;
    }

    public static WebApplication UseTheWorks(
        this WebApplication app,
        type tThisAssemblyProject,
        Action<WebApplication>? configure
    )
    {
        app.UseTheWorks(tThisAssemblyProject);
        configure?.Invoke(app);
        return app;
    }

    internal static bool IsLocal(this IHostEnvironment env) => env.IsEnvironment("Local");

    internal static bool IsDevelopment(this IHostEnvironment env) =>
        env.IsEnvironment("Development");
}
