namespace Dgmjr.Graph.Controllers;
using Dgmjr.Graph.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Application = Dgmjr.Mime.Application;

[Route($"{MsGraphApi}/{Me}")]
[AuthorizeForScopes(Scopes = [MsGraphScopes.User.ReadWrite.All])]
public class MeController(ILogger<MeController> logger, IServiceProvider services) : ControllerBase, ILog, IHaveAGraphClient
{
    public ILogger Logger => logger;
    public GraphServiceClient Graph => services.GetRequiredService<GraphServiceClient>();
    private readonly IUsersService _users = services.GetRequiredService<IUsersService>();

    [HttpGet]
    [ProducesResponseType(typeof(User), Status200OK)]
    [Produces(MsGraphUserJson, MsGraphUserXml, MsGraphUserBson, MsGraphUserMsgPack)]
    public async Task<IActionResult> Get()
    {
        Logger.PageVisited(Http.Get, Me);
        return Ok(await _users.GetMeAsync());
    }

    [HttpGet("{property}")]
    [Produces(Text.Plain.DisplayName, Application.Json.DisplayName, Application.Xml.DisplayName, Application.Bson.DisplayName, Application.MessagePack.DisplayName)]
    [ProducesResponseType(typeof(string), Status200OK)]
    [ProducesResponseType(typeof(int), Status200OK)]
    [ProducesResponseType(typeof(long), Status200OK)]
    public async Task<IActionResult> Get([FromRoute] string property)
    {
        Logger.PageVisited(Http.Get, $"{Me}/{property}");
        var propertyFullName = new DGraphExtensionProperty(property).Name;
        var result = await Graph.Me.Request().Select(u => u.AdditionalData[propertyFullName]).GetAsync();
        var value = result.AdditionalData[new DGraphExtensionProperty(property).Name];
        return Ok(value);
    }

    [HttpPost("{property}")]
    [Produces(MsGraphUserJson, MsGraphUserXml, MsGraphUserBson, MsGraphUserMsgPack)]
    public async Task<IActionResult> Post([FromRoute] string property, [FromQuery] string value)
    {
        Logger.PageVisited(Http.Post, $"{Me}/{property}");
        var me = await Graph.Me.Request().GetAsync();
        me.AdditionalData[property] = value;
        return Ok(await Graph.Me.Request().UpdateAsync(me));
    }

    [HttpGet(Uris.ExtensionProperties)]
    [ProducesResponseType(typeof(DGraphExtensionProperty[]), Status200OK)]
    [Produces(MsGraphExtensionPropertiesListJson, MsGraphExtensionPropertiesListXml, MsGraphExtensionPropertiesListBson, MsGraphExtensionPropertiesListMsgPack)]
    public async Task<IActionResult> GetExtensionProperties()
    {
        Logger.PageVisited(Http.Get, $"{Me}/{Uris.ExtensionProperties}");
        return Ok((await _users.GetExtensionPropertiesAsync(default)).Cast<DGraphExtensionProperty>());
    }
}