namespace Dgmjr.Configuration.Extensions;
using Microsoft.Extensions.Hosting;

public interface IConfigureIHostApplicationBuilder : IConfigureOptions<IHostApplicationBuilder>, IConfigureStuffInOrder;
