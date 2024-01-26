﻿namespace Dgmjr.AspNetCore.TagHelpers.Bootstrap.Table
{
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using System;
    using System.Collections.Generic;
    using System.Text;

    [OutputElementHint("th")]
    [HtmlTargetElement("th", ParentTag = "tr")]
    public class ThTagHelper : TdTagHelper { }
}
