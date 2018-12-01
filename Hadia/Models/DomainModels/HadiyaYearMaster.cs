using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.DomainModels
{
    public class HadiyaYearMaster
    {
        public int Id { get; set; }
        public string  YearName { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateUpTo { get; set; }
        public DateTime CDate { get; set; }
        public int CLogin { get; set; }
        public int?  MLogin { get; set; }
        public DateTime? MDate { get; set; }

        public Mem_Master YearAddedBy { get; set; }
        public Mem_Master YearModifiedBy { get; set; }
       
    }
}
