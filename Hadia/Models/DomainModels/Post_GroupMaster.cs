using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.DomainModels
{
    public class Post_GroupMaster   
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public GroupType Type { get; set; }
        public GroupPrivacy OpenOrClosed { get; set; }
        public string Description { get; set; }
        public string GroupImage { get; set; }
        public DateTime FormedOn { get; set; }
        public string PassoutYear { get; set; }
        public DateTime CDate { get; set; }
        public int CLogin { get; set; }

        public Mem_Master CreatedBy { get; set; }

        public ICollection<Post_GroupMember> GroupMembers { get; set; }
        public ICollection<Mem_Master> Members { get; set; }
        public ICollection<Post_ChapterLeader> ChapterLeaders { get; set; }
        public ICollection<Post_InterestedArea> InterestedAreas { get; set; }
        public ICollection<Post_Master> Posts { get; set; }
        public ICollection<Sett_GroupAdminHistory> AdminGroup { get; set; }
    }

    public enum GroupType : byte
    {
        Chapter =1,
        Group =2,
        Batch  =3

    }

    public enum GroupPrivacy : byte
    {
        Open=1,
        Closed=2
    }
}
