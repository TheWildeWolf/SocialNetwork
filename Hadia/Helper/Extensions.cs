 using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Hadia.Helper
{
    public static class Extensions
    {
        public static void ShowApplicationError(this HttpContext context, string exceptionMessage,string innerException)
        {
            context.Response.Headers.Add("Application-Error", exceptionMessage);
            context.Response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            var result = JsonConvert.SerializeObject(new { error = exceptionMessage, detail = innerException });
            context.Response.WriteAsync(result);
            //if (context.Request.Headers["Accept"] == "application/json" || context.Request.Headers["Accept"] == "application/xml")
            //{
                
            //}
            //else
            //{

            //   // context.Response.WriteAsync("<h1>Hell No</h1><p>"+ exceptionMessage+"</p>");
            //}
            
        }
    }
}