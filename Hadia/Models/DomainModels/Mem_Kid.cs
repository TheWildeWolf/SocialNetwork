using System;
using System.ComponentModel;

namespace Hadia.Models.DomainModels
{
    public class Mem_Kid
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string KidName { get; set; }
        public DateTime Age { get; set; }
        public GenderType Gender { get; set; }
        public DateTime CDate { get; set; }

        public Mem_Master Member { get; set; }
    }

    public enum GenderType : byte
    {
        [DisplayName("Male")]
        Male = 1,
        [DisplayName("Male")]
        Female = 2
    }

}

