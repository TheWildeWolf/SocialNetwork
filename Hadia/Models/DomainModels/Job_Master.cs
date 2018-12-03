using System;
using System.Collections.Generic;

namespace Hadia.Models.DomainModels
{
    public class Job_Master
    {
        public int Id { get; set; }
        public int PostedId { get; set; }
        public string Narration { get; set; }
        public DateTime ExpiryDate { get; set; }

        public JobStatus Status { get; set; }
        public DateTime CDate { get; set; }
        public DateTime? DDate { get; set; }

        public DateTime? MDate { get; set; }

        public int? DLogin { get; set; }

        public int? AppointedMemId { get; set; }
        public string AppoinmentDetail { get; set; }

        public Mem_Master PostedBy { get; set; }
        public Mem_Master AppointedMember { get; set; }
        public Mem_Master DeletedBy { get; set; }
        public ICollection<Job_View> Views { get; set; }
    }

    public enum JobStatus : byte
    {
        Active = 1,
        InActive = 2
    }

}

