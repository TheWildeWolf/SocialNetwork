using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.DomainModels
{
    public class Res_Views
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public int MemberId { get; set; }
        public DateTime CDate { get; set; }

        public Resources Resourceses { get; set; }
        public Mem_Master Member { get; set; }
    }
}
