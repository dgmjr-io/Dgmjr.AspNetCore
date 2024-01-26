/*
 * DgmjrTagHelperBase.cs
 *
 *   Created: 2024-40-15T16:40:24-05:00
 *   Modified: 2024-36-15T17:36:43-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using Microsoft.Extensions.DependencyInjection;

namespace Dgmjr.AspNetCore.TagHelpers;

public class DgmjrTagHelperBase(
    string tagName,
    IActionContextAccessor actionContextAccessor = default
) : TagHelper, IHaveAnActionContextAccessor
{
    protected const string AttributePrefix = "dgmjr-";

[HtmlAttributeNotBound]
public string TagName { get; set; } = tagName;

private const string DisableBootstrapAttributeName = "disable-bootstrap";

[HtmlAttributeName(DisableBootstrapAttributeName)]
[HtmlAttributeNotBound]
[HtmlAttributeMinimizable]
public bool DisableBootstrap { get; set; }

[HtmlAttributeNotBound]
public string GeneratedId { get; set; }

[CopyToOutput]
public string Id { get; set; }

[CopyToOutput]
public string Name { get; set; }

[HtmlAttributeNotBound]
public TagHelperOutput Output { get; set; }

[HtmlAttributeNotBound]
public IActionContextAccessor ActionContextAccessor
{
    get => _actionContextAccessor ??= Services.GetRequiredService<IActionContextAccessor>();
    set => _actionContextAccessor = value;
}
private IActionContextAccessor _actionContextAccessor;

protected IServiceProvider Services => ViewContext.HttpContext.RequestServices;

[ViewContext]
[HtmlAttributeNotBound]
public ViewContext ViewContext { get; set; }

private IUrlHelper _urlHelper;

[HtmlAttributeNotBound]
public IUrlHelper UrlHelper
{
    get =>
        _urlHelper ??= Services
            .GetRequiredService<IUrlHelperFactory>()
            .GetUrlHelper(ViewContext);
    set => _urlHelper = value;
}

// public override void Init(TagHelperContext context)
// {
//     this.SetContexts(context);
//     this.SetContext(context);
//     this.FillMinimizableAttributes(context);
//     this.ConvertUrls(ActionContextAccessor);
// }

// public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
// {
//     Output = output;
//     if (!DisableBootstrap)
//     {
//         this.CopyPropertiesToOutput(output);
//         this.CheckMandatoryProperties();
//         this.CopyIdentifier();
//         RenderProcess(context, output);
//         this.RenderIdentifier(this, output);
//         RemoveMinimizableAttributes(output);
//     }
// }

// public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
// {
//     Output = output;
//     if (!DisableBootstrap)
//     {
//         CopyToOutputAttribute.CopyPropertiesToOutput(this, output);
//         MandatoryAttribute.CheckProperties(this);
//         GenerateIdAttribute.CopyIdentifier(this);
//         await RenderProcessAsync(context, output);
//         GenerateIdAttribute.RenderIdentifier(this, output);
//         RemoveMinimizableAttributes(output);
//     }
// }

protected virtual void RenderProcess(TagHelperContext context, TagHelperOutput output) { }

protected virtual async Task RenderProcessAsync(
    TagHelperContext context,
    TagHelperOutput output
)
{
    RenderProcess(context, output);
}
}
