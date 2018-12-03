using System;

namespace Hadia.Models.DomainModels
{
    public class Sett_PrivacySetting
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int CategoryId { get; set; }

        public bool Chapter { get; set; }
        public bool Batch { get; set; }
        public bool MyNetwork { get; set; }
        public bool All { get; set; }

        public DateTime CDate { get; set; }
        public DateTime? MDate { get; set; }

        public Mem_Master Member { get; set; }
        public Sett_PrivacyInfoCategory Category { get; set; }
    }
}

