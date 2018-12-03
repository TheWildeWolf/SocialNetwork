using System;

namespace Hadia.Models.DomainModels
{
    public class Sett_DeviceInfoLog
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string DeviceKey { get; set; }

        public DateTime CDate { get; set; }

        public Mem_Master Member { get; set; }
    }
}

