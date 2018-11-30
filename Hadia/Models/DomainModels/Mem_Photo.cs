using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.DomainModels
{
    public class Mem_Photo
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string Image { get; set; }
        public DateTime CDate { get; set; }
        public bool IsActive { get; set; }

        public Mem_Master Member { get; set; }
    }
}
