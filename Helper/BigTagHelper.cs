using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesWebApp.Helper
{
    [HtmlTargetElement("big")]
    [HtmlTargetElement(Attributes ="big")]
    public class BigTagHelper :TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "h1";
            output.Attributes.RemoveAll("big");
            output.Attributes.SetAttribute("class","h3");
        }
    }
}
