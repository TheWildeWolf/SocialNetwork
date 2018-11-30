using System;

namespace Hadia.Models.DomainModels
{
    public class Mem_MyNetwork
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int NetworkMemberId { get; set; }
        public DateTime CDate { get; set; }

        public ItemStatus Status { get; set; }

        public DateTime DDate { get; set; }

        public Mem_Master Member { get; set; }
        public Mem_Master NetworkMember { get; set; }
    }

    public enum ItemStatus : byte
    {
        Active = 1,
        Removed = 2,
        Deleted = 3
    }
}

