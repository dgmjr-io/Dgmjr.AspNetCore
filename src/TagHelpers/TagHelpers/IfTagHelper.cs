/*
 * IfTagHelper.cs
 *
 *   Created: 2024-31-15T22:31:30-05:00
 *   Modified: 2024-31-15T22:31:31-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */


namespace Dgmjr.AspNetCore.TagHelpers;

/// <summary>
/// Suppresses the output of the element if the supplied predicate equates to <c>false</c>.
/// </summary>
[HtmlTargetElement("*", Attributes = AttributeNames.AspIf)]
public class IfTagHelper : TagHelper
{
    internal static readonly object SuppressedKey = new();
    internal static readonly object SuppressedValue = new();

    /// <summary>
    /// Gets or sets the predicate expression to test.
    /// </summary>
    [HtmlAttributeName(AttributeNames.AspIf)]
    public bool Predicate { get; set; }

    /// <inheritdoc />
    /// <remarks>
    /// Run before other Tag Helpers (default Order is 0) so they can cooperatively decide not to run.
    /// Note this value is coordinated with the value of AuthzTagHelper.Order to ensure the IfTagHelper logic runs first.
    /// (Lower values run earlier).
    /// </remarks>
    public override int Order => -100;

    /// <inheritdoc />
    public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        if (output == null)
        {
            throw new ArgumentNullException(nameof(output));
        }

        if (!Predicate)
        {
            output.SuppressOutput();
            context.Items[SuppressedKey] = SuppressedValue;
        }
    }
}

/// <summary>
/// Extension methods for <see cref="TagHelperContext"/>.
/// </summary>
public static class IfTagHelperContextExtensions
{
    /// <summary>
    /// Determines if the <see cref="IfTagHelper"/> (<c>asp-if</c>) has suppressed rendering for the element associated with
    /// this <see cref="TagHelperContext"/>.
    /// </summary>
    /// <param name="context">The <see cref="TagHelperContext"/>.</param>
    /// <returns><c>true</c> if <c>asp-if</c> evaluated to <c>false</c>, else <c>false</c>.</returns>
    public static bool SuppressedByAspIf(this TagHelperContext context) =>
        context.Items.TryGetValue(IfTagHelper.SuppressedKey, out var value)
        && value == IfTagHelper.SuppressedValue;
}
