using System;

namespace Hadia.Models.DomainModels
{
    public class Mem_Membership
    {
        public int Id { get; set; }
        public int YearId { get; set; }
        public int MemberId { get; set; }

        public MembershipStatus Status { get; set; }
        public DateTime CDate { get; set; }
        public int CLogin { get; set; }
        public int MLogin { get; set; }

        public DateTime MDate { get; set; }

        public Mem_Master Member { get; set; }
        public Mem_Master CreatedBy { get; set; }
        public Mem_Master ModifiedBy { get; set; }

    }

    public enum MembershipStatus : byte
    {
        Active = 1,
        Removed = 2,
        Deleted = 2
    }

}

