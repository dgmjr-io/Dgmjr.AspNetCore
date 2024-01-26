namespace No.Dgmjr.AspNetCore.TagHelpers.Bootstrap;

[OutputElementHint(TagNames.Form)]
[HtmlTargetElement(TagNames.NavForm, ParentTag = TagNames.Navbar)]
public class NavbarFormTagHelper() : DgmjrTagHelperBase(TagNames.Form)
{
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
{
    output.TagName = "form";
    output.AddCssClass("form-inline");
}
}
