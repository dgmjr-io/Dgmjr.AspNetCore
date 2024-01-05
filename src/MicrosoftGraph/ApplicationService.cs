namespace Dgmjr.MicrosoftGraph;
using Microsoft.Identity.Web;

public class ApplicationService(GraphServiceClient graph, ILogger<UsersService> logger, IConfiguration configuration) : ILog
{
    public ILogger Logger => logger;
    private readonly IConfiguration _configuration = configuration;
    private MicrosoftB2CGraphOptions GraphOptions => _configuration.GetSection(Constants.AzureAdB2C).Get<MicrosoftB2CGraphOptions>();
    private MicrosoftIdentityOptions IdentityOptions => _configuration.GetSection(Constants.AzureAdB2C).Get<MicrosoftIdentityOptions>();
    private readonly GraphServiceClient _graphServiceClient = graph;

    public async Task<Application?> GetApplication()
        => await _graphServiceClient.Applications[ClientId].Request().GetAsync();

    public string ClientId =>
        IdentityOptions?.ClientId ??
        throw new InvalidOperationException("ClientId is required");
}
