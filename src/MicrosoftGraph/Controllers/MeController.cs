namespace Dgmjr.Graph.Controllers;
using Dgmjr.Graph.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Application = Dgmjr.Mime.Application;
using Dgmjr.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web.Resource;

[AuthorizeForScopes(Scopes = [MsGraphScopes.User.Read.Base])]
[RequiredScope([MsGraphScopes.User.Read.Base])]
[Route($"{MsGraphApi}{Me}")]
public class MeController(ILogger<MeController> logger, IServiceProvider services) : MsGraphController(logger, services)
{
    private readonly IUsersService _users = services.GetRequiredService<IUsersService>();

[HttpGet]
[ProducesResponseType(typeof(User), Status200OK)]
[Produces(MsGraphUserJson, MsGraphUserXml, MsGraphUserBson, MsGraphUserMsgPack)]
public async Task<IActionResult> Get()
{
    Logger.Get(Me);
    return Ok(await _users.GetMeAsync());
}

[HttpGet("{property}")]
[Produces(Text.Plain.DisplayName, Application.Json.DisplayName, Application.Xml.DisplayName, Application.Bson.DisplayName, Application.MessagePack.DisplayName)]
[ProducesResponseType(typeof(string), Status200OK)]
[ProducesResponseType(typeof(int), Status200OK)]
[ProducesResponseType(typeof(long), Status200OK)]
public async Task<IActionResult> Get([FromRoute] string property)
{
    Logger.Get(Request.Path);
    var propertyFullName = new DGraphExtensionProperty(property).Name;
    var result = await Graph.Me.Request().Select(u => u.AdditionalData[propertyFullName]).GetAsync();
    var value = result.AdditionalData[new DGraphExtensionProperty(property).Name];
    return Ok(value);
}

[HttpPost("{property}")]
[Produces(MsGraphUserJson, MsGraphUserXml, MsGraphUserBson, MsGraphUserMsgPack)]
public async Task<IActionResult> Post([FromRoute] string property, [FromQuery] string value)
{
    Logger.Post(Request.Path);
    var me = await Graph.Me.Request().GetAsync();
    me.AdditionalData[property] = value;
    return Ok(await Graph.Me.Request().UpdateAsync(me));
}

[HttpGet(Uris.ExtensionProperties)]
[ProducesResponseType(typeof(DGraphExtensionProperty[]), Status200OK)]
[Produces(MsGraphExtensionPropertiesListJson, MsGraphExtensionPropertiesListXml, MsGraphExtensionPropertiesListBson, MsGraphExtensionPropertiesListMsgPack)]
public async Task<IActionResult> GetExtensionProperties()
{
    Logger.Get($"{Me}/{Uris.ExtensionProperties}");
    return Ok((await _users.GetExtensionPropertiesAsync(default)).Cast<DGraphExtensionProperty>());
}
}
