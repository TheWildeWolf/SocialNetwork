namespace Hadia.Models.DomainModels
{
    public class Mem_AdminPrivilage
    {
        public int Id { get; set; }
        public int MemberId { get; set; }

        public bool MemberPosting { get; set; }
        public bool AdminAccess { get; set; }
        public bool HafAccess { get; set; }
        public bool AluminiDataAccess { get; set; }

        public bool BlockAccess { get; set; }

        public Mem_Master Member { get; set; }
        
    }
}
