using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.DependencyInjection;

public static class BuildIHostApplicationBuilderExtension
{
    // public static IApplicationBuilder Build(this IHostApplicationBuilder builder)
    // {
    //     IHostApplicationBuilder builder2 = WebApplication.CreateBuilder(["hello", "world"]);
    //     var app = (builder as WebApplicationBuilder).Build();
    // }
}
