namespace Microsoft.AspNetCore.Mvc.Infrastructure;

using Microsoft.AspNetCore.Mvc;

public interface IStatusCodeActionResult : IActionResult
{
    int? StatusCode { get; }
}
