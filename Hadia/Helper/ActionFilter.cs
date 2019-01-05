using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Hadia.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Helper
{
    /*
     * this is Hadia Action filter for checking anything before hitting
     * an action or after
     *
     */
    public class ActionFilter : IAsyncActionFilter
    {
        private HadiaContext _db;
        public ActionFilter(HadiaContext db)
        {
            _db = db;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            
            var user =context.HttpContext.User.FindFirst(x => x.Type == ClaimTypes.Name).Value;
            var data = await _db.Mem_Masters.FindAsync(12);
            //var userSetting =await _db.Database.ExecuteSqlCommandAsync("select");
            //_db.Database.BeginTransaction();
            //_db.Database.
            
            if(user != "")
                context.Result = new UnauthorizedResult();
        }
    }
}
