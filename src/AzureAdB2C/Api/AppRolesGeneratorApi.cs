namespace Dgmjr.AzureAdB2C.Api;
using Microsoft.AspNetCore.Authorization;
using Dgmjr.AzureAdB2C.Services.Graph;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dgmjr.AzureAdB2C.Models;

public class AppRolesGeneratorApi(ILogger<AppRolesGeneratorApi> logger, IAppRolesService appRolesService) : ApiControllerBase(logger)
{
    [Authorize]
    [HttpPost]
    [Route("api/approles/generate")]
    [Consumes("application/json")]
    public async Task<IActionResult> GenerateAsync([FromBody] ApiRequest request, CancellationToken cancellationToken = default)
    {
        // var request = Deserialize<ApiRequest>(requestJson);
        logger.LogDebug("request: {request}", request);
        var result = await appRolesService.GenerateClaimsAsync(request, cancellationToken);

        return result.StatusCode switch
        {
            StatusCodes.Status200OK => Ok(result),
            StatusCodes.Status400BadRequest => BadRequest(result),
            StatusCodes.Status401Unauthorized => Unauthorized(result),
            StatusCodes.Status403Forbidden => Forbid((result as ApiBlockResponse)!.UserMessage),
            StatusCodes.Status404NotFound => NotFound(result),
            StatusCodes.Status409Conflict => Conflict(result),
            StatusCodes.Status500InternalServerError => Problem((result as ApiErrorResponse)!.DeveloperMessage, statusCode: result.StatusCode),
            _ => StatusCode(result.StatusCode ?? StatusCodes.Status200OK, result),
        };
    }
}
