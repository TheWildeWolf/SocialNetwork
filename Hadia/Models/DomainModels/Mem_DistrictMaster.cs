using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.DomainModels
{
    public class Mem_DistrictMaster
    {
        public int Id { get; set; }
        public string DistrictName { get; set; }
        public int StateId { get; set; }
        public DateTime CDate { get; set; }
        public int CLogin { get; set; }

        public Mem_Master CreatedBy { get; set; }
        public Mem_StateMaster State { get; set; }
    }
}
