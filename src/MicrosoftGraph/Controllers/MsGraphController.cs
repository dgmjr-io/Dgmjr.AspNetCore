/*
 * MsGraphController.cs
 *
 *   Created: 2024-55-16T14:55:53-05:00
 *   Modified: 2024-55-16T14:55:54-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Graph.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

[Route(MsGraphApi)]
public abstract class MsGraphController(ILogger logger, IServiceProvider services)
    : ControllerBase,
        IHaveAGraphClient
{
    public ILogger Logger => logger;
public GraphServiceClient Graph => services.GetRequiredService<GraphServiceClient>();
}
