using System;
using System.Collections.Generic;

namespace Hadia.Models.DomainModels
{
    public class Sett_DeviceInfoLog
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string DeviceKey { get; set; }

        public string Brand { get; set; }
        public string DeviceModel { get; set; }

        public DateTime CDate { get; set; }

        public Mem_Master Member { get; set; }

        public ICollection<Mem_Master> Members { get; set; }
    }
}

