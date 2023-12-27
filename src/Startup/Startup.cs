namespace Dgmjr.AspNetCore;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

public abstract class Startup(IConfiguration configuration, IWebHostEnvironment env)
{
    public IConfiguration Configuration { get; } = configuration;
public IWebHostEnvironment Environment { get; } = env;

public abstract void ConfigureServices(IServiceCollection services);

public abstract void Configure(IApplicationBuilder app);
}
