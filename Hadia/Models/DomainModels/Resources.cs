using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.DomainModels
{
    public class Resources
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableUpto { get; set; }
        public string Narration { get; set; }
        public ResourceStatus Status { get; set; }
        public DateTime CDate { get; set; }
        public DateTime DDate { get; set; }
        public DateTime MDate { get; set; }
        public int DLogin { get; set; }

        public Mem_Master Member { get; set; }
        public Mem_Master DeletedBy { get; set; }
    }
    public enum ResourceStatus : byte
    {
        
        Active = 1,
        Remove = 2,
        Delete = 3

    }
}
