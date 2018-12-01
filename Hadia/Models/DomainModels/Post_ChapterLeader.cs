using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.DomainModels
{
    public class Post_ChapterLeader
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public DateTime DateFrom { get; set; }
        public int MemberId   { get; set; }
        public ChapterLeaderType Type { get; set; }
        public DateTime CDate { get; set; }
        public int CLogin { get; set; }

        public Post_GroupMaster Group { get; set; }
        public Mem_Master Member { get; set; }
        public Mem_Master CreatedBy { get; set; }
    }
    public enum ChapterLeaderType : byte
    {
        [DisplayName("President")]
        President = 1,
        [DisplayName("Secretery")]
        Secretery = 2,
        
    }
}
