using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.DomainModels
{
    public class Sett_Reset
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string Key { get; set; }
        public DateTime CDate { get; set; }
        public DateTime ExpireDate { get; set; }

        public Mem_Master Member { get; set; }
    }
}
