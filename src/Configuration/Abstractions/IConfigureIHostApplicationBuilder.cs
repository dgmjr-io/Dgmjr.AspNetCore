namespace Dgmjr.Configuration.Extensions;
using Microsoft.Extensions.Hosting;

public interface IConfigureIHostApplicationBuilder : IConfigureStuffInOrder
{
    void Configure(IHostApplicationBuilder builder);
}
