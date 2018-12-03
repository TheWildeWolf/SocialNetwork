using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.DomainModels
{
    public class Mem_Contanct
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public ContactType Type { get; set; }
        public int ConuntryCodeId { get; set; }
        public bool IsVerified { get; set; }
        public DateTime CDate { get; set; }

        public Mem_Master Member { get; set; }
        public Mem_CountryCode CountryCode { get; set; }
    }

    public enum ContactType : byte
    {
        Mobile = 1,
        Email =2,
        WhatsApp=3
    }
}
