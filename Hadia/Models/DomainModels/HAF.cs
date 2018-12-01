using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.DomainModels
{
    public class HAF
    {
      
            public int Id { get; set; }
            public int YearId { get; set; }
            public int MemberId { get; set; }
            public bool Paid { get; set; }
            public DateTime CDate { get; set; }
            public int CLogin { get; set; }
            public int? MLogin { get; set; }
            public DateTime? MDate { get; set; }

        public HadiyaYearMaster HadiyaYear { get; set; }
        public Mem_Master Member { get; set; }
        public Mem_Master CreatedBy { get; set; }
        public Mem_Master ModifiedBy { get; set; }

    }


}
