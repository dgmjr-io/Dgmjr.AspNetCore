namespace Dgmjr.AzureAdB2C.Api;

using Dgmjr.AspNetCore.Controllers;
using Dgmjr.AzureAdB2C.Models;
using Dgmjr.AzureAdB2C.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

public abstract class ClaimsGeneratorApi(
    ILogger<ClaimsGeneratorApi> logger,
    IClaimsGenerator claimsGenerator,
    IUserHydrator userHydrator
) : ApiControllerBase(logger)
{
    public virtual IClaimsGenerator ClaimsGenerator => claimsGenerator;
public virtual IUserHydrator UserHydrator => userHydrator;

[HttpPost]
[Route("api/claims/validate")]
public async Task<IActionResult> ValidateAsync(
    [FromBody] ApiRequest request,
    CancellationToken cancellationToken = default
)
{
    var result = await ClaimsGenerator.GenerateClaimsAsync(
        request,
        cancellationToken
    );

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
