namespace Dgmjr.Graph.Services;

public class ApplicationService(
    GraphServiceClient graph,
    ILogger<UsersService> logger,
    IOptionsMonitor<AzureAdB2CGraphOptions> options,
    IOptionsMonitor<MicrosoftIdentityOptions> msidOptions,
    IDistributedCache cache
) : MsGraphService(graph, logger, options, msidOptions, cache), IApplicationService { }
