namespace Dgmjr.Configuration.Extensions;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

public interface IConfigureIHostApplicationBuilder : IConfigureStuffInOrder
{
    void Configure(WebApplicationBuilder builder);
}
