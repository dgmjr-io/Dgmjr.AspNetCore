namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.Tabs
{
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using System.Threading.Tasks;

    [HtmlTargetElement("tabs-pane", ParentTag = "tabs")]
    [GenerateId("pane-")]
    public class TabsPaneTagHelper : TagHelper
    {
        #region --- Attribute Names ---

        private const string HeaderAttributeName = "header";
        private const string ActiveAttributeName = "active";

        #endregion

        #region --- Properties ---

        [HtmlAttributeName(HeaderAttributeName)]
        public string Header { get; set; }

        [HtmlAttributeName(ActiveAttributeName)]
        public bool IsActive { get; set; }

        [Context]
        [HtmlAttributeNotBound]
        public TabsTagHelper TabsContext { get; set; }

        [HtmlAttributeNotBound]
        public TagHelperContent Content { get; set; }

        public virtual string Id { get; set; } = guid.NewGuid().ToString("N")[..8];

        #endregion

        public override void Init(TagHelperContext context)
        {
            base.Init(context);
            this.TabsContext.Panes.Add(this);
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            this.Content = await output.GetChildContentAsync();
            output.SuppressOutput();
        }
    }
}
