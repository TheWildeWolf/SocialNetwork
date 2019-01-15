using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Hadia.Data;
using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Helper
{
    public static class ContextExtensions
    {
        public static  IQueryable<Mem_Master> Verified(this HadiaContext db, Expression<Func<Mem_Master, bool>> expression)
        {
            return db.Mem_Masters.Where(x => x.IsVarified).Where(expression);
        }
    }
}