using System;

namespace Hadia.Models.DomainModels
{
    public class Sett_GroupAdminHistory
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int MemberId { get; set; }
        public DateTime CDate { get; set; }

        public Mem_Master Member { get; set; }
        public Post_GroupMaster GroupMaster { get; set; }

    }
}

