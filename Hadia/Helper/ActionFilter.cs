using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
     * this is Action filter for checking anything before hitting
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
            #region Checking Token Key with database key
            var userId = Convert.ToInt32(context.HttpContext.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var tokenSid = context.HttpContext.User.FindFirst(x => x.Type == ClaimTypes.Sid).Value;
            var currentSid = await _db.Sett_LoginLogs
                .OrderByDescending(x => x.LoginTime)
                .Take(1)
                .SingleOrDefaultAsync(x => x.MemberId == userId);
            //var isVerified = _db.Mem_Masters.FromSql($"select IsActive from Mem_Masters where Id=@id",
            //    new SqlParameter("@id", userId)
            //    ).Single().IsVarified;
            if (!currentSid.KeyValue.Equals(tokenSid))
                context.Result = new UnauthorizedResult();
            #endregion
        }
    }
}
