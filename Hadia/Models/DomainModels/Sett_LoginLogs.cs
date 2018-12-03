using System;

namespace Hadia.Models.DomainModels
{
    public class Sett_LoginLog
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime? LogoutTime { get; set; }

        public string KeyValue { get; set; }
        public string IPAddress { get; set; }

        public Mem_Master Member { get; set; }
    }
}

