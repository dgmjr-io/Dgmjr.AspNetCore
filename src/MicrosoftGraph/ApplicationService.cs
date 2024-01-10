namespace Dgmjr.MicrosoftGraph;
using Microsoft.Identity.Web;

public class ApplicationService(GraphServiceClient graph, ILogger<UsersService> logger, IConfiguration configuration) : ILog
{
    public ILogger Logger => logger;
    private readonly IConfiguration _configuration = configuration;
    private MicrosoftB2CGraphOptions GraphOptions => _configuration.GetSection(Constants.AzureAdB2C).Get<MicrosoftB2CGraphOptions>();
    private MicrosoftIdentityOptions IdentityOptions => _configuration.GetSection(Constants.AzureAdB2C).Get<MicrosoftIdentityOptions>();
    protected virtual GraphServiceClient Graph => graph;
    public guid ExtensionsAppClientId => GraphOptions.AzureAdB2CExtensionsApplicationId;

    /// <summary>Retrieves the client ID from "AzureAdB2C:ClientIf"</summary>
    public string ClientId =>
        IdentityOptions?.ClientId ??
        throw new InvalidOperationException("ClientId is required");

    public async Task<Application?> GetApplication()
        => await Graph.Applications[ClientId].Request().GetAsync();

    public async Task<Application?> GetExtensionsApplication()
        => await Graph.Applications[GraphOptions.AzureAdB2CExtensionsApplicationId.ToString()].Request().GetAsync();

    public async Task<MgExtensionProperty[]> GetExtensionPropertiesAsync(CancellationToken cancellationToken = default)
    {

        var extensionProperties = await Graph.Applications[ExtensionsAppClientId.ToString()].ExtensionProperties.Request().GetAsync();
        return extensionProperties.AsEnumerable().ToArray();
    }
}
