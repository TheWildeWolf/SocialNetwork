 using System.Text.RegularExpressions;
 using System.Threading.Tasks;
 using Microsoft.AspNetCore.Diagnostics;
 using Microsoft.AspNetCore.Http;
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
            var result = JsonConvert.SerializeObject(new { error = exceptionMessage, detail = innerException });
            if (exceptionHandler.Path.Contains("/api/"))
            {
               await context.Response.WriteAsync(result);
            }
            else
            {
               await context.Response.WriteAsync(errorpage);
            }

        }
    }
}