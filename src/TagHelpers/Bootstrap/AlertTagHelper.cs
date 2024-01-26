/*
This TH was written by Rick Strahl

Usage:
<error-display message = "@model.Message"
                icon="warning"
                header="Error!"
               >
 </error-display>

Add font-awesome
           <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">

*/

namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap;

/// <summary>
/// <para>TagHelper to display a BootStrap Alert box and FontAwesome icon.</para>
/// <para>
/// Message and Header values can be assigned from model values using
/// standard Razor expressions.
/// </para>
/// <para>
/// The Helper only displays content when message or header are set
/// otherwise the content is not displayed, so when binding to your
/// model and the model value is empty nothing displays.
/// </para>
/// </summary>
/// <remarks>
/// Requires FontAwesome in addition to bootstrap in order to display icons
/// </remarks>
[HtmlTargetElement("alert")]
public class AlertTagHelper : TagHelper
{
    /// <summary>
    /// the main message that gets displayed
    /// </summary>
    [HtmlAttributeName("message")]
    public string Message { get; set; }

    /// <summary>
    /// Optional header that is displayed in big text. Use for
    /// 'noisy' warnings and stop errors only please :-)
    /// The message is displayed below the header.
    /// </summary>
    [HtmlAttributeName("header")]
    public string Header { get; set; }

    /// <summary>
    /// Font-awesome icon name without the fa- prefix.
    /// Example: info, warning, lightbulb-o,
    /// If none is specified - "warning" is used
    /// To force no icon use "none"
    /// </summary>
    [HtmlAttributeName("icon")]
    public string Icon { get; set; }

    /// <summary>
    /// CSS class. Handled here so we can capture the existing
    /// class value and append the BootStrap alert class.
    /// </summary>
    [HtmlAttributeName("class")]
    public string CssClass { get; set; }

    /// <summary>
    /// Optional - specifies the alert class used on the top level
    /// window. If not specified uses the same as the icon.
    /// Override this if the icon and alert classes are different
    /// (often they are not).
    /// </summary>
    [HtmlAttributeName("alert-class")]
    public string AlertClass { get; set; }

    /// <summary>
    /// If true embeds the message text as HTML. Use this
    /// flag if you need to display HTML text. If false
    /// the text is HtmlEncoded.
    /// </summary>
    [HtmlAttributeName("message-as-html")]
    public bool MessageAsHtml { get; set; }

    /// <summary>
    /// If true embeds the header text as HTML. Use this
    /// flag if you need to display raw HTML text. If false
    /// the text is HtmlEncoded.
    /// </summary>
    [HtmlAttributeName("header-as-html")]
    public bool HeaderAsHtml { get; set; }

    /// <summary>
    /// If true displays a close icon to close the alert.
    /// </summary>
    [HtmlAttributeName("dismissible")]
    public bool IsDismissible { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        if (IsNullOrEmpty(Message) && IsNullOrEmpty(Header))
            return;

        if (IsNullOrEmpty(Icon))
            Icon = "warning";
        else
            Icon = Icon.Trim();
        if (Icon == "none")
            Icon = "";

        // assume alertclass to match icon  by default
        // override it when icon and alert class are diff (ie. info, info-circle)
        if (IsNullOrEmpty(AlertClass))
            AlertClass = Icon;

        if (Icon == "info")
            Icon = "info-circle";
        if (Icon == "danger")
        {
            Icon = "warning";
            if (IsNullOrEmpty(AlertClass))
                AlertClass = "alert-danger";
        }
        if (Icon == "success")
        {
            Icon = "check";
            if (IsNullOrEmpty(AlertClass))
                AlertClass = "success";
        }

        if (Icon == "warning" || Icon == "error" || Icon == "danger")
            Icon = Icon + " text-danger"; // force to error color

        if (IsDismissible && !AlertClass.Contains("alert-dismissible"))
            AlertClass += " alert-dismissible";

        string messageText = !MessageAsHtml ? System.Net.WebUtility.HtmlEncode(Message) : Message;
        string headerText = !HeaderAsHtml ? System.Net.WebUtility.HtmlEncode(Header) : Header;

        output.TagName = "div";

        // fix up CSS class
        if (CssClass != null)
            CssClass = CssClass + " alert alert-" + AlertClass;
        else
            CssClass = "alert alert-" + AlertClass;
        output.Attributes.Add("class", CssClass);
        output.Attributes.Add("role", "alert");

        StringBuilder sb = new StringBuilder();

        if (IsDismissible)
            sb.Append(
                "<button type =\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">\r\n"
                    + "   <span aria-hidden=\"true\">&times;</span>\r\n"
                    + "</button>\r\n"
            );

        if (IsNullOrEmpty(Header))
        {
            if (!IsNullOrEmpty(Icon))
            {
                sb.Append($"<i class='fa fa-{Icon}'></i> ");
            }
            sb.Append($"{messageText}");
        }
        else
        {
            sb.Append($"<h3>");
            if (!IsNullOrEmpty(Icon))
            {
                sb.Append($"<i class='fa fa-{Icon}'></i> ");
            }
            sb.Append($"{headerText}</h3>\r\n" + "<hr/>\r\n" + $"{messageText}\r\n");
        }
        output.Content.SetHtmlContent(sb.ToString());
    }
}
