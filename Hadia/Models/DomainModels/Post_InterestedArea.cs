using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.DomainModels
{
    public class Post_InterestedArea
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int InterestedAreaId { get; set; }
        public DateTime CDate { get; set; }
        public int CLogin { get; set; }


        public Post_GroupMaster GroupMaster { get; set; }
        public Post_InterestedAreaMaster InterestedAreaMaster { get; set; }
        public Mem_Master CreatedBy { get; set; }
    }
}
