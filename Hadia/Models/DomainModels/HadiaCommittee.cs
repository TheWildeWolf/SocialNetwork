using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.DomainModels
{
    public class HadiaCommittee
    {
        public int Id { get; set; }
        public DateTime FormedOn { get; set; }
        public int PresidentId { get; set; }
        public int Vice1Id { get; set; }
        public int Vice2Id { get; set; }
        public int SecreteryId { get; set; }
        public int JointSecretery1Id { get; set; }
        public int JointSecretery2Id { get; set; }
        public int TreasurerId { get; set; }
        public DateTime CDate { get; set; }
        public int CLogin { get; set; }
        public int? MLogin { get; set; }
        public DateTime? MDate { get; set; }

        public Mem_Master President { get; set; }
        public Mem_Master Vice1 { get; set; }
        public Mem_Master Vice2 { get; set; }
        public Mem_Master Secretery { get; set; }
        public Mem_Master JointSecr1 { get; set; }
        public Mem_Master JointSecr2 { get; set; }
        public Mem_Master Treasurer { get; set; }
        public Mem_Master CreatedBy { get; set; }
        public Mem_Master Modified { get; set; }

    }
}
