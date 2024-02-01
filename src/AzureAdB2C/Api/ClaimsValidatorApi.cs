namespace Dgmjr.AzureAdB2C.Api;

using Dgmjr.AspNetCore.Controllers;
using Dgmjr.AzureAdB2C.Models;
using Dgmjr.AzureAdB2C.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


public abstract class ClaimsValidatorApi(
    ILogger<ClaimsValidatorApi> logger,
    IClaimsValidator claimsValidator
) : ApiControllerBase(logger)
{
    public virtual IClaimsValidator ClaimsValidator => claimsValidator;

[HttpPost]
[Route("api/claims/generate")]
public async Task<IActionResult> GenerateAsync(
    [FromBody] ApiRequest request,
    CancellationToken cancellationToken = default
)
{
    var result = await ClaimsValidator.ValidateAsync(request, cancellationToken);

    if (IsNullOrWhiteSpace(result.ErrorMessage))
    {
        var response = new ApiContinueResponse { Version = ClaimsValidator.Version };
        return Ok(response);
    }
    else
    {
        var response = new ApiValidationErrorResponse(result.ErrorMessage) { Version = ClaimsValidator.Version };
        return BadRequest(response);
    }
}
}
