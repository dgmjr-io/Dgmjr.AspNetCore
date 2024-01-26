// namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.GridSystem
// {
//     using Microsoft.AspNetCore.Razor.TagHelpers;

//     [OutputElementHint("div")]
//     [RestrictChildren("column")]
//     public class RowTagHelper : TagHelper
//     {
//         #region --- Attribute Names ---

//         private const string VerticalAlignmentAttributeName = "vertical-alignment";
//         private const string HorizontalAlignmentAttributeName = "alignment";

//         #endregion

//         #region --- Properties ---

//         [HtmlAttributeName(VerticalAlignmentAttributeName)]
//         public VerticalAlignment VerticalAlignment { get; set; } = VerticalAlignment.Default;

//         [HtmlAttributeName(HorizontalAlignmentAttributeName)]
//         public GridHorizontalAlignment HorizontalAlignment { get; set; } =
//             GridHorizontalAlignment.Default;

//         #endregion

//         public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
//         {
//             output.TagName = "div";
//             output.AddCssClass("row");

//             // Vertical Alignment
//             switch (this.VerticalAlignment)
//             {
//                 case VerticalAlignment.Top:
//                     output.AddCssClass("align-items-start");
//                     break;
//                 case VerticalAlignment.Middle:
//                     output.AddCssClass("align-items-center");
//                     break;
//                 case VerticalAlignment.Bottom:
//                     output.AddCssClass("align-items-end");
//                     break;
//             }

//             // Horizontal Alignment
//             switch (this.HorizontalAlignment)
//             {
//                 case GridHorizontalAlignment.Left:
//                     output.AddCssClass("justify-content-start");
//                     break;
//                 case GridHorizontalAlignment.Center:
//                     output.AddCssClass("justify-content-center");
//                     break;
//                 case GridHorizontalAlignment.Right:
//                     output.AddCssClass("justify-content-end");
//                     break;
//                 case GridHorizontalAlignment.Around:
//                     output.AddCssClass("justify-content-around");
//                     break;
//                 case GridHorizontalAlignment.Between:
//                     output.AddCssClass("justify-content-between");
//                     break;
//             }
//         }
//     }
// }
