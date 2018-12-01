using System;
using System.ComponentModel.DataAnnotations;

namespace Hadia.Models.DomainModels
{
    public class Sett_AdminActivityLog
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public DateTime DateTime { get; set; }
        [MaxLength(125)]
        public string ActivityType { get; set; }
        [MaxLength(125)]
        public string Page { get; set; }
        public string Notes { get; set; }

        public Mem_Master Member { get; set; }

    }
}

