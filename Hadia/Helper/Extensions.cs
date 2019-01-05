 using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Text.RegularExpressions;
 using System.Threading.Tasks;
 using Hadia.Data;
 using Hadia.Models.DomainModels;
 using Microsoft.AspNetCore.Diagnostics;
 using Microsoft.AspNetCore.Html;
 using Microsoft.AspNetCore.Http;
 using Microsoft.AspNetCore.Mvc.Rendering;
 using Microsoft.AspNetCore.Mvc.ViewFeatures;
 using Newtonsoft.Json;

namespace Hadia.Helper
{
    public static class Extensions
    {
        public static string ToCode(this string normalstring)
        {
            return Regex.Replace(normalstring, @"\t|\n|\r|'", " ");
        }

        public static async Task ShowApplicationError(this HttpContext context, string exceptionMessage,string innerException)
        {
            var errorpage = "<!DOCTYPE html><html><head>" +
                            "<meta charset=\"utf-8\"/>" +
                            " <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\"> " +
                            "<title>Hadia</title> <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">" +
                            "</head><body><section class=\"centered\"> <h1>500 Server Error</h1> <div class=\"container\">" +
                            " <div><span >Something went wrong</span></div></div></section>" +
                            "<style>@import url('https://fonts.googleapis.com/css?family=Lato|Roboto+Slab');" +
                            "*{position: relative; margin: 0; padding: 0; box-sizing: border-box;}" +
                            ".centered{height: 100vh; display: flex; flex-direction: column; justify-content: center;" +
                            " align-items: center;}h1{margin-bottom: 50px; font-family: 'Lato', sans-serif; font-size: 50px;}" +
                            ".message{display: inline-block; line-height: 1.2; transition: line-height .2s, width .2s; overflow: hidden;}" +
                            ".message,.hidden{font-family: 'Roboto Slab', serif; font-size: 18px;}.hidden{color: #FFF;}</style>" +
                            "<script type=\"text/javascript\">" +
                            "console.log('"+exceptionMessage.ToCode()+ "');" +
                            "console.log('" + innerException.ToCode() + "');" +
                            "</script></body></html>";
            var exceptionHandler = context.Features.Get<IExceptionHandlerPathFeature>();
            context.Response.Headers.Add("Application-Error", exceptionMessage);
            context.Response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            if (exceptionHandler.Path.Contains("/api/"))
            {
                var result = JsonConvert.SerializeObject(new { error = exceptionMessage.ToCode(), detail = innerException.ToCode() });
                await context.Response.WriteAsync(result);
            }
            else
            {
               await context.Response.WriteAsync(errorpage);
            }

        }

        public static HtmlString Pagination<T>(this IHtmlHelper helper,PaginatedList<T> paginatedList)
        {
            var prevDisabled = paginatedList.HasPreviousPage ? "disabled" : "";
            var nextDisabled = paginatedList.HasNextPage ? "disabled" : "";
            var active = string.Empty;
            var pageNumbers = "";
            var prevButton =
                $"<ul class=\"pagination pagination-separated align-self-center\"><li class=\"page-item {prevDisabled}\">" +
                $"<a asp-action=\"Index\" asp-route-page=\"{paginatedList.PageIndex - 1}\" class=\"page-link\">&larr;&nbsp;Prev</a>";
            for(int i = 1; i <= paginatedList.TotalPages; i++)
            {
                    active = i == paginatedList.PageIndex ? "active" : "";
                    pageNumbers += $"<li class=\"page-item {active}\"><a asp-action=\"Index\" asp-route-page=\"{i}\"" +
                                   $" asp-route-BatchId=\"\" asp-route-ChapterId=\"\" asp-route-Approval=\"\"" +
                                   $"class=\"page-link\">{i}</a></li>";
            }
            return new HtmlString("");
        }

        public static string TimeAgo(this DateTime dateTime)
        {
            string result = string.Empty;
            var timeSpan = DateTime.Now.Subtract(dateTime);

            if (timeSpan <= TimeSpan.FromSeconds(60))
            {
                result = string.Format("{0} seconds ago", timeSpan.Seconds);
            }
            else if (timeSpan <= TimeSpan.FromMinutes(60))
            {
                result = timeSpan.Minutes > 1 ?
                    String.Format("about {0} minutes ago", timeSpan.Minutes) :
                    "about a minute ago";
            }
            else if (timeSpan <= TimeSpan.FromHours(24))
            {
                result = timeSpan.Hours > 1 ?
                    String.Format("about {0} hours ago", timeSpan.Hours) :
                    "about an hour ago";
            }
            else if (timeSpan <= TimeSpan.FromDays(30))
            {
                result = timeSpan.Days > 1 ?
                    String.Format("about {0} days ago", timeSpan.Days) :
                    "yesterday";
            }
            else if (timeSpan <= TimeSpan.FromDays(365))
            {
                result = timeSpan.Days > 30 ?
                    String.Format("about {0} months ago", timeSpan.Days / 30) :
                    "about a month ago";
            }
            else
            {
                result = timeSpan.Days > 365 ?
                    String.Format("about {0} years ago", timeSpan.Days / 365) :
                    "about a year ago";
            }

            return result;
        }

        public static string TimeStamp(this DateTime dateTime)
        {
            return dateTime.ToString("yyyyMMddHHmmssfff");
        }
    }
}