using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hadia.Data;
using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Helper
{
    public static class ContextExtensions
    {
        public static  IQueryable<Mem_Master> Varified(this HadiaContext db)
        {
            return db.Mem_Masters.Where(x => x.IsVarified);
        }
    }
}