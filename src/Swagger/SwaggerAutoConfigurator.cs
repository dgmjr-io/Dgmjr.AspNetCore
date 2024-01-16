using Microsoft.AspNetCore.Builder;

namespace Dgmjr.AspNetCore.Swagger;

public class SwaggerAutoConfigurator : IConfigureIHostApplicationBuilder, IConfigureIApplicationBuilder
{
    public ConfigurationOrder Order => throw new NotImplementedException();

    public void Configure(IHostApplicationBuilder builder)
    {
        builder.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseCustomSwaggerUI();
    }
}
