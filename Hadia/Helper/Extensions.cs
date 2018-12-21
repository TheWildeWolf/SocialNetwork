 using Microsoft.AspNetCore.Diagnostics;
 using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Hadia.Helper
{
    public static class Extensions
    {
        public static void ShowApplicationError(this HttpContext context, string exceptionMessage,string innerException)
        {
            var exceptionHandler = context.Features.Get<IExceptionHandlerPathFeature>();
            context.Response.Headers.Add("Application-Error", exceptionMessage);
            context.Response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            var result = JsonConvert.SerializeObject(new { error = exceptionMessage, detail = innerException });
            context.Response.WriteAsync(result);
            if (exceptionHandler.Path.Contains("/api/"))
            {
                context.Response.WriteAsync(result);
            }
            else
            {
                context.Response.WriteAsync("<h1>Hell No</h1><p>"+ exceptionMessage+"</p>");
            }

        }
    }
}