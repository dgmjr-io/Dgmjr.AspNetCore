namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.GridSystem
{
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class ContainerTagHelper : TagHelper
    {
        #region --- Attribute Names ---

        private const string FluidAttributeName = "fluid";

        #endregion

        #region --- Properties ---

        [HtmlAttributeName(FluidAttributeName)]
        public bool Fluid { get; set; }

        #endregion

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.AddCssClass(Fluid ? "container-fluid" : "container");
        }
    }
}
