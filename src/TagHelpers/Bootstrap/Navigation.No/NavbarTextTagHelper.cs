namespace No.Dgmjr.AspNetCore.TagHelpers.Bootstrap;

[HtmlTargetElement(TagNames.NavText, ParentTag = TagNames.Navbar)]
[HtmlTargetElement(TagNames.NavText, ParentTag = TagNames.NavbarNav)]
public class NavbarTextTagHelper() : DgmjrTagHelperBase(TagNames.Li)
{
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        await base.ProcessAsync(context, output);
        output.TagName = TagNames.Li;
        output.AddCssClass(CssClasses.NavItem);
        output.AddCssClass(CssClasses.NavLink);
        output.AddCssClass(CssClasses.NavText);
        output.AddCssClass(CssClasses.Disabled);
        output.AddCssClass(TagNames.NavText);
    }
}
