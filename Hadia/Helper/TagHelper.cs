using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;

namespace Hadia.Helper
{
    public class PaginationTagHelper : TagHelper
    {
        private const string ActionAttributeName = "asp-action";
        private const string ControllerAttributeName = "asp-controller";
        private const string AreaAttributeName = "asp-area";
        private const string RouteAttributeName = "asp-route";
        private const string RouteValuesPrefix = "asp-route-";
        private const string Href = "href";
        private IDictionary<string, string> _routeValues;

        [HtmlAttributeName("asp-action")]
        public string Action { get; set; }
        [HtmlAttributeName("asp-controller")]
        public string Controller { get; set; }
        [HtmlAttributeName("asp-area")]
        public string Area { get; set; }
        [HtmlAttributeName("asp-route")]
        public string Route { get; set; }
        [HtmlAttributeName("asp-page")]
        public string Page { get; set; }
        [HtmlAttributeName("asp-page-handler")]
        public string PageHandler { get; set; }
        [HtmlAttributeName("asp-protocol")]
        public string Protocol { get; set; }
        [HtmlAttributeName("asp-host")]
        public string Host { get; set; }
        [HtmlAttributeName("asp-fragment")]
        public string Fragment { get; set; }


        public int PageTotal { get; set; }
        public int PageIndex { get; set; }
        [HtmlAttributeName("Previous")]
        public bool HasPreviousPage { get; set; }
        [HtmlAttributeName("Next")]
        public bool HasNextPage { get; set; }

        protected IHtmlGenerator Generator { get; }

        [HtmlAttributeName("asp-all-route-data", DictionaryAttributePrefix = "asp-route-")]
        public IDictionary<string, string> RouteValues
        {
            get
            {
                if (this._routeValues == null)
                    this._routeValues = (IDictionary<string, string>)new Dictionary<string, string>((IEqualityComparer<string>)StringComparer.OrdinalIgnoreCase);
                return this._routeValues;
            }
            set
            {
                this._routeValues = value;
            }
        }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public PaginationTagHelper(IHtmlGenerator generator)
        {
            this.Generator = generator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "ul";
            output.Attributes.Add("class", "pagination pagination-separated align-self-center");
            var active = string.Empty;

            RouteValueDictionary routeValueDictionary = (RouteValueDictionary) null;

            if (this._routeValues != null && this._routeValues.Count > 0)
                routeValueDictionary = new RouteValueDictionary((object) this._routeValues);
            if (this.Area != null)
            {
                if (routeValueDictionary == null)
                    routeValueDictionary = new RouteValueDictionary();
                routeValueDictionary["area"] = (object) this.Area;
            }

            TagBuilder tagBuilder = this.Generator.GenerateActionLink(this.ViewContext, string.Empty,
                this.Action, this.Controller, this.Protocol, this.Host, this.Fragment,
                (object) routeValueDictionary, (object) null);
            tagBuilder.AddCssClass("page-link");

            var previousClass = !HasPreviousPage ? "disabled" : "";
            var nextClass = !HasNextPage ? "disabled" : "";
            var previousButtonStart = $"<li class=\"page-item {previousClass}\">";

            var previousButtonEnd = "&larr; &nbsp; Prev</a></li>";
            output.Content.Append(previousButtonStart + GetString(tagBuilder) + previousButtonEnd);
            
            for (int i = 1; i <= PageTotal; i++)
            {
                active = i == PageIndex ? "active" : "";
                
                output.Content.Append($"<li class=\"page-item {active}\">{i}" + GetString(tagBuilder) + "</li>");

            }
            
            var nextButtonStart = $"<li class=\"page-item {nextClass}\">";
            var nextButtonEnd = "Next &nbsp; &rarr;</a></li>";
            output.Content.Append(nextButtonStart + GetString(tagBuilder) + nextButtonEnd);
            //var builder = this.Generator.GenerateActionLink(ViewContext,)
            //output.MergeAttributes(tagBuilder);


        }
        public static string GetString(IHtmlContent content)
        {
            var writer = new System.IO.StringWriter();
            content.WriteTo(writer, HtmlEncoder.Default);
            return writer.ToString();
        }
    }

     
}
