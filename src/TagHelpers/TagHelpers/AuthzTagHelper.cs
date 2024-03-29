/*
 * AuthzTagHelper.cs
 *
 *   Created: 2024-39-16T11:39:42-05:00
 *   Modified: 2024-39-16T11:39:43-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.TagHelpers;

/// <summary>
/// Suppresses rendering of an element unless specific authorization policies are met.
/// </summary>
[HtmlTargetElement(TagNames.Any, Attributes = AspAuthzAttributeName)]
[HtmlTargetElement(TagNames.Any, Attributes = AspAuthzPolicyAttributeName)]
public class AuthzTagHelper : TagHelper
{
    internal static readonly object SuppressedKey = new();
    internal static readonly object SuppressedValue = new();

    private const string AspAuthzAttributeName = "asp-authz";
    private const string AspAuthzPolicyAttributeName = "asp-authz-policy";

    private readonly IAuthorizationService _authz;

    /// <summary>
    /// Creates a new instance of the <see cref="AuthzTagHelper" /> class.
    /// </summary>
    /// <param name="authz">The <see cref="IAuthorizationService"/>.</param>
    public AuthzTagHelper(IAuthorizationService authz)
    {
        _authz = authz;
    }

    /// <inheritdoc />
    // Run before other Tag Helpers (default Order is 0) so they can cooperatively decide not to run.
    // Note this value is coordinated with the value of IfTagHelper.Order to ensure the IfTagHelper logic runs first.
    // (Lower values run earlier).
    public override int Order => -10;

    /// <summary>
    /// A boolean indicating whether the current element requires authentication in order to be rendered.
    /// </summary>
    [HtmlAttributeName(AspAuthzAttributeName)]
    public bool RequiresAuthentication { get; set; }

    /// <summary>
    /// An authorization policy name that must be satisfied in order for the current element to be rendered.
    /// </summary>
    [HtmlAttributeName(AspAuthzPolicyAttributeName)]
    public string RequiredPolicy { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="ViewContext"/>.
    /// </summary>
    [HtmlAttributeNotBound]
    [ViewContext]
    public ViewContext ViewContext { get; set; }

    /// <inheritdoc />
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        if (output == null)
        {
            throw new ArgumentNullException(nameof(output));
        }

        if (context.SuppressedByAspIf() || context.SuppressedByAspAuthz())
        {
            return;
        }

        var requiresAuth = RequiresAuthentication || !IsNullOrEmpty(RequiredPolicy);
        var showOutput = false;

        var user = ViewContext.HttpContext.User;
        if (
            context.AllAttributes[AspAuthzAttributeName] != null
            && !requiresAuth
            && !user.Identity.IsAuthenticated
        )
        {
            // authz="false" & user isn't authenticated
            showOutput = true;
        }
        else if (!IsNullOrEmpty(RequiredPolicy))
        {
            // auth-policy="foo" & user is authorized for policy "foo"
            var cacheKey = AspAuthzPolicyAttributeName + "." + RequiredPolicy;
            bool authorized;
            var cachedResult = ViewContext.ViewData[cacheKey];
            if (cachedResult != null)
            {
                authorized = (bool)cachedResult;
            }
            else
            {
                var authResult = await _authz.AuthorizeAsync(user, ViewContext, RequiredPolicy);
                authorized = authResult.Succeeded;
                ViewContext.ViewData[cacheKey] = authorized;
            }

            showOutput = authorized;
        }
        else if (requiresAuth && user.Identity.IsAuthenticated)
        {
            // auth="true" & user is authenticated
            showOutput = true;
        }

        if (!showOutput)
        {
            output.SuppressOutput();
            context.Items[SuppressedKey] = SuppressedValue;
        }
    }
}

/// <summary>
/// Extension methods for <see cref="TagHelperContext"/>.
/// </summary>
public static class AuthzTagHelperContextExtensions
{
    /// <summary>
    /// Determines if the <see cref="AuthzTagHelper"/> (<c>asp-authz</c>) has suppressed rendering for the element associated with
    /// this <see cref="TagHelperContext"/>.
    /// </summary>
    /// <param name="context">The <see cref="TagHelperContext"/>.</param>
    /// <returns><c>true</c> if <c>asp-authz</c> suppressed rendering of this Tag Helper.</returns>
    public static bool SuppressedByAspAuthz(this TagHelperContext context) =>
        context.Items.TryGetValue(AuthzTagHelper.SuppressedKey, out var value)
        && value == AuthzTagHelper.SuppressedValue;
}
