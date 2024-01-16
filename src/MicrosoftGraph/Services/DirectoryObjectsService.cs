namespace Dgmjr.Graph.Services;

public class DirectoryObjectsService(GraphServiceClient graph, ILogger<UsersService> logger, IOptionsMonitor<MicrosoftB2CGraphOptions> options, IOptionsMonitor<MicrosoftIdentityOptions> msidOptions, IDistributedCache cache) : MsGraphService(graph, logger, options, msidOptions, cache), IDirectoryObjectsService
{
    public async Task<DirectoryObject> GetAsync(string id, CancellationToken cancellationToken = default)
{
    return await Graph.DirectoryObjects[id].Request().GetAsync(cancellationToken);
}

public async Task<DirectoryObject> GetAsync(string id, string property, CancellationToken cancellationToken = default)
{
    return await Graph.DirectoryObjects[id].Request().Select(property).GetAsync(cancellationToken);
}

public async Task<DirectoryObject> CreateAsync(DirectoryObject directoryObject, CancellationToken cancellationToken = default)
{
    return await Graph.DirectoryObjects.Request().AddAsync(directoryObject, cancellationToken);
}

public async Task DeleteAsync(string id, CancellationToken cancellationToken = default)
{
    await Graph.DirectoryObjects[id].Request().DeleteAsync(cancellationToken);
}

public async Task<DirectoryObject> UpdateAsync(string id, DirectoryObject directoryObject, CancellationToken cancellationToken = default)
{
    return await Graph.DirectoryObjects[id].Request().UpdateAsync(directoryObject, cancellationToken);
}
}
