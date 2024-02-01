using Dgmjr.AzureAdB2C.Json;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Dgmjr.AzureAdB2C.Models;

public abstract class ApiResponse : ActionResult, IStatusCodeActionResult
{
    [JIgnore]
    public virtual bool IsSuccess => Action == ApiResponseAction.Continue;
    [JProp("version")]
    public virtual Version Version { get; set; } = default!;
    [JProp("action")]
    public virtual ApiResponseAction Action => ApiResponseAction.Continue;
    [JProp("status")]
    public virtual int? StatusCode => StatusCodes.Status200OK;
}

[JsonConverter(typeof(JsonApiContinueResponseConverter))]
public class ApiContinueResponse : ApiResponse
{
    public override ApiResponseAction Action => ApiResponseAction.Continue;

    public virtual IStringDictionary Claims { get; set; } = new StringDictionary();
}

public abstract class ApiErrorResponse(string userMessage, string? developerMessage = default)
    : ApiResponse
{
    public virtual string? UserMessage => userMessage;
public virtual string? DeveloperMessage => developerMessage ?? userMessage;
}

public class ApiBlockResponse(string userMessage, string ? developerMessage = default)
    : ApiErrorResponse(userMessage, developerMessage)
{
    public override ApiResponseAction Action => ApiResponseAction.ShowBlockPage;
}

public class ApiValidationErrorResponse(
    string userMessage,
    string ? developerMessage = default
) : ApiErrorResponse(userMessage, developerMessage)
{
    public override int? StatusCode => StatusCodes.Status400BadRequest;
public override ApiResponseAction Action => ApiResponseAction.ValidationError;
}

[JsonConverter(typeof(JStringEnumConverter))]
public enum ApiResponseAction
{
    Continue,
    ShowBlockPage,
    Redirect,
    ValidationError
}
