using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesWebApp.Helper
{
    public class CustomEmailTagHelper :TagHelper
    {
        //custom tag helpers
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", "malito:yunah@gmail.com");
            output.Attributes.Add("id","my-email-id");
            output.Content.SetContent("Check out my email");
        }
    }
}
