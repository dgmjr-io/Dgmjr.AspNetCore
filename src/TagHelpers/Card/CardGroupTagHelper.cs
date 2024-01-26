﻿namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.Card
{
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [OutputElementHint("div")]
    [RestrictChildren("card")]
    public class CardGroupTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.AddCssClass("card-group");
        }
    }
}
