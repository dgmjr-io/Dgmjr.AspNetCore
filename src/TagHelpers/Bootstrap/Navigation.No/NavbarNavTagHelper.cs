using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace No.Dgmjr.AspNetCore.TagHelpers.Bootstrap;

[HtmlTargetElement(TagNames.NavbarNav)]
// [RestrictChildren(TagNames.NavLink, TagNames.NavText, TagNames.NavDropDown, TagNames.NavItem)]
[ContextClass]
public class NavbarNavTagHelper(IActionContextAccessor actionContextAccessor)
    : TagHelper,
        IHaveAnActionContextAccessor,
        IIdentifiable<string>
{
    public IActionContextAccessor ActionContextAccessor => actionContextAccessor;

[CopyToOutput]
public string Id { get; set; } = guid.NewGuid().ToString()[..8];

public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
{
    await base.ProcessAsync(context, output);
    output.TagName = "ul";
    output.AddCssClass(CssClasses.Nav);
    output.AddCssClass(CssClasses.NavbarNav);
}
}
