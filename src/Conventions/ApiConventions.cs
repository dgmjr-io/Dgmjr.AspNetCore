namespace Dgmjr.AspNetCore.Conventions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

public static class ApiConventions
{
    /// <summary>
    /// Get convention.
    /// </summary>
    /// <param name="id"></param>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    public static void Get(
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
            object id
    ) { }
}
