namespace Dgmjr.Configuration.Extensions;
using Microsoft.AspNetCore.Builder;

public interface IConfigureIApplicationBuilder : IConfigureStuffInOrder
{
    void Configure(IApplicationBuilder app);
}
