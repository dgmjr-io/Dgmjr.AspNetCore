namespace Dgmjr.Graph.Abstractions;

public interface IDirectoryObjectsService : IMsGraphService
{
    Task<DirectoryObject> CreateAsync(DirectoryObject directoryObject, CancellationToken cancellationToken = default);
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);
    Task<DirectoryObject> GetAsync(string id, CancellationToken cancellationToken = default);
    Task<DirectoryObject> GetAsync(string id, string property, CancellationToken cancellationToken = default);
    Task<DirectoryObject> UpdateAsync(string id, DirectoryObject directoryObject, CancellationToken cancellationToken = default);
}
