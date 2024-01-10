namespace Dgmjr.Configuration.Extensions;
using Microsoft.AspNetCore.Builder;

public interface IConfigureIApplicationBuilder : IConfigureOptions<IApplicationBuilder>, IConfigureStuffInOrder;
