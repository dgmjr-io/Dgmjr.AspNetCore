﻿namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.Components
{
    using Microsoft.AspNetCore.Razor.TagHelpers;

    /// <summary>
    /// A tag helper for tooltips.
    /// </summary>
    /// <seealso cref="BSolutions.Brecons.TagHelper.Controls.TagHelper" />
    /// <remarks>
    /// For performance reasons, the Tooltip and Popover data-apis are opt-in,
    /// meaning you must initialize them yourself:
    /// $(function () { $('[data-toggle="tooltip"]').tooltip() })
    /// </remarks>
    [HtmlTargetElement("*", Attributes = TooltipAttributeName)]
    public class TooltipTagHelper : TagHelper
    {
        #region --- Attribute Names ---

        private const string TooltipAttributeName = "tooltip";
        private const string HtmlAttributeName = TooltipAttributeName + "-html";
        private const string PlacementAttributeName = TooltipAttributeName + "-placement";
        private const string AnimationAttributeName = TooltipAttributeName + "-animation";
        private const string DelayAttributeName = TooltipAttributeName + "-delay";

        #endregion

        #region --- Properties ---

        [HtmlAttributeName(TooltipAttributeName)]
        [CopyToOutput("title")]
        public string Tooltip { get; set; }

        [HtmlAttributeName(HtmlAttributeName)]
        public bool IsHtml { get; set; }

        [HtmlAttributeName(PlacementAttributeName)]
        public Placement Placement { get; set; } = Placement.Top;

        [HtmlAttributeName(AnimationAttributeName)]
        public bool Animation { get; set; } = true;

        [HtmlAttributeName(DelayAttributeName)]
        public int Delay { get; set; }

        #endregion

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.AddDataAttribute("toggle", "tooltip");
            output.AddDataAttribute("placement", this.Placement.GetEnumInfo().Name);
            output.AddDataAttribute("animation", this.Animation ? "true" : "false");
            output.AddDataAttribute("delay", this.Delay.ToString());
            output.AddDataAttribute("html", this.IsHtml ? "true" : "false");
        }
    }
}
