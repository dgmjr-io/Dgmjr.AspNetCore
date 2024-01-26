/*
 * AuthorizeResourceTagHelper.cs
 *
 *   Created: 2024-40-15T16:40:24-05:00
 *   Modified: 2024-59-15T16:59:51-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.TagHelpers.Authorization;

[HtmlTargetElement(Attributes = "asp-authorize-resource,asp-policy")]
[HtmlTargetElement(Attributes = "asp-authorize-resource,asp-requirement")]
public class AuthorizeResourceTagHelper(
    IHttpContextAccessor httpContextAccessor,
    IAuthorizationService authorizationService
) : TagHelper
{
    /// <summary>
    /// Gets or sets the policy name that determines access to the HTML block.
    /// </summary>
    [HtmlAttributeName("asp-policy")]
    public string Policy { get; set; }

    /// <summary>
    /// Gets or sets a comma delimited list of roles that are allowed to access the HTML  block.
    /// </summary>
    [HtmlAttributeName("asp-requirement")]
    public IAuthorizationRequirement Requirement { get; set; }

    /// <summary>
    /// Gets or sets the resource to be authorized against a particular policy
    /// </summary>
    [HtmlAttributeName("asp-authorize-resource")]
    public object Resource { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        if (Resource == null)
        {
            throw new ArgumentException("Resource cannot be null");
        }
        if (IsNullOrWhiteSpace(Policy) && Requirement == null)
        {
            throw new ArgumentException("Either Policy or Requirement must be specified");
        }
        if (!IsNullOrWhiteSpace(Policy) && Requirement != null)
        {
            throw new ArgumentException(
                "Policy and Requirement cannot be specified at the same time"
            );
        }

        AuthorizationResult authorizeResult;

        if (!IsNullOrWhiteSpace(Policy))
        {
            authorizeResult = await authorizationService.AuthorizeAsync(
                httpContextAccessor.HttpContext.User,
                Resource,
                Policy
            );
        }
        else if (Requirement != null)
        {
            authorizeResult = await authorizationService.AuthorizeAsync(
                httpContextAccessor.HttpContext.User,
                Resource,
                Requirement
            );
        }
        else
        {
            throw new ArgumentException("Either Policy or Requirement must be specified");
        }

        if (!authorizeResult.Succeeded)
        {
            output.SuppressOutput();
        }
    }
}
