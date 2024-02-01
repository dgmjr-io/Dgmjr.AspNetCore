/*
 * DirectoryObjectsController.cs
 *
 *   Created: 2024-55-16T14:55:21-05:00
 *   Modified: 2024-55-16T14:55:21-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Graph.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

[Route($"{MsGraphApi}{DirectoryObjects}")]
[AuthorizeForScopes(Scopes = [MsGraphScopes.Directory.Read.All])]
public class DirectoryObjectsController(
    ILogger<DirectoryObjectsController> logger,
    IServiceProvider services
) : MsGraphController(logger, services)
{
    private IDirectoryObjectsService DirectoryObjectsService =>
        services.GetRequiredService<IDirectoryObjectsService>();

    [HttpGet(Uris.ExtensionProperties)]
    public async Task<IActionResult> GetExtensionPropertiesAsync()
    {
        Logger.Get(Request.Path);
        return Ok(
            (
                await DirectoryObjectsService.GetExtensionPropertiesAsync(default)
            ).Cast<DGraphExtensionProperty>()
        );
    }
}
