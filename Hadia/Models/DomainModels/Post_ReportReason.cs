using System;
using System.Collections.Generic;

namespace Hadia.Models.DomainModels
{
    public class Post_ReportReason
    {
        public int Id { get; set; }
        public string Reason { get; set; }

        public DateTime CDate { get; set; }
        public DateTime? MDate { get; set; }

        public int CLogin { get; set; }
        public int? MLogin { get; set; }

        public Mem_Master CreatedBy { get; set; }
        public Mem_Master ModifiedBy { get; set; }

        public ICollection<Post_Report> Reports { get; set; }
        
    }
}

