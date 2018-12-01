using System;

namespace Hadia.Models.DomainModels
{
    public class Job_View
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public int MemberId { get; set; }
        public DateTime CDate { get; set; }

        public Mem_Master Member { get; set; }
        public Job_Master Job { get; set; }

    }
}

