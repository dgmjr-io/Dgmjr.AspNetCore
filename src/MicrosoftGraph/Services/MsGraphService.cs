namespace Dgmjr.Graph.Services;
using global::Dgmjr.Abstractions;

public interface IMsGraphService : IHaveAGraphClient
{
    /// <summary>The client ID of the extensions application</summary>
    guid ExtensionsAppClientId { get; }

    /// <summary>The client ID of the application registered in Azure AD that the Web app/API is registered with</summary>
    guid ClientId { get; }

    /// <summary>Retrieves the application registered in Azure AD that the Web app/API is registered with</summary>
    Task<MgApplication?> GetApplicationAsync();

    /// <summary>Retrieves <inheritdoc cref="GetExtensionPropertiesAsync" path="/returns" /></summary>
    /// <param name="cancellationToken"></param>
    /// <returns>the list of extension properties registered with the extensions application</returns>
    Task<MgExtensionProperty[]> GetExtensionPropertiesAsync(CancellationToken cancellationToken = default);

    /// <summary>Retrieves <inheritdoc cref="GetExtensionsApplicationAsync" path="/returns" /></summary>
    /// <returns>the extensions application registered with client ID <see cref="ExtensionsAppClientId" /></returns>
    Task<MgApplication?> GetExtensionsApplicationAsync();
}

public class MsGraphService(GraphServiceClient graph, ILogger logger, IOptionsMonitor<MicrosoftB2CGraphOptions> options, IOptionsMonitor<MicrosoftIdentityOptions> msidOptions, IDistributedCache cache) : IMsGraphService
{
    private static readonly duration CacheDuration = duration.FromDays(1000);
private static readonly DateTimeOffset CacheExpiration = DateTimeOffset.UtcNow.Add(CacheDuration);
public ILogger Logger => logger;
private MicrosoftB2CGraphOptions Options => options.CurrentValue;
private MicrosoftIdentityOptions MsidOptions => msidOptions.CurrentValue;
public guid ExtensionsAppClientId => Options.AzureAdB2CExtensionsApplicationId;
public guid ClientId => new(MsidOptions.ClientId);
protected IDistributedCache Cache => cache;

public virtual GraphServiceClient Graph => graph;

public async Task<MgApplication?> GetApplicationAsync()
{
    return await Graph.Applications[ClientId.ToString()].Request().GetAsync();
}

public async Task<MgApplication?> GetExtensionsApplicationAsync()
{
    return await Graph.Applications[ExtensionsAppClientId.ToString()].Request().GetAsync();
}

public async Task<MgExtensionProperty[]> GetExtensionPropertiesAsync(CancellationToken cancellationToken = default)
{
    await Cache.SetStringAsync("test", "test", CacheExpiration, cancellationToken: cancellationToken);
    var extensionPropertiesJson = await Cache.GetStringAsync(CacheKeys.ExtensionProperties, cancellationToken);
    MgExtensionProperty[]? extensionProperties;
    if (extensionPropertiesJson is not null)
    {
        Logger.CacheHit(CacheKeys.ExtensionProperties);
        extensionProperties = Deserialize<MgExtensionProperty[]>(extensionPropertiesJson)!;
    }
    else
    {
        Logger.CacheMiss(CacheKeys.ExtensionProperties);
        extensionProperties =

            [..await Graph.DirectoryObjects.GetAvailableExtensionProperties().Request().PostAsync(cancellationToken)];
        await Cache.SetAsync(CacheKeys.ExtensionProperties, extensionProperties, CacheExpiration, cancellationToken: cancellationToken);
    }
    return extensionProperties;
}
}
