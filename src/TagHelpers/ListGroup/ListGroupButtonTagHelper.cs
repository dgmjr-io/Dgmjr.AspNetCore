namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.ListGroup
{
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [OutputElementHint("button")]
    [HtmlTargetElement("list-group-button", ParentTag = "list-group")]
    public class ListGroupButtonTagHelper : ListGroupLinkTagHelper
    {
        protected override string TagName => "button";
    }
}
