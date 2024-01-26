namespace Dgmjr.AspNetCore.TagHelpers.Authorization;
using AuthorizationPolicy = Microsoft.AspNetCore.Authorization.AuthorizationPolicy;

[HtmlTargetElement(Attributes = "asp-authorize")]
[HtmlTargetElement(Attributes = "asp-authorize,asp-policy")]
[HtmlTargetElement(Attributes = "asp-authorize,asp-roles")]
[HtmlTargetElement(Attributes = "asp-authorize,asp-authentication-schemes")]
public class AuthorizeTagHelper(
    IHttpContextAccessor httpContextAccessor,
    IAuthorizationPolicyProvider policyProvider,
    IPolicyEvaluator policyEvaluator
    ) : TagHelper, IAuthorizeData
{
    /// <summary>
    /// Gets or sets the policy name that determines access to the HTML block.
    /// </summary>
    [HtmlAttributeName("asp-policy")]
public string Policy { get; set; }

/// <summary>
/// Gets or sets a comma delimited list of roles that are allowed to access the HTML  block.
/// </summary>
[HtmlAttributeName("asp-roles")]
public string Roles { get; set; }

/// <summary>
/// Gets or sets a comma delimited list of schemes from which user information is constructed.
/// </summary>
[HtmlAttributeName("asp-authentication-schemes")]
public string AuthenticationSchemes { get; set; }

public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
{
    var policy = await AuthorizationPolicy.CombineAsync(policyProvider, new[] { this });

    var authenticateResult = await policyEvaluator.AuthenticateAsync(
        policy,
        httpContextAccessor.HttpContext
    );

    var authorizeResult = await policyEvaluator.AuthorizeAsync(
        policy,
        authenticateResult,
        httpContextAccessor.HttpContext,
        null
    );

    if (!authorizeResult.Succeeded)
    {
        output.SuppressOutput();
    }

    if (output.Attributes.TryGetAttribute("asp-authorize", out TagHelperAttribute attribute))
        output.Attributes.Remove(attribute);
}
}
