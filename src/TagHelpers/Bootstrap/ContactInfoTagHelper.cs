namespace AuthoringTagHelpers.TagHelpers
{
    [HtmlTargetElement(TagNames.Contact, TagStructure = TagStructure.NormalOrSelfClosing)]
    public class ContactInfoTagHelper : TagHelper
    {
        [HtmlAttributeName("name")]
        public string Name { get; set; }

        [HtmlAttributeName("address")]
        public string Address { get; set; }

        [HtmlAttributeName("city")]
        public string City { get; set; }

        [HtmlAttributeName("state")]
        public string State { get; set; }

        [HtmlAttributeName("zip")]
        public string Zip { get; set; }

        [HtmlAttributeName("phone")]
        public string Phone { get; set; }

        [HtmlAttributeName("email")]
        public string Email { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "address";
            var sb = new StringBuilder();
            if (!IsNullOrEmpty(Name))
                sb.Append("<strong>").Append(Name).AppendLine("</strong><br>");
            if (!IsNullOrEmpty(Address))
                sb.Append(Address).AppendLine("<br>");
            if (!IsNullOrEmpty(City))
                sb.Append(City).Append(", ");
            if (!IsNullOrEmpty(State))
                sb.Append(State).Append(' ');
            if (!IsNullOrEmpty(Zip))
                sb.Append(Zip).Append("<br>");
            if (!IsNullOrEmpty(Phone))
            {
                sb.Append("<abbr title=\"Phone\">P:</abbr> <a href=\"tel:")
                    .Append(Phone)
                    .Append("\">")
                    .Append(Phone)
                    .AppendLine("</a><br>");
            }

            if (!IsNullOrEmpty(Email))
            {
                sb.Append("<a href=\"mailto:")
                    .Append(Email)
                    .Append("\">")
                    .Append(Email)
                    .AppendLine("</a>");
            }

            output.Content.SetHtmlContent(sb.ToString());
        }
    }
}
