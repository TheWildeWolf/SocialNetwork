using System;
using System.Security.Claims;
using Hadia.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hadia.Controllers
{
    /*
     * Base Controller for API
     * inherit from this to Any New Api Controller
     *
     */
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[ServiceFilter(typeof(ActionFilter))]
    public class BaseApiController : ControllerBase
    {
        public int UserId => GetUserId();
        public string UserName => GetUsername();
        private string GetUsername()
        {
            return User.FindFirst(ClaimTypes.Name).Value;
        }
        private int GetUserId()
        {
           return Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
    }
}