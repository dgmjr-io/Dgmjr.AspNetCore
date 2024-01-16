namespace Dgmjr.Graph.Services;

public class ApplicationService(GraphServiceClient graph, ILogger<UsersService> logger, IOptionsMonitor<MicrosoftB2CGraphOptions> options, IOptionsMonitor<MicrosoftIdentityOptions> msidOptions, IDistributedCache cache) : MsGraphService(graph, logger, options, msidOptions, cache), IApplicationService
{
}
