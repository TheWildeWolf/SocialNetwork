using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.DomainModels
{
    public class Mem_ProjectWork
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string ProjectTitle { get; set; }
        public string Description { get; set; }
        public DateTime CDate { get; set; }
        public Mem_Master Member { get; set; }

    }
}
