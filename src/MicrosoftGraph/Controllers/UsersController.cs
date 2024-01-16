namespace Dgmjr.Graph.Controllers;
using Dgmjr.Graph.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Application = Dgmjr.Mime.Application;

[Route($"{MsGraphApi}/{Users}")]
[AuthorizeForScopes(ScopeKeySection = DownstreamApis_MicrosoftGraph_Scopes)]
public class UsersController(ILogger<UsersController> logger, IServiceProvider services) : ControllerBase, ILog
{
    public ILogger Logger => logger;
private readonly IUsersService _users = services.GetRequiredService<IUsersService>();

[HttpGet("{userId:guid}")]
[ProducesResponseType(typeof(User), Status200OK)]
[Produces(MsGraphUserJson, MsGraphUserXml, MsGraphUserBson, MsGraphUserMsgPack)]
public async Task<IActionResult> Get([FromRoute] guid userId)
{
    Logger.PageVisited(Http.Get, $"{Users}/{userId}");
    return Ok(await _users.GetAsync(userId.ToString()));
}

[HttpGet("{property}")]
[Produces(Text.Plain.DisplayName, Application.Json.DisplayName, Application.Xml.DisplayName, Application.Bson.DisplayName, Application.MessagePack.DisplayName)]
[ProducesResponseType(typeof(string), Status200OK)]
[ProducesResponseType(typeof(int), Status200OK)]
[ProducesResponseType(typeof(long), Status200OK)]
public async Task<IActionResult> Get([FromRoute] string property)
{
    Logger.PageVisited(Http.Get, $"{Users}/{property}");
    var result = await _users.GetAsync((await _users.GetMyIdAsync()).ToString(), property);
    var value = result.AdditionalData[new DGraphExtensionProperty(property).Name];
    return Ok(value);
}

[HttpPost("{userId}/{property}")]
[Produces(MsGraphUserJson, MsGraphUserXml, MsGraphUserBson, MsGraphUserMsgPack)]
public async Task<IActionResult> Post([FromRoute] guid userId, [FromRoute] string property, [FromQuery] string value)
{
    Logger.PageVisited(Http.Post, $"{Users}/{userId}/{property}");
    var user = await _users.UpdateAsync(userId.ToString(), property, value);
    return Ok(user);
}

[HttpGet(Uris.ExtensionProperties)]
[ProducesResponseType(typeof(DGraphExtensionProperty[]), Status200OK)]
[Produces(MsGraphExtensionPropertiesListJson, MsGraphExtensionPropertiesListXml, MsGraphExtensionPropertiesListBson, MsGraphExtensionPropertiesListMsgPack)]
public async Task<IActionResult> GetExtensionProperties()
{
    Logger.PageVisited(Http.Get, $"{Users}/{Uris.ExtensionProperties}");
    return Ok((await _users.GetExtensionPropertiesAsync(default)).Cast<DGraphExtensionProperty>());
}
}
