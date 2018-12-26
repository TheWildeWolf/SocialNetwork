using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Hadia.Helper
{
    public class PaginationTagHelper : TagHelper
    {
        public string AspAction { get; set; }
        public string AspController { get; set; }
        public string AspArea { get; set; }

        

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "ul"; 
            output.Attributes.Add("class", "pagination pagination-separated align-self-center");



        }
    }

     
}
